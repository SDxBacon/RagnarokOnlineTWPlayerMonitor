using System;
using SharpPcap;
using SharpPcap.LibPcap;
using SharpPcap.WinPcap;
using PacketDotNet;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RagnarokMonitor_metro
{
    class ragnarokMonitor
    {
        private bool onListen = false;
        private byte[] byteData = new byte[4096];
        private Socket socket;
        private Thread rawsocket_worker;
        private MainForm mainform;

        private string target_ip;
        private string target_port;
        private WinPcapDevice selectedWinPcapDevice;
        
        public ragnarokMonitor(MainForm mf)
        {
            mainform = mf;
        }

        public ragnarokMonitor(MainForm mf, string ip_in, int port_in)
        {
            mainform = mf;
            target_ip = ip_in;
            target_port = port_in.ToString();

            Console.WriteLine("ragnarokMonitor initialized with IP:"+target_ip+", Port:"+target_port);
        }

        private void monitor_recv_runtime()
        {
            //Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            selectedWinPcapDevice.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            string filter = $"tcp and host {target_ip}";
            selectedWinPcapDevice.Filter = filter;

            // Capture packets using GetNextPacket()
            while (onListen)
            {
                RawCapture rawCapture = selectedWinPcapDevice.GetNextPacket();
                if (rawCapture == null)
                {
                    continue;
                }

                // use PacketDotNet to parse this packet and print out
                // its high level information
                Packet parsedPacket = Packet.ParsePacket(rawCapture.LinkLayerType, rawCapture.Data);
                if (parsedPacket.HasPayloadPacket)
                {
                    TcpPacket tcp = parsedPacket.Extract<TcpPacket>();
                    if (tcp != null)
                    {
                        Console.WriteLine($"hasPayloadData: {tcp.HasPayloadData}");
                        if (tcp.HasPayloadData && tcp.PayloadData.Length > 0)
                        {
                            bool isROServerInfoPacket = ragnarokPacket.verifyServerInfo(tcp.PayloadData, tcp.PayloadData.Length);
                            if (isROServerInfoPacket)
                            {
                                handleServerInfo(tcp);
                            }
                        }
                        
                        Console.WriteLine(tcp.ToString());
                    }
                    
                }

                Console.WriteLine(parsedPacket.ToString());
            }

            selectedWinPcapDevice.Close();
        }

        private void handleServerInfo(TcpPacket packet)
        {
            int infoSetsNumber = 0,
                infoOffset = 32;

            // Calculating how many server information sets do we received from server.
            infoSetsNumber = ragnarokPacket.getServerInfoSetsNumber(packet.PayloadData.Length);

            byte[] payloadData = packet.PayloadData;

            try
            {
                for (int i = 0; i < infoSetsNumber; i++)
                {
                    int port, playerCount;
                    byte[] byteServerName = new byte[20];
                    string IP, strServerName;
                    IP = payloadData[0 + i * infoOffset].ToString() + "." + payloadData[1 + i * infoOffset].ToString() + "." +
                         payloadData[2 + i * infoOffset].ToString() + "." + payloadData[3 + i * infoOffset].ToString();
                    port = (payloadData[5 + i * infoOffset] << 8) + payloadData[4 + i * infoOffset];
                    playerCount = (payloadData[27 + i * infoOffset] << 8) + payloadData[26 + i * infoOffset];

                    Array.Copy(payloadData, 6 + i * infoOffset, byteServerName, 0, 20);
                    strServerName = System.Text.Encoding.GetEncoding("big5").GetString(byteServerName, 0, 20).Replace("\0", string.Empty);

                    mainform.Invoke(mainform.updateDataGridView_Var, strServerName, IP, port.ToString(), playerCount.ToString());

                    /* free byteServerName.*/
                    byteServerName = null;
                }

                onListen = false;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error in handle server info:" + e);
            }

        }

        private void startMonitoring()
        {
            onListen = true;

            /* setup tWinPcapDevice */
            WinPcapDevice wpDevice = getWinPcapDeviceByIP(mainform.getNetworkInterfaceText());
            if (wpDevice == null)
            {
                stopMonitoring();
                return;
            }

            selectedWinPcapDevice = wpDevice;

            rawsocket_worker = new Thread(monitor_recv_runtime);
            rawsocket_worker.Start();
        }


        private void stopMonitoring()
        {
            int timeout = 200;
            onListen = false;

            bool isTerminated;
            do
            {
                isTerminated = rawsocket_worker.Join(timeout);
            } while (!isTerminated);
            
            /**/
            mainform.Invoke(mainform.notifyMonitorFinish_Var);
        }

        public void Run()
        {
            if (onListen == true)
                stopMonitoring();
            else      
                startMonitoring();
            
        }

        private WinPcapDevice getWinPcapDeviceByIP(string ip)
        {
            // Retrieve the device list
            var devices = WinPcapDeviceList.Instance;

            // If no devices were found print an error
            if (devices.Count < 1)
            {
                Console.WriteLine("No devices were found on this machine");
                return null;
            }

            // Find WinPcapDevice that contains input IP address 
            foreach (WinPcapDevice device in devices)
            {
                ReadOnlyCollection<PcapAddress> addresses = device.Addresses;
                foreach (var pcapAddr in addresses)
                {
                    Sockaddr addr = pcapAddr.Addr;
                    if (addr.ToString() == ip)
                        return device;
                }
            }

            return null;
        }
    }
}

using System;
using SharpPcap;
using SharpPcap.LibPcap;
using PacketDotNet;
using System.Collections.ObjectModel;
using System.Threading;

namespace RagnarokMonitor_metro
{
    class ragnarokMonitor
    {
        private bool onListen = false;
        private Thread rawsocket_worker;
        private MainForm mainform;

        private string target_ip;
        private string target_port;
        private ILiveDevice selectedWinPcapDevice;

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
            ICaptureDevice dev = selectedWinPcapDevice;
            //Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            dev.Open(mode: DeviceModes.Promiscuous | DeviceModes.NoCaptureLocal, read_timeout: readTimeoutMilliseconds);

            string filter = $"tcp and host {target_ip}";
            dev.Filter = filter;

            

            // Capture packets using GetNextPacket()
            while (onListen)
            {
                RawCapture packet = null;
                PacketCapture e;

                if (dev.GetNextPacket(out e) == GetPacketStatus.PacketRead) {
                    packet = e.GetPacket();
                }

                if (packet == null)
                {
                    continue;
                }

                // use PacketDotNet to parse this packet and print out
                // its high level information
                Packet parsedPacket = Packet.ParsePacket(packet.LinkLayerType, packet.Data);
                if (parsedPacket.HasPayloadPacket)
                {
                    TcpPacket tcp = parsedPacket.Extract<TcpPacket>();
                    if (tcp != null)
                    {
                        if (tcp.HasPayloadData && tcp.PayloadData.Length > 0)
                        {
                            bool isROServerInfoPacket = ragnarokPacket.verifyServerInfo(tcp.PayloadData, tcp.PayloadData.Length);
                            if (isROServerInfoPacket)
                            {
                                onListen = false;
                                handleServerInfo(tcp);
                                mainform.Invoke(mainform.notifyMonitorFinish_Var);
                            }
                        }
                        
                    }
                    
                }

                Console.WriteLine(parsedPacket.ToString());
            }

            selectedWinPcapDevice.Close();
        }

        private void handleServerInfo(TcpPacket packet)
        {
            int infoSetsNumber = 0,
                infoOffset = 160;

            // Calculating how many server information sets do we received from server.
            infoSetsNumber = ragnarokPacket.getServerInfoSetsNumber(packet.PayloadData.Length);

            byte[] payloadData = packet.PayloadData;         

            try
            {
                for (int i = 0, dataOffset = 0; i < infoSetsNumber; i++)
                {
                    int port, playerCount;
                    byte[] byteServerName = new byte[20];
                    byte[] bytesUrl = new byte[70];

                    string IP, strServerName;
                    // slice server url bytes, NOTE: length = 70 bytes is a approximate value, the real size of server url info is much longer
                    Array.Copy(payloadData, 31 + i * infoOffset + dataOffset, bytesUrl, 0, 70);
                    string strServerURL = System.Text.Encoding.GetEncoding("ASCII").GetString(bytesUrl).Replace("\0", string.Empty);
                    string[] result = strServerURL.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    IP = result[0];
                    try
                    {
                        port = int.Parse(result[1]);
                    } catch
                    {
                        port = 0;
                    }
                    

                    // calculate playerCount
                    playerCount = (payloadData[27 + i * infoOffset + dataOffset] << 8) + payloadData[26 + i * infoOffset + dataOffset];

                    Array.Copy(payloadData, 6 + i * infoOffset + dataOffset, byteServerName, 0, 20);
                    strServerName = System.Text.Encoding.GetEncoding("big5").GetString(byteServerName, 0, 20).Replace("\0", string.Empty);

                    mainform.Invoke(mainform.updateDataGridView_Var, strServerName, IP, port.ToString(), playerCount.ToString());

                    dataOffset += 4;
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
            ILiveDevice device = getWinPcapDeviceByIP(mainform.getNetworkInterfaceText());
            if (device == null)
            {
                stopMonitoring();
                return;
            }

            selectedWinPcapDevice = device;

            rawsocket_worker = new Thread(monitor_recv_runtime);
            rawsocket_worker.Start();
        }


        private void stopMonitoring()
        {
            int timeout = 50;
            onListen = false;

            bool isTerminated;
            if (rawsocket_worker.IsAlive)
            {
                do
                {
                    isTerminated = rawsocket_worker.Join(timeout);
                } while (!isTerminated);
            }
           
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

        private ILiveDevice getWinPcapDeviceByIP(string ip)
        {
            // Retrieve the device list
            var devices = CaptureDeviceList.Instance;

            // If no devices were found print an error
            if (devices.Count < 1)
            {
                Console.WriteLine("No devices were found on this machine");
                return null;
            }

            // Find WinPcapDevice that contains input IP address 
            foreach (LibPcapLiveDevice device in devices)
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

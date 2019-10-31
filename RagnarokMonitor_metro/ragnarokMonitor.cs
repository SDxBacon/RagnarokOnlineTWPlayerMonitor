using System;
using System.Collections.Generic;
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
            while (onListen)
            {
                try
                {
                    int nRecv = socket.Receive(byteData, 0, byteData.Length, SocketFlags.None);
                    // parse data from raw socket.
                    ParseData(byteData, nRecv);
                }
                catch (Win32Exception w32e)
                {
                    if ( w32e.ErrorCode != 10060 )
                        Console.WriteLine("Error in _interListen:" + w32e.ErrorCode);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("monitor_recv_runtime", exception);
                }

            }

            /*free socket*/
            socket.Close();
            socket = null;

            /* clean threadListen. */
            rawsocket_worker = null;

            /**/
            mainform.Invoke(mainform.notifyMonitorFinish_Var);
        }

        private void ParseData(byte[] byteData, int nRecv)
        {
            if (nRecv <= 0) return;

            // parse IP Header & payload.
            IPHeader ipHeader = new IPHeader(byteData, nRecv);

            // parse Tcp Header & payload.
            if (ipHeader.ProtocolType == Protocol.TCP && ipHeader.MessageLength > 0)
            {
                TCPHeader tcpHeader = new TCPHeader(ipHeader.Data, ipHeader.MessageLength);
                Console.WriteLine("TCP packet incoming... IP:"+ ipHeader.SourceAddress.ToString()+", source port:"+ tcpHeader.SourcePort);

                if (ipHeader.SourceAddress.ToString() == target_ip
                    && tcpHeader.SourcePort == target_port)
                    Console.WriteLine("OH!!! you should look at it.");

                if (ipHeader.SourceAddress.ToString() == target_ip
                    && tcpHeader.SourcePort == target_port
                    && ragnarokPacket.verifyServerInfo(tcpHeader.Data, tcpHeader.MessageLength))
                {
                    Console.WriteLine("Server information packet received.");
                    mainform.Invoke(mainform.clearDataGridView_Var); // clear metroGrid.
                    handleServerInfo(tcpHeader); // handle server information packet.
                    mainform.Invoke(mainform.uploadMonitorResult_callback_Var);// check if need to upload monitor result to server.
                }
            }

        }

        private void handleServerInfo(TCPHeader tcpHeader)
        {
            int infoSetsNumber = 0,
                infoOffset = 32;

            // Calculating how many server information sets do we received from server.
            infoSetsNumber = ragnarokPacket.getServerInfoSetsNumber(tcpHeader.MessageLength);

            try
            {
                for (int i = 0; i < infoSetsNumber; i++)
                {
                    int port, playerCount;
                    byte[] byteServerName = new byte[20];
                    string IP, strServerName;
                    IP = tcpHeader.Data[0 + i * infoOffset].ToString() + "." + tcpHeader.Data[1 + i * infoOffset].ToString() + "." +
                         tcpHeader.Data[2 + i * infoOffset].ToString() + "." + tcpHeader.Data[3 + i * infoOffset].ToString();
                    port = (tcpHeader.Data[5 + i * infoOffset] << 8) + tcpHeader.Data[4 + i * infoOffset];
                    playerCount = (tcpHeader.Data[27 + i * infoOffset] << 8) + tcpHeader.Data[26 + i * infoOffset];

                    Array.Copy(tcpHeader.Data, 6 + i * infoOffset, byteServerName, 0, 20);
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

            /* setup raw socket*/
            setSocket(mainform.getNetworkInterfaceText());

            if (socket != null)
            {
                /*Setup threadListen.*/
                rawsocket_worker = new Thread(monitor_recv_runtime);
                rawsocket_worker.Start();
            }
        }


        private void stopMonitoring()
        {
            onListen = false;
            rawsocket_worker.Abort();
        }

        public void Run()
        {
            if (onListen == true)
                stopMonitoring();
            else      
                startMonitoring();
            
        }

        private void setSocket(string ip)
        {
            try
            {
                /* Setup raw socket*/
                socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Raw, ProtocolType.IP);

                socket.Bind(new IPEndPoint(IPAddress.Parse(ip), 0));

                socket.SetSocketOption(SocketOptionLevel.IP,            //Applies only to IP packets
                                           SocketOptionName.HeaderIncluded, //Set the include the header
                                           true);                           //option to true

                byte[] byTrue = BitConverter.GetBytes(1);
                byte[] byOut = new byte[4]; //Capture outgoing packets            

                //Socket.IOControl is analogous to the WSAIoctl method of Winsock 2
                socket.IOControl(IOControlCode.ReceiveAll,              //Equivalent to SIO_RCVALL constant of Winsock 2
                                 byTrue,
                                 byOut);

                socket.ReceiveTimeout = 1000;
            }
            catch(SocketException e)
            {
                Console.WriteLine("setSocket SocketException error:" + e);
                throw;
            }
            catch(ObjectDisposedException e)
            {
                Console.WriteLine("setSocket ObjectDisposedException error:" + e);
                throw;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("setSocket InvalidOperationException error:" + e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("setSocket Exception error:" + e);
                throw;
            }
        }
    }
}

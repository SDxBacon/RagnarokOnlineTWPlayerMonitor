using System;
using System.Net;
using SharpPcap;
using SharpPcap.LibPcap;

namespace Network
{
    public class NetworkInterfaceInfo
    {
        public int Index { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? IPv4 { get; set; }
    }

    public class NetworkHelper
    {
        /// <summary>
        /// 取得網路介面資訊
        /// </summary>
        /// <returns>網路介面資訊列表</returns>
        public static List<NetworkInterfaceInfo> retrieveNetworkInterfaces()
        {
            int i = 0;
            CaptureDeviceList devices = CaptureDeviceList.Instance;
            List<NetworkInterfaceInfo> interfaces = new List<NetworkInterfaceInfo>();

            // If no devices were found
            if (devices.Count < 1)
            {
                return interfaces;
            }

            // Otherwise, create a list of NetworkInterfaceInfo objects
            foreach (LibPcapLiveDevice dev in devices)
            {
                foreach (var item in dev.Addresses)
                {
                    string input = item.Addr?.ToString();
                    IPAddress address;
                    if (IPAddress.TryParse(input, out address!))
                    {
                        if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            interfaces.Add(new NetworkInterfaceInfo
                            {
                                Index = i,
                                Name = dev.Name,
                                Description = dev.Description,
                                IPv4 = item.Addr?.ToString(),
                            });
                        }
                    }
                }
                i++;
            }

            return interfaces;
        }

        public void SetupNetFilterAndRunSniffer()
        {
            // Set up netfilter rules for the specified network interface
            // ...

            // Run the sniffer using the netfilter rules
            // ...
        }
    }
}





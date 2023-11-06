using System;
using System.Net;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Text.Json;
using PipeEvent;

namespace RagnarokServerInfoSniffer
{
    /// <summary>
    /// Represents information about a network interface.
    /// </summary>
    public class NetworkInterfaceInfo
    {
        public int Index { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? IPv4 { get; set; }
    }

    /// <summary>
    /// Basic capture example
    /// </summary>
    public class Program
    {
        public static List<NetworkInterfaceInfo> retrieveNetworkInterfaces()
        {
            int i = 0;
            var devices = CaptureDeviceList.Instance;
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
                    string input = item.Addr.ToString();
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

        public static void Main()
        {
            // Retrieve the device list
            var devices = CaptureDeviceList.Instance;

            var interfaces = Program.retrieveNetworkInterfaces();

            string jsonString = JsonSerializer.Serialize(interfaces);

            Console.WriteLine(jsonString);

            Console.WriteLine();
            Console.Write("-- Please choose a device to capture: ");

            int i = int.Parse(Console.ReadLine());
            // i = 4;

            using var device = devices[i];

            // Register our handler function to the 'packet arrival' event
            device.OnPacketArrival +=
                new PacketArrivalEventHandler(device_OnPacketArrival);

            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            device.Open(mode: DeviceModes.Promiscuous | DeviceModes.DataTransferUdp | DeviceModes.NoCaptureLocal, read_timeout: readTimeoutMilliseconds);

            Console.WriteLine();
            Console.WriteLine("-- Listening on {0} {1}, hit 'Enter' to stop...",
                device.Name, device.Description);

            // Start the capturing process
            device.StartCapture();

            // Wait for 'Enter' from the user.
            Console.ReadLine();

            // Stop the capturing process
            device.StopCapture();

            Console.WriteLine("-- Capture stopped.");

            // Print out the device statistics
            Console.WriteLine(device.Statistics.ToString());
        }

        /// <summary>
        /// Prints the time and length of each received packet
        /// </summary>
        private static void device_OnPacketArrival(object sender, PacketCapture e)
        {
            var time = e.Header.Timeval.Date;
            var len = e.Data.Length;
            var rawPacket = e.GetPacket();
            Console.WriteLine("{0}:{1}:{2},{3} Len={4}",
                time.Hour, time.Minute, time.Second, time.Millisecond, len);
            Console.WriteLine(rawPacket.ToString());
        }
    }
}

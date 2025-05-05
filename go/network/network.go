package network

import (
	"fmt"
	"log"

	"github.com/google/gopacket"
	"github.com/google/gopacket/layers"
	"github.com/google/gopacket/pcap"
	"golang.org/x/net/context"
)

type PacketCaptureService struct {
	filter                string
	ctx                   context.Context
	cancel                context.CancelFunc
	packetReceivedChannel chan []byte
}

func NewPacketCaptureService(filter string) *PacketCaptureService {
	ctx, cancel := context.WithCancel(context.Background())
	packetReceivedChannel := make(chan []byte)

	return &PacketCaptureService{
		filter:                filter,
		ctx:                   ctx,
		cancel:                cancel,
		packetReceivedChannel: packetReceivedChannel,
	}
}

func (pcs *PacketCaptureService) GetPacketChannel() chan []byte {
	return pcs.packetReceivedChannel
}

func (pcs *PacketCaptureService) GetContext() context.Context {
	return pcs.ctx
}

// StopCapture terminates the packet capture service by canceling
// its associated context. This stops all ongoing packet capturing
// and monitoring operations.
func (pcs *PacketCaptureService) StopCapture() {
	pcs.cancel()
}

// StartCaptureAllInterfaces initiates packet capture on all available network interfaces except loopback.
// It performs the following steps for each non-loopback interface:
// 1. Opens the interface for live packet capture
// 2. Applies the configured BPF filter
// 3. Starts a goroutine to continuously capture packets
//
// The captured packets are sent to the packetReceivedChannel for processing.
// The capture can be stopped by canceling the context provided to the PacketCaptureService.
//
// This method runs asynchronously and does not block. Each interface capture runs in its own goroutine.
// If there are errors opening devices or setting filters, they will be logged as fatal errors.
func (pcs *PacketCaptureService) StartCaptureAllInterfaces() {
	// first, find all network interfaces with pcap library
	devices, err := pcap.FindAllDevs()
	if err != nil {
		return
	}

	fmt.Printf("Found %d devices:\n", len(devices))

	// then, iterate through all interfaces and capture packets
	for _, device := range devices {
		// fmt.Printf("Device %d: %s\n", index, device.Name)

		// if the interface is not valid, skip it
		if !IsValidInterface(device) {
			continue
		}

		go func() {
			// open the device for live capture
			handle, err := pcap.OpenLive(device.Name, 1600, true, pcap.BlockForever)
			if err != nil {
				log.Fatal("無法打開設備:", err)
				return
			}
			defer handle.Close()

			// set the BPF filter
			err = handle.SetBPFFilter(pcs.filter)
			if err != nil {
				log.Fatal("無法設置過濾器:", err)
				return
			}

			fmt.Println("Start sniffing on interface:", device.Name)
			// start capturing packets
			packetSource := gopacket.NewPacketSource(handle, handle.LinkType())
			packetSource.NoCopy = true

			for {
				select {
				case <-pcs.ctx.Done(): // listen for cancellation
					return
				case packet := <-packetSource.Packets():
					tcpLayer := packet.Layer(layers.LayerTypeTCP)
					if tcpLayer != nil {
						tcp, _ := tcpLayer.(*layers.TCP)

						payload := tcp.Payload
						if len(payload) > 0 {
							pcs.packetReceivedChannel <- payload
						}
					}

				}
			}
		}()
	}
}

// func (ns *NetworkService) StartSniffer(ifaceName string) {
// 	// target IP address to sniff
// 	// TODO: make this configurable
// 	// targetIP := "104.16.224.104"
// 	filterExpr := "tcp and net 104.16.0.0/16 and port 6900"

// 	ctx := ns.ctx
// 	if ctx == nil {
// 		// TODO: if the ctx is not set
// 	}

// 	go func() {
// 		// open the device for live capture
// 		handle, err := pcap.OpenLive(ifaceName, 1600, true, pcap.BlockForever)
// 		if err != nil {
// 			log.Fatal("無法打開設備:", err)
// 			return
// 		}
// 		defer handle.Close()

// 		// set the BPF filter
// 		err = handle.SetBPFFilter(filterExpr)
// 		if err != nil {
// 			log.Fatal("無法設置過濾器:", err)
// 			return
// 		}

// 		// start capturing packets
// 		packetSource := gopacket.NewPacketSource(handle, handle.LinkType())
// 		packetSource.NoCopy = true

// 		for {
// 			select {
// 			case <-ctx.Done(): // listen for cancellation
// 				return
// 			case packet := <-packetSource.Packets():
// 				// process the packet
// 				// TODO:
// 				appLayer := packet.ApplicationLayer()
// 				if appLayer != nil {
// 					_ = appLayer.Payload()
// 					// TODO:
// 					wg.Done()
// 				}
// 				continue
// 			}
// 		}

// 	}()

// }

// func (ns *NetworkService) StopSniffer() {
// 	// TODO:
// 	ns.ctx = nil // clear context
// }

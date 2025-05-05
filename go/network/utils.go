package network

import (
	"runtime"
	"strings"

	"github.com/google/gopacket/pcap"
)

// IsValidInterface determines if a network interface is suitable for packet capture.
// It applies various filters to exclude inappropriate interfaces:
//  1. Filters out loopback interfaces
//  2. Excludes interfaces without IP addresses
//  3. Excludes virtual interfaces (VMware, VPN, Docker, etc.)
//  4. On Windows: ensures valid NPF devices and filters Microsoft virtual interfaces
//  5. On macOS: excludes specific system interfaces (utun, awdl, llw, bridge)
//
// The function also verifies that the interface has at least one valid IPv4 address
// that is not loopback, multicast, or unspecified.
//
// Parameters:
//   - iface: pcap.Interface - The network interface to validate
//
// Returns:
//   - bool: true if the interface is valid for packet capture, false otherwise
func IsValidInterface(iface pcap.Interface) bool {
	// 1. drop loopback interfaces
	if strings.Contains(strings.ToLower(iface.Name), "loopback") ||
		strings.Contains(strings.ToLower(iface.Description), "loopback") ||
		strings.Contains(strings.ToLower(iface.Name), "lo") {
		return false
	}

	// 2. drop interfaces without IP addresses
	if len(iface.Addresses) == 0 {
		return false
	}

	// 3. exclude virtual interfaces
	virtualKeywords := []string{"virtual", "vmware", "vpn", "pseudo", "veth", "docker"}
	for _, keyword := range virtualKeywords {
		if strings.Contains(strings.ToLower(iface.Name), keyword) ||
			strings.Contains(strings.ToLower(iface.Description), keyword) {
			return false
		}
	}

	// 4. on Windows, ensure valid NPF devices and filter out Microsoft virtual interfaces
	if runtime.GOOS == "windows" {
		if !strings.HasPrefix(iface.Name, "\\Device\\NPF_") {
			return false
		}

		// exclude Microsoft virtual interfaces
		if strings.Contains(strings.ToLower(iface.Description), "microsoft") &&
			(strings.Contains(strings.ToLower(iface.Description), "loopback") ||
				strings.Contains(strings.ToLower(iface.Description), "virtual")) {
			return false
		}
	}

	// 5. on macOS, exclude specific system interfaces
	if runtime.GOOS == "darwin" {
		// exclude utun and awdl interfaces, which are usually VPN or Apple Wireless Direct Link
		if strings.HasPrefix(iface.Name, "utun") ||
			strings.HasPrefix(iface.Name, "awdl") ||
			strings.HasPrefix(iface.Name, "llw") ||
			strings.HasPrefix(iface.Name, "bridge") {
			return false
		}
	}

	// check if the interface has a valid IPv4 address
	hasValidIPv4 := false
	for _, addr := range iface.Addresses {
		ip := addr.IP
		if ip.To4() != nil && !ip.IsLoopback() && !ip.IsMulticast() && !ip.IsUnspecified() {
			hasValidIPv4 = true
			break
		}
	}

	return hasValidIPv4
}

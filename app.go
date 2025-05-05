package main

import (
	"context"
	"fmt"
	"myproject/go/config"
	"myproject/go/network"
	"myproject/go/ragnarok"
	"os"
	"path/filepath"

	"github.com/wailsapp/wails/v2/pkg/runtime"
)

// App struct
type App struct {
	ctx context.Context
}

type LoginServer = config.LoginServer

var loginServers []LoginServer = []LoginServer{
	{Name: "Taiwan", IP: "219.84.200.54", Port: 6900, PacketID: "0xc0a8"},
	{Name: "Korea", IP: "112.175.128.137", Port: 6900, PacketID: "0xc0a8"},
}

// NewApp creates a new App application struct
func NewApp() *App {
	return &App{}
}

// startup is called when the app starts. The context is saved
// so we can call the runtime methods
func (a *App) startup(ctx context.Context) {
	a.ctx = ctx

	_ = a.buildConfigPath()
	// config, err := a.loadConfig()
	// if err != nil {
	// 	runtime.LogError(a.ctx, "Failed to load config: "+err.Error())
	// 	return
	// }

	// runtime.LogInfo(a.ctx, "Config loaded: App Name = "+config.App.Name+", Server Count = "+string(len(config.Servers.Servers)))
}

func (a *App) buildConfigPath() string {
	// acquire the path of the executable
	exePath, err := os.Executable()
	if err != nil {
		// return nil, fmt.Errorf("failed to get executable path: %v", err)
		return ""
	}
	// get the directory of the executable
	dir := filepath.Dir(exePath)
	// construct the path to config.xml
	configPath := filepath.Join(dir, "config.xml")
	return configPath
}

// Greet returns a greeting for the given name
func (a *App) Greet(name string) string {
	return fmt.Sprintf("Hello %s, It's show time!", name)
}

// GetServers returns the list of servers
func (a *App) GetLoginServers() []LoginServer {
	return loginServers
}

func (a *App) StartCaptureCharacterServerList(targetServer string) {
	packetCaptureService := network.NewPacketCaptureService("tcp and net 219.84.200.54 and port 6900")

	fmt.Println("Start capture character server list")

	ctx := packetCaptureService.GetContext()
	channel := packetCaptureService.GetPacketChannel()

	// create a go routine to waiting for sniff worker done
	go func() {
		packetCaptureService.StartCaptureAllInterfaces()

		// notify frontend that all interfaces are listening
		runtime.EventsEmit(a.ctx, "todo")

		for {
			select {
			// receive packet from channel
			case payload := <-channel:
				if payload[0] != 0xc0 || payload[1] != 0xa8 {
					// skip if not 0xc0a8
					continue
				}

				charServerInfoList := ragnarok.ParsePayloadToCharacterServerInfo(payload, []byte{0xc0, 0xa8})

				fmt.Println("charServerInfoList: ", charServerInfoList)

				// packetCaptureService.StopCapture()
				continue
			case <-ctx.Done():
				// handle context done signal
				// TODO:
				// do nothing, just wait for signal
			}
		}

	}()

	// if targetServer in loginServers {
	// 	runtime.LogInfo(a.ctx, "Start listening to server: "+targetServer)
	// } else {
	// 	runtime.LogError(a.ctx, "Server not found: "+targetServer)
	// }

}

func (a *App) StopListenToLoginServer() {
	// stop listening
	// TODO:
}

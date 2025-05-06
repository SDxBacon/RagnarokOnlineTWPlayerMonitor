package main

import (
	"bytes"
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
	ctx                  context.Context
	isCapturing          bool
	packetCaptureService *network.PacketCaptureService
}

type LoginServer = config.LoginServer

var loginServers []LoginServer = []LoginServer{
	{Name: "Taiwan", IP: "219.84.200.54", Port: 6900, Pattern: []byte{0xc0, 0xa8}},
	{Name: "Korea", IP: "112.175.128.137", Port: 6900, Pattern: []byte{0xc0, 0xa8}},
}

// NewApp creates a new App application struct
func NewApp() *App {
	return &App{}
}

// startup is called when the app starts. The context is saved
// so we can call the runtime methods
func (a *App) startup(ctx context.Context) {
	a.ctx = ctx

	configPath := a.buildConfigPath() // FIXME:

	runtime.LogInfo(a.ctx, "[App.startup] Config path: "+configPath)

	customServers, err := config.LoadCustomServersFromXML("./config.xml")
	if err != nil {
		runtime.LogInfof(a.ctx, "[App.startup] Failed to load config: %v", err)
		return
	}

	if len(customServers) == 0 {
		runtime.LogInfo(a.ctx, "[App.startup] No custom servers found in config.")
		return
	}

	runtime.LogInfof(a.ctx, "[App.startup] customServers: %+v", customServers)
}

func (a *App) buildConfigPath() string {
	inDevMode := runtime.Environment(a.ctx).BuildType == "development"

	var basePath string
	if inDevMode {
		// in development mode, use the current working directory
		basePath, _ = os.Getwd()
	} else {
		// in production mode, use the executable path
		basePath, _ = os.Executable()
	}
	// get the directory of basePath
	dir := filepath.Dir(basePath)
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
	fmt.Println("[StartCaptureCharacterServerList] entering ...")

	// TODO:
	if a.isCapturing || a.packetCaptureService != nil {
		fmt.Println("[StartCaptureCharacterServerList] Already capturing, stop the previous capture.")
		prevPacketCaptureService := a.packetCaptureService
		prevPacketCaptureService.StopCapture() // stop the previous capture

		// reset isCapturing flag and clean up packetCaptureService reference
		a.isCapturing = false
		a.packetCaptureService = nil
	}

	packetCaptureService := network.NewPacketCaptureService("tcp and net 219.84.200.54 and port 6900")
	ctx := packetCaptureService.GetContext()
	channel := packetCaptureService.GetPacketChannel()

	// memorize the packetCaptureService and turn on isCapturing flag
	a.packetCaptureService = packetCaptureService
	a.isCapturing = true

	// create a go routine to waiting for sniff worker done
	go func() {
		packetCaptureService.StartCaptureAllInterfaces()

		// notify frontend that all interfaces might be listening
		// runtime.EventsEmit(a.ctx, "todo")

		for {
			select {
			case payload := <-channel:
				// receive packet from channel
				pattern := loginServers[0].Pattern
				// check if the payload is started with `pattern`
				if !bytes.Equal(payload[:2], pattern) {
					continue
				}

				charServerInfoList := ragnarok.ParsePayloadToCharacterServerInfo(payload, pattern)

				fmt.Println("charServerInfoList: ", charServerInfoList)

				// packetCaptureService.StopCapture()
				continue
			case <-ctx.Done():
				// handle context done signal
				// TODO:
				return
			}
		}

	}()
}

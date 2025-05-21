package main

import (
	"embed"
	"encoding/json"
	"log"

	"github.com/wailsapp/wails/v2"
	"github.com/wailsapp/wails/v2/pkg/logger"
	"github.com/wailsapp/wails/v2/pkg/options"
	"github.com/wailsapp/wails/v2/pkg/options/assetserver"
)

//go:embed all:frontend/dist
var assets embed.FS

//go:embed wails.json
var wailsConfig []byte

func getProductVersion() string {
	var config WailsConfig
	if err := json.Unmarshal(wailsConfig, &config); err != nil {
		log.Printf("解析 wails.json 失败: %v", err)
		return ""
	}

	return config.Info.ProductVersion
}

type WailsConfig struct {
	Info struct {
		ProductVersion string `json:"productVersion"`
	} `json:"info"`
}

func main() {
	// Create an instance of the app structure
	app := NewApp()

	app.appVersion = getProductVersion()

	// Create application with options
	err := wails.Run(&options.App{
		Title:              "Ragnarok Online 在線人數監視器",
		Width:              720,
		Height:             330,
		LogLevel:           logger.INFO,
		LogLevelProduction: logger.ERROR,
		AssetServer: &assetserver.Options{
			Assets: assets,
		},
		BackgroundColour: &options.RGBA{R: 27, G: 38, B: 54, A: 1},
		OnStartup:        app.startup,
		Bind: []interface{}{
			app,
		},
	})

	if err != nil {
		println("Error:", err.Error())
	}
}

package config

import (
	"encoding/xml"
	"fmt"
	"os"
)

type Configuration struct {
	XMLName xml.Name      `xml:"configuration"`
	App     ConfigApp     `xml:"app"`
	Servers ConfigServers `xml:"servers"`
}

type ConfigApp struct {
	Name string `xml:"name"`
}

type ConfigServers struct {
	Servers []LoginServer `xml:"server"`
}

type LoginServer struct {
	Name     string `xml:"name"`
	IP       string `xml:"IP"`
	Port     int    `xml:"port"`
	PacketID string `xml:"packet_id"`
}

func LoadConfig(path string) (*Configuration, error) {
	// check if the config.xml file exists
	if _, err := os.Stat(path); os.IsNotExist(err) {
		// config.xml not found, return nil
		return nil, nil
	} else if err != nil {
		return nil, fmt.Errorf("error checking config.xml at %s: %v", path, err)
	}

	// read the config.xml file
	data, err := os.ReadFile(path)
	if err != nil {
		return nil, fmt.Errorf("failed to read config.xml at %s: %v", path, err)
	}

	// parse XML
	var config Configuration
	err = xml.Unmarshal(data, &config)
	if err != nil {
		return nil, fmt.Errorf("failed to parse config.xml at %s: %v", path, err)
	}

	// check if the App.Name matches
	if config.App.Name != "myproject" {
		// not match, ignore the config
		return nil, nil
	}

	// match, return the config
	return &config, nil
}

package main

import (
	"fmt"
	"regexp"
	"strconv"
	"strings"

	"github.com/wailsapp/wails/v2/pkg/runtime"
)

// hasUpdate compares the current version with the latest version to determine if an update is available.
// The function expects version strings that can be parsed by the App's parseVersion function,
// which should return a slice of integers representing the major, minor, and patch versions.
//
// It performs a semantic versioning comparison:
// 1. First compares major versions
// 2. If major versions are equal, compares minor versions
// 3. If minor versions are equal, compares patch versions
//
// Parameters:
//   - currentVersion: A string representing the current application version
//   - latestVersion: A string representing the latest available version
//
// Returns:
//   - bool: true if an update is available (latest version is greater), false otherwise
//   - error: an error if either version string cannot be parsed
func (a *App) hasUpdate(currentVersion, latestVersion string) (bool, error) {
	parseVersion := a.parseVersion

	current, err := parseVersion(currentVersion)
	if err != nil {
		errMsg := fmt.Sprintf("Unable to parse current version: %v", err)
		runtime.LogErrorf(a.ctx, "[App.hasUpdate] %s", errMsg)
		return false, fmt.Errorf(errMsg)
	}

	latest, err := parseVersion(latestVersion)
	if err != nil {
		errMsg := fmt.Sprintf("Unable to parse latest version: %v", err)
		runtime.LogErrorf(a.ctx, "[App.hasUpdate] %s", errMsg)
		return false, fmt.Errorf(errMsg)
	}

	// compare major version
	if latest[0] > current[0] {
		return true, nil
	} else if latest[0] < current[0] {
		return false, nil
	}

	// compare minor version
	if latest[1] > current[1] {
		return true, nil
	} else if latest[1] < current[1] {
		return false, nil
	}

	// compare patch version
	if latest[2] > current[2] {
		return true, nil
	}

	// if all parts are equal, return false
	return false, nil
}

// parseVersion parses a semantic version string into a 3-element integer array.
//
// The version string is expected to be in the format "X.Y.Z" where X, Y, and Z are non-negative integers.
// A prefix "v" will be trimmed if present. The function validates that the version string matches the expected pattern.
//
// Parameters:
//   - version: a string representing the semantic version (e.g., "1.2.3" or "v1.2.3")
//
// Returns:
//   - [3]int: array containing the major, minor, and patch version numbers
//   - error: nil if parsing was successful, otherwise an error describing what went wrong
//
// Examples:
//   - "1.2.3" -> [1, 2, 3], nil
//   - "v1.2.3" -> [1, 2, 3], nil
//   - "1.2" -> error (invalid format)
//   - "1.a.3" -> error (contains non-numeric parts)
func (a *App) parseVersion(version string) ([3]int, error) {
	// remove possible "v" prefix
	version = strings.TrimPrefix(version, "v")

	// check if version string matches the pattern
	matched, err := regexp.MatchString(`^\d+\.\d+\.\d+$`, version)
	if err != nil {
		return [3]int{}, err
	}
	if !matched {
		errMsg := fmt.Sprintf("`version` is invalid:%s", version)
		runtime.LogErrorf(a.ctx, "[App.parseVersion] %s", errMsg)
		return [3]int{}, fmt.Errorf(errMsg)
	}

	// split version string into parts
	parts := strings.Split(version, ".")
	if len(parts) != 3 {
		errMsg := fmt.Sprintf("`version` should have 3 parts: %s", version)
		runtime.LogErrorf(a.ctx, "[App.parseVersion] %s", errMsg)
		return [3]int{}, fmt.Errorf(errMsg)
	}

	var result [3]int
	for i, part := range parts {
		num, err := strconv.Atoi(part)
		if err != nil {
			errMsg := fmt.Sprintf("Unable to convert version part to integer: %s", part)
			runtime.LogErrorf(a.ctx, "[App.parseVersion] %s", errMsg)
			return [3]int{}, fmt.Errorf(errMsg)
		}
		result[i] = num
	}

	return result, nil
}

package github

import (
	"context"
	"encoding/json"
	"fmt"
	"io"
	"net/http"
	"sort"
	"time"

	"github.com/wailsapp/wails/v2/pkg/runtime"
)

type GitHubService struct {
	ctx   context.Context
	owner string
	repo  string
}

type Release struct {
	TagName     string    `json:"tag_name"`
	PublishedAt time.Time `json:"published_at"`
}

func NewGitHubService(ctx context.Context) *GitHubService {
	return &GitHubService{
		ctx: ctx,
		// FIXME: should read from wails.json in the future
		owner: "SDxBacon",
		repo:  "RagnarokOnlinePlayerMonitor",
	}
}

func (ghs *GitHubService) GetLatestReleaseTag() (string, error) {
	owner := ghs.owner
	repo := ghs.repo

	url := fmt.Sprintf("https://api.github.com/repos/%s/%s/releases", owner, repo)

	resp, err := http.Get(url)
	if err != nil {
		runtime.LogErrorf(ghs.ctx, "[GitHubService.GetLatestReleaseTag] request fail: %v", err)
		return "", err
	}
	defer resp.Body.Close()

	body, err := io.ReadAll(resp.Body)
	if err != nil {
		runtime.LogErrorf(ghs.ctx, "[GitHubService.GetLatestReleaseTag] read response fail: %v", err)
		return "", err
	}

	var releases []Release
	if err := json.Unmarshal(body, &releases); err != nil {
		runtime.LogErrorf(ghs.ctx, "[GitHubService.GetLatestReleaseTag] unmarshal json fail: %v", err)
		return "", err
	}

	if len(releases) > 0 {
		sort.Slice(releases, func(i, j int) bool {
			return releases[i].PublishedAt.After(releases[j].PublishedAt)
		})

		runtime.LogInfof(ghs.ctx, "[GitHubService.GetLatestReleaseTag] latest tag: %s", releases[0].TagName)

		return releases[0].TagName, nil
	} else {
		runtime.LogError(ghs.ctx, "[GitHubService.GetLatestReleaseTag] no releases found")

		return "", fmt.Errorf("no releases found")
	}
}

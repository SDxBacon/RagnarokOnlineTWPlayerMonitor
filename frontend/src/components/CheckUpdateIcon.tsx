import isEmpty from "lodash/isEmpty";
import { useState } from "react";
import { useEffectOnce } from "react-use";
import { Button } from "@/components/ui/button";
import GitHubButton from "./GitHubButton";
import {
  Tooltip,
  TooltipContent,
  TooltipProvider,
  TooltipTrigger,
} from "@/components/ui/tooltip";

import { CheckForUpdate, OpenGitHub } from "../../wailsjs/go/main/App";

enum NewVersionStatus {
  Unknown = "Unknown",
  Checking = "Checking",
  UpToDate = "UpToDate",
  UpdateAvailable = "UpdateAvailable",
  Error = "Error",
}

const CheckUpdateIcon = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [status, setStatus] = useState(NewVersionStatus.Unknown);
  const [latestVersion, setLatestVersion] = useState<string | null>(null);

  const tooltipMessage = (() => {
    switch (status) {
      case NewVersionStatus.Checking:
        return "檢查是否有更新中...";
      case NewVersionStatus.UpToDate:
        return "目前已是最新版本";
      case NewVersionStatus.UpdateAvailable:
        return `有新版本可供下載! 最新版本: ${latestVersion}`;
      case NewVersionStatus.Error:
        return "檢查更新時發生錯誤";
      default:
        return "";
    }
  })();

  const handleMouseEnter = () => {
    setIsOpen(true);
  };

  const handleMouseLeave = () => {
    setIsOpen(false);
  };

  // effect to check for updates
  // this effect will run only once when the component is mounted
  useEffectOnce(() => {
    // update the status to checking
    setStatus(NewVersionStatus.Checking);
    // call the CheckForUpdate function from the App module
    CheckForUpdate()
      .then((result) => {
        const nextStatus = isEmpty(result)
          ? NewVersionStatus.UpToDate
          : NewVersionStatus.UpdateAvailable;
        const nextLatestVersion = isEmpty(result) ? null : result;

        // if the status is UpdateAvailable, set the isOpen state to true
        if (nextStatus === NewVersionStatus.UpdateAvailable) {
          setIsOpen(true);
        }

        setStatus(nextStatus);
        setLatestVersion(nextLatestVersion);
      })
      .catch(() => {
        setStatus(NewVersionStatus.Error);
        setLatestVersion(null);
      });
  });

  if (status === NewVersionStatus.Unknown) {
    return <GitHubButton onClick={OpenGitHub} />;
  }

  return (
    <TooltipProvider>
      <Tooltip open={isOpen}>
        <TooltipTrigger>
          <GitHubButton
            onMouseEnter={handleMouseEnter}
            onMouseLeave={handleMouseLeave}
            onClick={OpenGitHub}
          />
        </TooltipTrigger>
        <TooltipContent>
          <p>{tooltipMessage}</p>
        </TooltipContent>
      </Tooltip>
    </TooltipProvider>
  );
};

export default CheckUpdateIcon;

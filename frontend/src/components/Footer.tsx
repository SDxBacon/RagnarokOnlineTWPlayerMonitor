import {
  Tooltip,
  TooltipContent,
  TooltipProvider,
  TooltipTrigger,
} from "@/components/ui/tooltip";
import { LatestVersion } from "@/hooks/useCheckUpdateOnce";

import GitHubIconWithNotification from "./GitHubIconWithNotification";

import { OpenGitHub } from "../../wailsjs/go/main/App";

interface FooterProps {
  isUpdateAvailable: boolean;
  latestVersion: LatestVersion;
}

function Footer(props: FooterProps) {
  const { isUpdateAvailable, latestVersion } = props;
  return (
    <footer className="bg-muted px-6 py-3 border-t border-border">
      <div className="flex flex-col sm:flex-row justify-between items-center text-sm text-slate-500">
        {/* left - author information */}
        <p>Created by Ren-Wei Luo</p>
        {/* right - github icon with tooltip */}
        <TooltipProvider>
          <Tooltip>
            <TooltipTrigger className="relative" onClick={OpenGitHub}>
              <a
                className="hover:text-[#0c77f2] hover:underline flex items-center gap-1"
                href="#"
                onClick={OpenGitHub}
              >
                <GitHubIconWithNotification showDot={isUpdateAvailable} />
                View on GitHub
              </a>
            </TooltipTrigger>
            <TooltipContent>
              <p className="text-lg">
                New version: {latestVersion} is available!
              </p>
            </TooltipContent>
          </Tooltip>
        </TooltipProvider>
      </div>
    </footer>
  );
}

export default Footer;

import React from "react";
import {
  Tooltip,
  TooltipContent,
  TooltipProvider,
  TooltipTrigger,
} from "@/components/ui/tooltip";
import { OpenAuthorPage } from "../../wailsjs/go/main/App";

interface OpenAuthorPageButtonProps {
  children?: React.ReactNode;
}

function OpenAuthorPageButton(props: OpenAuthorPageButtonProps) {
  const { children } = props;

  return (
    <TooltipProvider>
      <Tooltip>
        <TooltipTrigger className="relative" onClick={OpenAuthorPage}>
          <a
            href="#"
            className="hover:text-[#0c77f2] hover:underline"
            onClick={OpenAuthorPage}
          >
            {children}
          </a>
        </TooltipTrigger>
        <TooltipContent>
          <p className="text-lg">Open the author's LinkedIn page</p>
        </TooltipContent>
      </Tooltip>
    </TooltipProvider>
  );
}

export default OpenAuthorPageButton;

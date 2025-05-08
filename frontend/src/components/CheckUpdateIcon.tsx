import isEmpty from "lodash/isEmpty";
import { useState } from "react";
import { useEffectOnce } from "react-use";
import { Button } from "@/components/ui/button";

import { CheckForUpdate } from "../../wailsjs/go/main/App";

const CheckUpdateIcon = () => {
  const [latestVersion, setLatestVersion] = useState<string | null>(null);

  // TODO: complete the function to check for updates
  useEffectOnce(() => {
    CheckForUpdate()
      .then((result) => {
        if (isEmpty(result)) {
          console.log("No updates available.");
          setLatestVersion("No updates available");
          return;
        }
        console.log("Update available:", result);
        setLatestVersion("Update available");
      })
      .catch((error) => {
        console.error("Error checking for updates:", error);
        setLatestVersion("Check fail");
      });
  });

  return (
    <div>
      <Button variant="outline" size="icon">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          strokeWidth={1.5}
          stroke="currentColor"
          className="size-5"
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            d="M3 16.5v2.25A2.25 2.25 0 0 0 5.25 21h13.5A2.25 2.25 0 0 0 21 18.75V16.5M16.5 12 12 16.5m0 0L7.5 12m4.5 4.5V3"
          />
        </svg>
      </Button>
    </div>
  );
};

export default CheckUpdateIcon;

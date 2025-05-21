import isEmpty from "lodash/isEmpty";
import { useState } from "react";
import { useEffectOnce } from "react-use";
import { CheckForUpdate } from "../../wailsjs/go/main/App";

export enum CheckVersionStatus {
  Unknown = "Unknown",
  Checking = "Checking",
  UpToDate = "UpToDate",
  UpdateAvailable = "UpdateAvailable",
  Error = "Error",
}

export type LatestVersion = string | null;

const useCheckUpdateOnce = (): [boolean, LatestVersion] => {
  const [status, setStatus] = useState(CheckVersionStatus.Unknown);
  const [latestVersion, setLatestVersion] = useState<LatestVersion>(null);

  const isUpdateAvailable = status === CheckVersionStatus.UpdateAvailable;

  // effect to check for updates
  // this effect will run only once when the component is mounted
  useEffectOnce(() => {
    // update the status to checking
    setStatus(CheckVersionStatus.Checking);
    // call the CheckForUpdate function from the App module
    CheckForUpdate()
      .then((result) => {
        const nextStatus = isEmpty(result)
          ? CheckVersionStatus.UpToDate
          : CheckVersionStatus.UpdateAvailable;
        const nextLatestVersion = isEmpty(result) ? null : result;

        setStatus(nextStatus);
        setLatestVersion(nextLatestVersion);
      })
      .catch(() => {
        setStatus(CheckVersionStatus.Error);
        setLatestVersion(null);
      });
  });

  return [isUpdateAvailable, latestVersion];
};

export default useCheckUpdateOnce;

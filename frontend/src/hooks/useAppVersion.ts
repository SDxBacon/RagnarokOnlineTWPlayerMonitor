import { useRef, useLayoutEffect } from "react";

import { GetAppVersion } from "../../wailsjs/go/main/App";

const useAppVersion = () => {
  const appVersionRef = useRef("");

  useLayoutEffect(() => {
    GetAppVersion().then((version: string) => {
      appVersionRef.current = version;
    });
  }, []);

  return appVersionRef.current;
};

export default useAppVersion;

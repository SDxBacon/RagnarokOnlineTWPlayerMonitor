import dayjs from "dayjs";
import isEmpty from "lodash/isEmpty";
import { useState } from "react";
import { useEffectOnce } from "react-use";
// import local components
import ServerSelect from "@/components/ServerSelect";
import CharacterServerTable from "@/components/CharacterServerTable";
import StartCaptureButton from "@/components/StartCaptureButton";
import Footer from "@/components/Footer";
// import local hooks
import useCheckUpdateOnce from "@/hooks/useCheckUpdateOnce";
// import wailjs api
import { GetLoginServers, StartCapture } from "../wailsjs/go/main/App";
import { config, ragnarok } from "../wailsjs/go/models";
// import local styles
import "./App.css";

function App() {
  const [selectedServer, setSelectedServer] =
    useState<config.LoginServer | null>(null);
  const [servers, setServers] = useState<config.LoginServer[]>([]);

  const [isCapture, setIsCapture] = useState(false);
  const [data, setData] = useState<ragnarok.CharacterServerInfo[]>([]);
  const [updatedTime, setUpdatedTime] = useState(Date.now());

  const [isUpdateAvailable, latestVersion] = useCheckUpdateOnce();

  const showUpdateTimeText = !isEmpty(data);

  const handleStartCaptureButtonClick = () => {
    if (selectedServer === null) return;

    setIsCapture(true);

    StartCapture(selectedServer.Name)
      .then((result) => {
        if (isEmpty(result)) {
          setData([]);
        } else {
          setData(result);
        }
        setIsCapture(false);
      })
      .catch((error) => {
        console.error("Error starting capture:", error);
        setIsCapture(false);
      })
      .finally(() => {
        // update the timestamp no matter if the capture is successful or not
        setUpdatedTime(Date.now());
      });
  };

  useEffectOnce(() => {
    (async () => {
      try {
        const servers = await GetLoginServers();
        setServers(servers);
        setSelectedServer(servers[0]);
      } catch (error) {
        console.error("Error fetching login servers:", error);
      }
    })();
  });

  return (
    <div
      id="app"
      className="flex flex-col bg-background text-foreground select-none"
    >
      {/* Main Part */}
      <div className="relative flex flex-1 gap-4 min-h-[225px] p-6 pt-8">
        {/* Left - server selector / capture button */}
        <div className="flex flex-col gap-7 justify-end">
          {/* 1. server select */}
          <ServerSelect value={selectedServer} options={servers} />
          {/* 2. start capture */}
          <StartCaptureButton
            className="rounded-[8px]"
            isLoading={isCapture}
            onClick={handleStartCaptureButtonClick}
          />
        </div>
        {/* Right - server table */}
        <CharacterServerTable data={data} />

        {/* Update time */}
        {showUpdateTimeText && (
          <span className="absolute right-7 bottom-1 text-muted-foreground italic text-sm">
            {`Updated: ${dayjs(updatedTime).format(
              "YYYY/MM/DD HH:mm:ss [(GMT]Z[)]"
            )}`}
          </span>
        )}
      </div>

      {/* Footer  */}
      <Footer
        isUpdateAvailable={isUpdateAvailable}
        latestVersion={latestVersion}
      />
    </div>
  );
}

export default App;

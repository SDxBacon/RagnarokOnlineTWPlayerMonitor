import isEmpty from "lodash/isEmpty";
import { useState, useEffect } from "react";
import { useEffectOnce } from "react-use";
// import local components
import ServerSelect from "@/components/ServerSelect";
import CheckUpdateIcon from "./components/CheckUpdateIcon";
import CharacterServerTable from "@/components/CharacterServerTable";
import StartCaptureButton from "@/components/StartCaptureButton";
// import wailjs api
import { GetLoginServers, StartCapture } from "../wailsjs/go/main/App";
import { config, ragnarok } from "../wailsjs/go/models";
import { EventsOn } from "../wailsjs/runtime/runtime";
// import local styles
import "./App.css";

function App() {
  const [selectedServer, setSelectedServer] =
    useState<config.LoginServer | null>(null);
  const [servers, setServers] = useState<config.LoginServer[]>([]);

  const [isCapture, setIsCapture] = useState(false);
  const [data, setData] = useState<ragnarok.CharacterServerInfo[]>([]);

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

  useEffect(() => {
    EventsOn("CHAR_SERVER_CAPTURED", (data: any) => {});
  }, []);

  return (
    <div id="app" className="bg-background text-foreground px-4 py-2">
      {/*  */}
      <div className="flex items-center justify-end">
        <CheckUpdateIcon />
      </div>

      {/*  */}
      <div className="flex p-4 gap-4">
        <div className="flex flex-col gap-4 justify-end">
          <ServerSelect value={selectedServer} options={servers} />
          <StartCaptureButton
            isLoading={isCapture}
            onClick={handleStartCaptureButtonClick}
          />
        </div>
        <CharacterServerTable data={data} />
      </div>

      {/*  */}
    </div>
  );
}

export default App;

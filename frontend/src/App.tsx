import { useState, useEffect } from "react";
import { useEffectOnce } from "react-use";
// import local components
import ServerSelect from "@/components/ServerSelect";
import CheckUpdateIcon from "./components/CheckUpdateIcon";
import CharacterServerTable from "@/components/CharacterServerTable";
// import wailjs api
import { GetLoginServers } from "../wailsjs/go/main/App";
import { config } from "../wailsjs/go/models";
// import local styles
import "./App.css";

function App() {
  const [selectedServer, setSelectedServer] =
    useState<config.LoginServer | null>(null);
  const [servers, setServers] = useState<config.LoginServer[]>([]);

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
    <div id="App" className="bg-background text-foreground">
      <CheckUpdateIcon />
      <ServerSelect value={selectedServer} options={servers} />
      <CharacterServerTable />
    </div>
  );
}

export default App;

import { useState, useEffect } from "react";
import { useEffectOnce } from "react-use";
// import local components
import ServerSelect from "@/components/ServerSelect";
import CharacterServerTable from "@/components/CharacterServerTable";
// import wailjs api
import { GetLoginServers } from "../wailsjs/go/main/App";
import { config } from "../wailsjs/go/models";
// import local styles
import "./App.css";

function App() {
  const [servers, setServers] = useState<config.LoginServer[]>([]);

  const gettt = async () => {
    try {
      const servers = await GetLoginServers();
      setServers(servers);
      console.log("Login servers:", servers);
    } catch (error) {
      console.error("Error fetching login servers:", error);
    }
  };

  useEffectOnce(() => {
    gettt();
  });

  return (
    <div id="App" className="bg-background text-foreground">
      <ServerSelect options={servers} />
      <CharacterServerTable />
    </div>
  );
}

export default App;

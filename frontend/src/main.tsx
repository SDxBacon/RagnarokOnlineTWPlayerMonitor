import React from "react";
import { createRoot } from "react-dom/client";
import { ThemeProvider } from "./components/ThemeProvider";
import App from "./App";
import "./style.css";

const container = document.getElementById("root");

const root = createRoot(container!);

root.render(
  <React.StrictMode>
    <ThemeProvider defaultTheme="dark" storageKey="ui-theme">
      <App />
    </ThemeProvider>
  </React.StrictMode>
);

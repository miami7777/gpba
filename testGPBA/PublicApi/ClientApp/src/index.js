import React, { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import App from "./App";

// a div with this id needs to actually exist in the index.html
const container = document.getElementById("root");

const root = createRoot(container);

export default function Index() {
    return (
        <StrictMode>
            <App />
        </StrictMode>
    );
}

root.render(<Index />);
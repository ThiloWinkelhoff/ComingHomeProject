import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import App from "./App.tsx";
import { BrowserRouter } from "react-router-dom";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { CssBaseline } from "@mui/material";
import "./index.css";

const theme = createTheme({
  typography: {
    allVariants: {
      color: "#ffffff", // Sets default text color for all typography variants
    },
  },
  palette: {
    mode: "dark", // Optional: sets the base to dark mode
  },
});
createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </ThemeProvider>
  </StrictMode>
);

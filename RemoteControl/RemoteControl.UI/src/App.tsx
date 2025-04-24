import { Route, Routes } from "react-router-dom";
import { Box, Typography } from "@mui/material";
import Header from "./Components/Header/Header";
import React, { Suspense } from "react";
const Devices = React.lazy(() => import("./Pages/Devices/Devices"));
const Scripts = React.lazy(() => import("./Pages/Scripts/Scripts"));
const Home = React.lazy(() => import("./Pages/Home/Home"));

function App() {
  return (
    <Box
      sx={{
        display: "grid",
        gridTemplateRows: "50px 1fr",
        height: "100%",
        width: "100%",
      }}
    >
      <Header />
      <Suspense fallback={<Typography>Loading...</Typography>}>
        <Routes>
          <Route path="/configure-devices" element={<Devices />} />
          <Route path="/configure-scripts" element={<Scripts />} />
          <Route path="/home" element={<Home />} />
          <Route path="/" element={<Home />} />
        </Routes>
      </Suspense>
    </Box>
  );
}

export default App;

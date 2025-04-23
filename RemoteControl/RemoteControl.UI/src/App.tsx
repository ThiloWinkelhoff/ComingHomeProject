import { Route, Routes } from "react-router-dom";
import Home from "./Pages/Home/Home";
import Devices from "./Pages/Devices/Devices";
import Scripts from "./Pages/Scripts/Scripts";
import { Box } from "@mui/material";
import Header from "./Components/Header/Header";

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

      <Routes>
        <Route path="/configure-devices" element={<Devices />} />
        <Route path="/configure-scripts" element={<Scripts />} />
        <Route path="/home" element={<Home />} />
        <Route path="/" element={<Home />} />
      </Routes>
    </Box>
  );
}

export default App;

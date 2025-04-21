import { Route, Routes } from "react-router-dom";
import Home from "./Pages/Home/Home";
import Devices from "./Pages/Devices/Devices";
import Scripts from "./Pages/Scripts/Scripts";
import { Box } from "@mui/material";
import Header from "./Components/Sidebar/Header";
import NotFound from "./Pages/NotFound/NotFound";

function App() {
  return (
    <Box
      sx={{
        display: "grid",
        gridTemplateRows: "50px 1fr",
        height: "100vh",
        width: "100vw",
        bgcolor: "#000000",
      }}
    >
      <Header />

      <Routes>
        <Route path="/devices" element={<Devices />} />
        <Route path="/scripts" element={<Scripts />} />
        <Route path="/home" element={<Home />} />
        <Route path="/" element={<Home />} />
        <Route path="*" element={<NotFound />} />
      </Routes>
    </Box>
  );
}

export default App;

import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import Home from "./Pages/Home/Home";
import Login from "./Pages/Login/Login";
import Linked from "./Pages/Linked/Linked";
import Devices from "./Pages/Devices/Devices";
import Sidebar from "./Components/Sidebar/Sidebar";
import Scripts from "./Pages/Scripts/Scripts";

function App() {
  return (
    <div
      className="AppContainer"
      style={{ display: "flex", height: "100vh", width: "100vw" }}
    >
      {/* Sidebar Component */}
      <Sidebar />

      {/* Main Content */}
      <div className="contentContainer">
        <Routes>
          <Route path="/linked" element={<Linked />} />
          <Route path="/devices" element={<Devices />} />
          <Route path="/scripts" element={<Scripts />} />
          <Route path="/home" element={<Home />} />
          <Route path="/" element={<Login />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;

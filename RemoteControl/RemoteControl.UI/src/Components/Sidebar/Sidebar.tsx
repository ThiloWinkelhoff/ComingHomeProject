import React from "react";
import { Link } from "react-router-dom";
import "./Sidebar.css"; // Assuming you'll create a corresponding Sidebar CSS file

const Sidebar = () => {
  return (
    <div
      className="Sidebar"
      style={{
        height: "100%",
        width: "20%",
        backgroundColor: "#333",
        color: "white",
        padding: "20px",
      }}
    >
      <ul>
        <li>
          <Link to="/home">Home</Link>
        </li>
        <li>
          <Link to="/linked">Linked</Link>
        </li>
        <li>
          <Link to="/devices">Devices</Link>
        </li>
        <li>
          <Link to="/scripts">Scripts</Link>
        </li>
      </ul>
    </div>
  );
};

export default Sidebar;

import { Link } from "react-router-dom";
import "./Sidebar.css"; // Assuming you'll create a corresponding Sidebar CSS file
import gearicon from "../../assets/GearIcon.svg";
const Sidebar = () => {
  return (
    <div className="Sidebar">
      <img src={gearicon}></img>
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
        <li>
          <Link to="/login">Login</Link>
        </li>
      </ul>
    </div>
  );
};

export default Sidebar;

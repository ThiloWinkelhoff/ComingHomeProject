import codeIcon from "../../assets/code_icon.svg";
import homeIcon from "../../assets/home_icon.svg";
import deviceIcon from "../../assets/device.icon.svg";

const navItems = [
  {
    label: "Home",
    display: <img src={homeIcon} alt="" />,
    path: "/home",
  },
  {
    label: "Devices",
    display: <img src={deviceIcon} alt="" />,
    path: "/configure-devices",
  },
  {
    label: "Scripts",
    display: <img src={codeIcon} alt="" />,
    path: "/configure-scripts",
  },
];

export default navItems;

import fetchConnectedDevices from "../../api/devices";
import ItemDisplay from "../../Components/Display/Item.Displayer";

function Devices() {
  return (
    <ItemDisplay
      fetching={fetchConnectedDevices}
      header={"Devices"}
      subHeader="Scripts"
      newPrompt="Script"
    ></ItemDisplay>
  );
}

export default Devices;

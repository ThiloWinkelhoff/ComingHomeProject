import fetchConnectedDevices from "../../api/devices";
import ItemDisplay from "../../Components/Display/ItemDisplay";

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

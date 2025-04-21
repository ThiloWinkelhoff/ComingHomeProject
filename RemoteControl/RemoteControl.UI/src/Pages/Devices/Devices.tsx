import ItemDisplay from "../../Components/Display/ItemDisplay";
import mockDeviceData from "../../Common/Device";

function Devices() {
  return (
    <ItemDisplay
      items={mockDeviceData}
      header={"Devices"}
      subHeader="Scripts"
      newPrompt="Script"
    ></ItemDisplay>
  );
}

export default Devices;

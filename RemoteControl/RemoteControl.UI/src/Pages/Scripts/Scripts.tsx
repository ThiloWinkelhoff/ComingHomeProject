import MockData from "../../Common/Script";
import ItemDisplay from "../../Components/Display/ItemDisplay";

function Scripts() {
  return (
    <ItemDisplay
      items={MockData}
      header={"Scripts"}
      subHeader={"Devices"}
      newPrompt={"Device"}
    ></ItemDisplay>
  );
}

export default Scripts;

import fetchScripts from "../../api/Scripts";
import ItemDisplay from "../../Components/Display/Item.Displayer";

function Scripts() {
  return (
    <ItemDisplay
      fetching={fetchScripts}
      header={"Scripts"}
      subHeader={"Devices"}
      newPrompt={"Device"}
    ></ItemDisplay>
  );
}

export default Scripts;

import { List } from "@mui/material";
import ItemCard from "./Item.Displayer.ItemList.Card.tsx";
import Item from "../../../Common/Item.ts";

interface Props {
  items: Item[];
  openScripts: { [key: number]: boolean };
  toggleOpen: (id: number) => void;
  subHeader: string;
  newPrompt: string;
  setDeleteTarget: (target: { item: Item; subitemId: number }) => void;
  setOpenConfirmation: (open: boolean) => void;
  reload: () => void;
}

const ItemList = ({
  items,
  openScripts,
  toggleOpen,
  subHeader,
  newPrompt,
  setDeleteTarget,
  setOpenConfirmation,
  reload,
}: Props) => {
  return (
    <List>
      {items.map((item) => (
        <ItemCard
          key={item.id}
          item={item}
          open={!!openScripts[item.id]}
          toggleOpen={toggleOpen}
          subHeader={subHeader}
          newPrompt={newPrompt}
          setDeleteTarget={setDeleteTarget}
          setOpenConfirmation={setOpenConfirmation}
          reload={() => {
            reload();
          }}
        />
      ))}
    </List>
  );
};

export default ItemList;

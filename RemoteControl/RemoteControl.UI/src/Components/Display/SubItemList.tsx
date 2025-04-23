import { Button, ListItem, ListItemText } from "@mui/material";
import Item from "../../Common/Item";

interface Props {
  item: Item;
  setDeleteTarget: (target: { item: Item; subitemId: number }) => void;
  setOpenConfirmation: (open: boolean) => void;
}

const SubItemList = ({ item, setDeleteTarget, setOpenConfirmation }: Props) => {
  return (
    <>
      {item.subItems?.map((subItem) => (
        <ListItem
          key={subItem.id}
          sx={{ display: "flex", justifyContent: "space-around" }}
        >
          <ListItemText>{subItem.name}</ListItemText>
          <Button
            sx={{
              height: "80%",
              aspectRatio: "1 / 1",
              minWidth: 0,
              p: 0,
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
            }}
            onClick={() => {
              setDeleteTarget({ item, subitemId: subItem.id });
              setOpenConfirmation(true);
            }}
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              height="24px"
              viewBox="0 -960 960 960"
              width="24px"
              fill="#e3e3e3"
            >
              <path d="M280-120q-33 0-56.5-23.5T200-200v-520h-40v-80h200v-40h240v40h200v80h-40v520q0 33-23.5 56.5T680-120H280Zm400-600H280v520h400v-520ZM360-280h80v-360h-80v360Zm160 0h80v-360h-80v360Z" />
            </svg>
          </Button>
        </ListItem>
      ))}
    </>
  );
};

export default SubItemList;

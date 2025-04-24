import { Button, ListItem, ListItemText } from "@mui/material";
import Item from "../../Common/Item";
import deleteIcon from "../../assets/delete_icon.svg";

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
            <img src={deleteIcon} alt="" />
          </Button>
        </ListItem>
      ))}
    </>
  );
};

export default SubItemList;

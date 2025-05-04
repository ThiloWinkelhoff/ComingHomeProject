import {
  Box,
  Collapse,
  ListItem,
  Typography,
  List,
  ListItemText,
} from "@mui/material";
import AddSubItemInput from "./Item.Displayer.ItemList.Card.Addition.tsx";
import Item from "../../../Common/Item.ts";
import SubItemList from "./Item.Displayer.ItemList.SubItemList.tsx";

interface Props {
  item: Item;
  open: boolean;
  toggleOpen: (id: number) => void;
  subHeader: string;
  newPrompt: string;
  setDeleteTarget: (target: { item: Item; subitemId: number }) => void;
  setOpenConfirmation: (open: boolean) => void;
  reload: () => void;
}

const ItemCard = ({
  item,
  open,
  toggleOpen,
  subHeader,
  newPrompt,
  setDeleteTarget,
  setOpenConfirmation,
  reload,
}: Props) => {
  return (
    <Box sx={{ mb: 1, borderRadius: 1, bgcolor: "#131212", boxShadow: 1 }}>
      <ListItem
        onClick={() => toggleOpen(item.id)}
        sx={{
          px: 2,
          py: 1,
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
          borderBottom: open ? "1px solid #000000" : "none",
        }}
        component="div"
      >
        <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
          {/* Icon */}
          <Typography variant="h5">{item.getNaming()}</Typography>
        </Box>
        <Box
          height="100%"
          display="flex"
          justifyContent="center"
          alignItems="center"
        >
          <Typography variant="body2">
            {subHeader}:{item.subItems?.length ?? 0}
          </Typography>
        </Box>
      </ListItem>

      <Collapse in={open} timeout="auto" unmountOnExit>
        <List disablePadding sx={{ pl: 4, pb: 1, pr: 4 }}>
          <ListItemText>
            <Typography variant="h5">{subHeader}</Typography>
          </ListItemText>
          <AddSubItemInput
            newPrompt={newPrompt}
            item={item}
            setOpenConfirmation={() => {
              reload();
            }}
          />
          <SubItemList
            item={item}
            setDeleteTarget={setDeleteTarget}
            setOpenConfirmation={setOpenConfirmation}
          />
        </List>
      </Collapse>
    </Box>
  );
};

export default ItemCard;

import { Autocomplete, Button, TextField, Typography } from "@mui/material";
import { Box, ListItem } from "@mui/material";
import { useEffect, useState } from "react";
import Item from "../../../Common/Item";
import ReducedItem from "../../../Common/ReducedItem";
import additionIcon from "../../../assets/add_icon.svg";

interface AddSubItemInputProps {
  setOpenConfirmation: () => void;
  newPrompt: string;
  item: Item;
}

const AddSubItemInput = ({
  newPrompt,
  item,
  setOpenConfirmation,
}: AddSubItemInputProps) => {
  const [options, setOptions] = useState<ReducedItem[]>([]);
  const [selected, setSelected] = useState<ReducedItem[]>([]);

  useEffect(() => {
    const fetchOptions = async () => {
      if (!item || typeof item.getUnconnected !== "function") return;

      const unconnected = await item.getUnconnected();
      setOptions(unconnected);
    };

    fetchOptions();
  }, [item]);

  const handleAdd = async () => {
    for (const subItem of selected) {
      await item.addSubItem(subItem.id);
    }
    setSelected([]);
    const updatedOptions = await item.getUnconnected();
    setOptions(updatedOptions);
    setOpenConfirmation();
  };

  return (
    <ListItem
      sx={{
        pt: 4,
        pb: 10,
        height: "48px",
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
      }}
    >
      <Box sx={{ flexGrow: 1, mr: 1 }}>
        <Autocomplete
          multiple
          disablePortal
          options={options}
          value={selected}
          getOptionLabel={(option) => option.name}
          onChange={(_event, newValue) => setSelected(newValue)}
          sx={{
            width: "100%",
            color: "white",
          }}
          renderInput={(params) => (
            <TextField
              {...params}
              variant="standard"
              label={
                <Typography variant="body1" noWrap>
                  {`Add New ${newPrompt} :`}
                </Typography>
              }
            />
          )}
        />
      </Box>
      <Button
        onClick={handleAdd}
        sx={{
          height: "80%",
          aspectRatio: "1 / 1",
          minWidth: 0,
          p: 0,
        }}
      >
        <img src={additionIcon} alt="" />
      </Button>
    </ListItem>
  );
};

export default AddSubItemInput;

import { Autocomplete, Button, TextField, Typography } from "@mui/material";
import { Box, ListItem } from "@mui/material";
import { useEffect, useState } from "react";
import Item from "../../Common/Item";
import ReducedItem from "../../Common/ReducedItem";

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
        pb: 0,
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
            backgroundColor: "#000000",
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
        <Box
          component="svg"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 -960 960 960"
          sx={{ height: "100%", width: "100%", fill: "#e3e3e3" }}
        >
          <path d="M440-440H200v-80h240v-240h80v240h240v80H520v240h-80v-240Z" />
        </Box>
      </Button>
    </ListItem>
  );
};

export default AddSubItemInput;

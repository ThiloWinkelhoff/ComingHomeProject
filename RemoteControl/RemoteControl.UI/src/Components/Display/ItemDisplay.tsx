import React, { useState } from "react";
import {
  Box,
  List,
  ListItem,
  ListItemText,
  Typography,
  Collapse,
  Button,
  Input,
  Autocomplete,
  TextField,
} from "@mui/material";
import Item from "../../Common/Item";
interface Props {
  items: Item[];
  header: string;
  subHeader: string;
  newPrompt: string;
}
const ItemDisplay: React.FC<Props> = ({
  items,
  header,
  subHeader,
  newPrompt,
}) => {
  const [openScripts, setOpenScripts] = useState<{ [key: number]: boolean }>(
    {}
  );

  const toggleOpen = (scriptId: number) => {
    setOpenScripts((prev) => ({
      ...prev,
      [scriptId]: !prev[scriptId],
    }));
  };

  return (
    <Box
      className="ItemDisplay  "
      sx={{
        backgroundColor: "#00000044",
        width: "100%",
        height: "100%",
        p: 3,
        borderRadius: 2,
        boxShadow: 1,
      }}
    >
      <Box sx={{ display: "flex", justifyContent: "space-between" }}>
        <Typography variant="h5" gutterBottom>
          {header}
        </Typography>
      </Box>

      <List>
        {items.map((item) => (
          <Box
            key={item.id}
            sx={{ mb: 1, borderRadius: 1, bgcolor: "#000000", boxShadow: 1 }}
          >
            <ListItem
              onClick={() => toggleOpen(item.id)}
              sx={{
                px: 2,
                py: 1,
                display: "flex",
                justifyContent: "space-between",
                alignItems: "center",
                borderBottom: openScripts[item.id]
                  ? "1px solid #201d1d"
                  : "none",
              }}
              component="div"
            >
              <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
                {item.active ? (
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    height="24px"
                    viewBox="0 -960 960 960"
                    width="24px"
                    fill="#e3e3e3"
                  >
                    <path d="M480-80q-82 0-155-31.5t-127.5-86Q143-252 111.5-325T80-480q0-83 31.5-155.5t86-127Q252-817 325-848.5T480-880q83 0 155.5 31.5t127 86q54.5 54.5 86 127T880-480q0 82-31.5 155t-86 127.5q-54.5 54.5-127 86T480-80Zm0-82q26-36 45-75t31-83H404q12 44 31 83t45 75Zm-104-16q-18-33-31.5-68.5T322-320H204q29 50 72.5 87t99.5 55Zm208 0q56-18 99.5-55t72.5-87H638q-9 38-22.5 73.5T584-178ZM170-400h136q-3-20-4.5-39.5T300-480q0-21 1.5-40.5T306-560H170q-5 20-7.5 39.5T160-480q0 21 2.5 40.5T170-400Zm216 0h188q3-20 4.5-39.5T580-480q0-21-1.5-40.5T574-560H386q-3 20-4.5 39.5T380-480q0 21 1.5 40.5T386-400Zm268 0h136q5-20 7.5-39.5T800-480q0-21-2.5-40.5T790-560H654q3 20 4.5 39.5T660-480q0 21-1.5 40.5T654-400Zm-16-240h118q-29-50-72.5-87T584-782q18 33 31.5 68.5T638-640Zm-234 0h152q-12-44-31-83t-45-75q-26 36-45 75t-31 83Zm-200 0h118q9-38 22.5-73.5T376-782q-56 18-99.5 55T204-640Z" />
                  </svg>
                ) : (
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    height="24px"
                    viewBox="0 -960 960 960"
                    width="24px"
                    fill="#e3e3e3"
                  >
                    <path d="m456-200 174-340H510v-220L330-420h126v220Zm24 120q-83 0-156-31.5T197-197q-54-54-85.5-127T80-480q0-83 31.5-156T197-763q54-54 127-85.5T480-880q83 0 156 31.5T763-763q54 54 85.5 127T880-480q0 83-31.5 156T763-197q-54 54-127 85.5T480-80Zm0-80q134 0 227-93t93-227q0-134-93-227t-227-93q-134 0-227 93t-93 227q0 134 93 227t227 93Zm0-320Z" />
                  </svg>
                )}

                <Typography variant="h5">{item.name}</Typography>
              </Box>
              <Box
                height="100%"
                display="flex"
                justifyContent="center"
                alignItems="center"
              >
                <Typography variant="body2">{item.subItems.length}</Typography>

                {openScripts[item.id] ? (
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    height="24px"
                    viewBox="0 -960 960 960"
                    width="24px"
                    fill="#e3e3e3"
                  >
                    <path d="m280-400 200-200 200 200H280Z" />
                  </svg>
                ) : (
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    height="24px"
                    viewBox="0 -960 960 960"
                    width="24px"
                    fill="#e3e3e3"
                  >
                    <path d="M480-360 280-560h400L480-360Z" />
                  </svg>
                )}
              </Box>
            </ListItem>
            <Collapse in={openScripts[item.id]} timeout="auto" unmountOnExit>
              <List disablePadding sx={{ pl: 4, pb: 1, pr: 4 }}>
                <ListItemText>
                  <Typography>{subHeader}</Typography>
                </ListItemText>

                <ListItem
                  sx={{ display: "grid", gridTemplateColumns: "1fr auto" }}
                >
                  <Autocomplete
                    disablePortal
                    multiple
                    options={["Something", "somethingElse"]}
                    sx={{
                      width: 300,
                      color: "white",
                      backgroundColor: "gray",
                    }}
                    renderInput={(params) => (
                      <TextField
                        variant="standard"
                        {...params}
                        label={
                          <Typography variant="body1" noWrap>
                            {`Add New ${newPrompt} :`}
                          </Typography>
                        }
                      />
                    )}
                  />
                  <Input
                    startAdornment={
                      <Typography color="white" variant="body1" noWrap>
                        {`Add New ${newPrompt} :`}
                      </Typography>
                    }
                  />
                  <Button>
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      height="24px"
                      viewBox="0 -960 960 960"
                      width="24px"
                      fill="#e3e3e3"
                    >
                      <path d="M440-440H200v-80h240v-240h80v240h240v80H520v240h-80v-240Z" />
                    </svg>
                  </Button>
                </ListItem>
                {item.subItems.map((subItem) => (
                  <ListItem key={subItem.id}>
                    <ListItemText primary={subItem.name} />
                  </ListItem>
                ))}
              </List>
            </Collapse>
          </Box>
        ))}
      </List>
    </Box>
  );
};

export default ItemDisplay;

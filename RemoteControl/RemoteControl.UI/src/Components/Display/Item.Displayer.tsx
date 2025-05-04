import React, { useEffect, useState } from "react";
import { Box } from "@mui/material";
import Item from "../../Common/Item";
import ConfirmDeletion from "../../Pages/DeleteConfirmation/DeleteConfirmation";
import ItemHeader from "./Item.Displayer.ItemHeader";
import ItemList from "./Item.Displayer.ItemList/Item.Displayer.ItemList";

interface Props {
  header: string;
  subHeader: string;
  newPrompt: string;
  fetching: () => Promise<Item[]>;
}

const ItemDisplay: React.FC<Props> = ({
  header,
  subHeader,
  newPrompt,
  fetching,
}) => {
  const [items, setItems] = useState<Item[]>([]);
  const [openConfirmation, setOpenConfirmation] = useState(false);
  const [openScripts, setOpenScripts] = useState<{ [key: number]: boolean }>(
    {}
  );
  const [deleteTarget, setDeleteTarget] = useState<{
    item: Item | null;
    subitemId: number | null;
  } | null>(null);

  const toggleOpen = (scriptId: number) => {
    setOpenScripts((prev) => ({
      ...prev,
      [scriptId]: !prev[scriptId],
    }));
  };
  const loadItems = async () => {
    try {
      const data = await fetching();
      setItems(data);
    } catch (error) {
      console.error("Error fetching items:", error);
    }
  };
  useEffect(() => {
    loadItems();
  }, []);

  return (
    <Box
      className="ItemDisplay"
      sx={{
        width: "100%",
        height: "100%",
        p: 3,
        borderRadius: 2,
        boxShadow: 1,
      }}
    >
      {openConfirmation && (
        <Box
          position="fixed"
          top={0}
          left={0}
          width="100vw"
          height="100vh"
          bgcolor="rgba(0, 0, 0, 0.7)"
          zIndex={1300}
          display="flex"
          justifyContent="center"
          alignItems="center"
        >
          <ConfirmDeletion
            confirmationClosed={(deletion: boolean) => {
              setOpenConfirmation(false);
              if (deletion === true) {
                loadItems();
              }
            }}
            item={deleteTarget ? deleteTarget?.item : null}
            subitem={deleteTarget ? deleteTarget?.subitemId : null}
          />
        </Box>
      )}

      <ItemHeader title={header} />
      <ItemList
        items={items}
        openScripts={openScripts}
        toggleOpen={toggleOpen}
        subHeader={subHeader}
        newPrompt={newPrompt}
        setDeleteTarget={setDeleteTarget}
        setOpenConfirmation={setOpenConfirmation}
        reload={loadItems}
      />
    </Box>
  );
};

export default ItemDisplay;

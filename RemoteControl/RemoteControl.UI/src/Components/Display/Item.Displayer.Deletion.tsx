import React from "react";
import { Box } from "@mui/material";
import ConfirmDeletion from "../../Pages/DeleteConfirmation/DeleteConfirmation";
import Item from "../../Common/Item";

interface DeletionProps {
  openConfirmation: boolean;
  setOpenConfirmation: (value: boolean) => void;
  deleteTarget: {
    item: Item;
    subitemId: number;
  };
}

const Deletion: React.FC<DeletionProps> = ({
  openConfirmation,
  setOpenConfirmation,
  deleteTarget,
}) => {
  if (!openConfirmation) return null;

  return (
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
        confirmationClosed={() => setOpenConfirmation(false)}
        item={deleteTarget.item}
        subitem={deleteTarget.subitemId}
      />
    </Box>
  );
};

export default Deletion;

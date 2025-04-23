import React from "react";
import { Box, Button, Container, Typography, Paper } from "@mui/material";
import Item from "../../Common/Item";

interface Props {
  confirmationClosed: (deleted: boolean) => void;
  item: Item | null;
  subitem: number | null;
}

const DeleteConfirmation: React.FC<Props> = ({
  confirmationClosed: loginClosed,
  item,
  subitem,
}) => {
  async function confirmDeletion(): Promise<void> {
    if (item === null || subitem === null) {
      return;
    }
    const success = await item.removeSubItem(subitem);
    if (success) {
      loginClosed(true);
    } else {
      // Optional: handle failure case
      console.error("Failed to remove subitem");
    }
  }

  return (
    <Container maxWidth="sm">
      <Paper
        elevation={3}
        sx={{
          p: 4,
          mt: 8,
          borderRadius: 2,
          bgcolor: "#141212",
          color: "#ffffff",
          position: "relative",
        }}
      >
        {/* SVG Close Button */}
        <Button
          onClick={() => loginClosed(false)}
          sx={{
            position: "absolute",
            top: 16,
            right: 16,
            minWidth: "auto",
            padding: 1,
            borderRadius: "50%",
            "&:hover": {
              backgroundColor: "#2a2a2a",
            },
          }}
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            height="24px"
            viewBox="0 -960 960 960"
            width="24px"
            fill="#e3e3e3"
          >
            <path d="m256-200-56-56 224-224-224-224 56-56 224 224 224-224 56 56-224 224 224 224-56 56-224-224-224 224Z" />
          </svg>
        </Button>

        <Typography variant="h4" gutterBottom color="white">
          Confirm Deletion
        </Typography>

        <Typography variant="body1" color="gray" mb={3}>
          Are you sure you want to remove the mapping?
        </Typography>

        <Box
          display="flex"
          flexDirection="row"
          gap={2}
          justifyContent="space-evenly"
        >
          <Button
            onClick={confirmDeletion}
            variant="contained"
            color="error"
            sx={{
              minWidth: 100,
              borderRadius: 2,
              px: 3,
            }}
          >
            Confirm
          </Button>

          <Button
            variant="outlined"
            sx={{
              minWidth: 100,
              color: "#fff",
              borderColor: "#fff",
              borderRadius: 2,
              px: 3,
              "&:hover": {
                borderColor: "#bbb",
                backgroundColor: "#1e1e1e",
              },
            }}
            onClick={() => loginClosed(false)}
          >
            Abort
          </Button>
        </Box>
      </Paper>
    </Container>
  );
};

export default DeleteConfirmation;

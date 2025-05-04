import { Box, Typography } from "@mui/material";

const ItemHeader = ({ title }: { title: string }) => (
  <Box sx={{ pl: "16px", display: "flex", justifyContent: "space-between" }}>
    <Typography variant="h3" gutterBottom>
      {title}
    </Typography>
  </Box>
);

export default ItemHeader;

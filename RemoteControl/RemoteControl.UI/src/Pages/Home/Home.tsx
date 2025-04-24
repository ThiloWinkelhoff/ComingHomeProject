import { Box, Typography, Button } from "@mui/material";
import { Link } from "react-router-dom";
import deviceIcon from "../../assets/device.icon.svg";
import codeIcon from "../../assets/code_icon.svg";

function Home() {
  return (
    <Box p={4} sx={{ justifyContent: "center", alignItems: "center" }}>
      <Typography variant="h3" gutterBottom align="center">
        Coming Home Configuration
      </Typography>

      <Typography variant="body1" align="center">
        Welcome to the Coming Home Project dashboard. This interface allows you
        to manage connected devices and configure automation scripts that bring
        your environment to life when you arrive home.
      </Typography>

      <Typography variant="h6" pt={4} gutterBottom align="center">
        Start Your Configuration
      </Typography>

      <Typography variant="body2" align="center">
        Choose between <strong>Devices</strong> and <strong>Scripts</strong>.
        Choosing either defines your default view:
        <br />- With <strong>Devices</strong>, you can view all devices and map
        the scripts accordingly.
        <br />- With <strong>Scripts</strong>, you can manage the automation and
        view connected devices.
      </Typography>
      <Typography align="center">
        You can also manage this though the Navigation at the top of the page.
      </Typography>

      <Box
        sx={{
          display: "flex",
          flexDirection: { xs: "column", md: "row" },
          justifyContent: "space-evenly",
          alignItems: "center",
          gap: 3,
          mt: 4,
          mb: 4,
        }}
      >
        <Button
          component={Link}
          to="/configure-devices"
          variant="outlined"
          sx={{
            px: 4,
            py: 2,
            textTransform: "none",
            gap: 1.5,
            fontSize: "1.2rem",
            display: "flex",
            alignItems: "center",
            borderRadius: 2,
            "&:hover": {
              backgroundColor: "#f0f0f0",
            },
          }}
        >
          <img src={codeIcon} alt="" /> Scripts
        </Button>

        <Button
          component={Link}
          to="/configure-devices"
          variant="outlined"
          sx={{
            px: 4,
            py: 2,
            textTransform: "none",
            gap: 1.5,
            fontSize: "1.2rem",
            display: "flex",
            alignItems: "center",
            borderRadius: 2,
            "&:hover": {
              backgroundColor: "#f0f0f0",
            },
          }}
        >
          <img src={deviceIcon} alt="" /> Devices
        </Button>
      </Box>

      <Typography variant="body2" align="center">
        In the future, we plan to allow full script creation and customization
        through this portal. Currently, only pre-made scripts can be executed.
      </Typography>
    </Box>
  );
}

export default Home;

import { Box, Typography, Button } from "@mui/material";
import { Link } from "react-router-dom";

function Home() {
  return (
    <Box p={4}>
      <Typography variant="h3" gutterBottom>
        Coming Home Configuration
      </Typography>

      <Typography variant="body1" paragraph>
        Welcome to the Coming Home Project dashboard. This interface allows you
        to manage connected devices and configure automation scripts that bring
        your environment to life when you arrive home.
      </Typography>

      <Typography variant="h6" pt={4} gutterBottom>
        Start Your Configuration
      </Typography>

      <Typography variant="body2" paragraph>
        Choose between <strong>Devices</strong> and <strong>Scripts</strong>.
        Choosing either defines your default view:
        <br />- With <strong>Devices</strong>, you can view all devices and map
        the scripts accordingly.
        <br />- With <strong>Scripts</strong>, you can manage the automation and
        view connected devices.
      </Typography>
      <Typography>
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
          to="/scripts"
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
          <svg
            xmlns="http://www.w3.org/2000/svg"
            height="24px"
            viewBox="0 -960 960 960"
            width="24px"
            fill="#555"
          >
            <path d="M320-240 80-480l240-240 57 57-184 184 183 183-56 56Zm320 0-57-57 184-184-183-183 56-56 240 240-240 240Z" />
          </svg>
          Scripts
        </Button>

        <Button
          component={Link}
          to="/devices"
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
          <svg
            xmlns="http://www.w3.org/2000/svg"
            height="24px"
            viewBox="0 -960 960 960"
            width="24px"
            fill="#555"
          >
            <path d="M80-160v-120h80v-440q0-33 23.5-56.5T240-800h600v80H240v440h240v120H80Zm520 0q-17 0-28.5-11.5T560-200v-400q0-17 11.5-28.5T600-640h240q17 0 28.5 11.5T880-600v400q0 17-11.5 28.5T840-160H600Zm40-120h160v-280H640v280Zm0 0h160-160Z" />
          </svg>
          Devices
        </Button>
      </Box>

      <Typography variant="body2">
        In the future, we plan to allow full script creation and customization
        through this portal. Currently, only pre-made scripts can be executed.
      </Typography>
    </Box>
  );
}

export default Home;

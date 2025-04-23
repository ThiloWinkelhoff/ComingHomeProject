import { Box, Button, ListItemText, Typography } from "@mui/material";
import { Link, useLocation } from "react-router-dom";
import navItems from "./Navigation";
import { useState } from "react";
import Login from "../../Pages/Login/Login";

function Header() {
  const location = useLocation();
  const [loggedIn, SetloggedIn] = useState(false);
  const [showLoginPrompt, setShowLoginPrompt] = useState(false);

  return (
    <Box
      display={"flex"}
      flexDirection={"row-reverse"}
      justifyContent={"space-between"}
    >
      {showLoginPrompt && (
        <Box
          position="fixed"
          top={0}
          left={0}
          width="100vw"
          height="100vh"
          bgcolor="rgba(0, 0, 0, 0.7)"
          zIndex={1300} // above most MUI components
          display="flex"
          justifyContent="center"
          alignItems="center"
        >
          <Login
            loginSuccessful={() => SetloggedIn(true)}
            loginClosed={() => setShowLoginPrompt(false)}
          ></Login>
        </Box>
      )}
      {!loggedIn ? (
        <Button
          onClick={() => {
            setShowLoginPrompt(true);
          }}
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            height="24px"
            viewBox="0 -960 960 960"
            width="24px"
            fill="#e3e3e3"
          >
            <path d="M480-120v-80h280v-560H480v-80h280q33 0 56.5 23.5T840-760v560q0 33-23.5 56.5T760-120H480Zm-80-160-55-58 102-102H120v-80h327L345-622l55-58 200 200-200 200Z" />
          </svg>
          <Typography>Login</Typography>
        </Button>
      ) : (
        <Button
          onClick={() => {
            SetloggedIn(false);
          }}
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            height="24px"
            viewBox="0 -960 960 960"
            width="24px"
            fill="#e3e3e3"
          >
            <path d="M200-120q-33 0-56.5-23.5T120-200v-560q0-33 23.5-56.5T200-840h280v80H200v560h280v80H200Zm440-160-55-58 102-102H360v-80h327L585-622l55-58 200 200-200 200Z" />
          </svg>
          <Typography>Logout</Typography>
        </Button>
      )}

      <Box height="100%" display="flex">
        {navItems.map((item) => {
          const isSelected = location.pathname === item.path;

          return (
            <Button
              key={item.path}
              component={Link}
              to={item.path}
              sx={{
                pr: 2,
                pl: 2,
                color: "#fff",
                backgroundColor: isSelected ? "#57606f" : "transparent",
                "&:hover": {
                  backgroundColor: isSelected ? "#57606f" : "#404852",
                },
                textTransform: "none",
                height: "100%",
              }}
            >
              {item.display}
              <ListItemText
                primary={item.label}
                primaryTypographyProps={{ fontWeight: "medium" }}
              />
            </Button>
          );
        })}
      </Box>
    </Box>
  );
}

export default Header;

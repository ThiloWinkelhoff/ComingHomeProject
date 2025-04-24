import { Box, Button, ListItemText, Typography } from "@mui/material";
import { Link, useLocation } from "react-router-dom";
import navItems from "./Navigation";
import { useState } from "react";
import Login from "../../Pages/Login/Login";
import loginIcon from "../../assets/login_icon.svg";
import logoutIcon from "../../assets/logout_icon.svg";
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
          <img src={loginIcon} alt="" />
          <Typography>Login</Typography>
        </Button>
      ) : (
        <Button
          onClick={() => {
            SetloggedIn(false);
          }}
        >
          <img src={logoutIcon} alt="" />
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

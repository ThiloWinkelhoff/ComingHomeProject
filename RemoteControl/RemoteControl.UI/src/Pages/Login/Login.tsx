import React, { useState } from "react";
import {
  Box,
  Button,
  Container,
  TextField,
  Typography,
  Paper,
} from "@mui/material";
import loginUser from "../../api/loginUser";

interface Props {
  loginSuccessful: () => void;
  loginClosed: () => void;
}

const Login: React.FC<Props> = ({ loginSuccessful, loginClosed }) => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState<string | null>(null);

  const handleLogin = async () => {
    try {
      const result = await loginUser({ username, password });
      localStorage.setItem("token", result.token);
      setError(null);
      loginSuccessful();
      loginClosed();
    } catch {
      setError("Invalid username or password.");
    }
  };

  return (
    <Container maxWidth="sm">
      <Paper
        elevation={3}
        sx={{
          padding: 4,
          marginTop: 8,
          borderRadius: 2,
          backgroundColor: "#141212",
          color: "#ffffff",
          position: "relative",
        }}
      >
        <Button
          onClick={() => loginClosed()}
          sx={{
            position: "absolute",
            top: "16px", // Distance from the top
            right: "16px", // Distance from the right
            cursor: "pointer", // Optional: to indicate it's clickable
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
          Login
        </Typography>
        <Box display="flex" flexDirection="column" gap={2}>
          <TextField
            label="Username"
            variant="outlined"
            fullWidth
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            InputLabelProps={{ style: { color: "#ffffff" } }}
            InputProps={{ style: { color: "#ffffff" } }}
            sx={{
              "& .MuiOutlinedInput-root": {
                "& fieldset": { borderColor: "#ffffff" },
                "&:hover fieldset": { borderColor: "#90caf9" },
                "&.Mui-focused fieldset": { borderColor: "#90caf9" },
              },
            }}
          />
          <TextField
            label="Password"
            type="password"
            variant="outlined"
            fullWidth
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            InputLabelProps={{ style: { color: "#ffffff" } }}
            InputProps={{ style: { color: "#ffffff" } }}
            sx={{
              "& .MuiOutlinedInput-root": {
                "& fieldset": { borderColor: "#ffffff" },
                "&:hover fieldset": { borderColor: "#90caf9" },
                "&.Mui-focused fieldset": { borderColor: "#90caf9" },
              },
            }}
          />
          {error && <Typography color="error">{error}</Typography>}
          <Button
            variant="contained"
            sx={{
              backgroundColor: "#1976d2",
              "&:hover": { backgroundColor: "#1565c0" },
              color: "#ffffff",
            }}
            onClick={handleLogin}
          >
            <Typography color="inherit">Login</Typography>
          </Button>
        </Box>
      </Paper>
    </Container>
  );
};

export default Login;

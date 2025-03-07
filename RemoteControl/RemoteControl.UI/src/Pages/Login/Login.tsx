import { useNavigate } from "react-router-dom";

function Login() {
  const navigate = useNavigate(); // Hook for navigation

  function executeLogin(): void {
    // Perform login logic here (optional)

    // Redirect to Home
    navigate("/home");
  }

  return (
    <>
      <div
        className="HomeContainer"
        style={{
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
          alignItems: "center",
          height: "100%",
          width: "100%",
        }}
      >
        <h1>Login</h1>
        <h4>Username</h4>
        <input></input>
        <h4>Password</h4>
        <input></input>
        <button onClick={executeLogin}>Login</button>
      </div>
    </>
  );
}

export default Login;

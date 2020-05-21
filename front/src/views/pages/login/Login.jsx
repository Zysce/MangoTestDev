import React, { useState } from "react";
import useApiController from "../../../controllers/apiController";
import "./login.scss";

const Login = ({ updateToken }) => {
  const [login, setLogin] = useState();
  const [password, setPassword] = useState();

  const [error, setError] = useState();

  const { post } = useApiController();

  const handleSubmit = async (event) => {
    event.preventDefault();
    setError(null);
    try {
      const response = await post("authentication/login", {
        username: login,
        password,
      });
      updateToken(response?.data?.value?.accessToken);
    } catch (err) {
      setError("Username/password incorrects");
    }
  };

  return (
    <div className="content">
      <div className="title">Login</div>
      <div>{error}</div>
      <form onSubmit={handleSubmit}>
        <div className="login">
          <label htmlFor="login">Login</label>
          <input
            id="login"
            type="text"
            name="login"
            onChange={(e) => setLogin(e.target.value)}
          />
        </div>
        <div className="password">
          <label htmlFor="password">Password</label>
          <input
            id="password"
            type="password"
            name="password"
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <button className="login-button" type="submit">
          Login
        </button>
      </form>
    </div>
  );
};

export default Login;

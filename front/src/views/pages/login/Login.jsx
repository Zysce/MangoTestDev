import React from "react";
import useLoginController from "../../../controllers/loginController";
import "./login.scss";

const Login = ({ updateToken }) => {
  const { setLogin, setPassword, handleSubmit, error } = useLoginController({
    updateToken,
  });

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

import React, { useEffect } from "react";
import "./App.scss";
import useAuthenticationController from "./controllers/authenticationController";
import Login from "./views/pages/login/Login";
import AuthenticatedRoutes from "./views/pages/AuthenticatedRoutes";
import { Route, BrowserRouter as Router } from "react-router-dom";

const App = () => {
  const {
    loggedIn,
    setLoggedIn,
    token,
    updateToken,
  } = useAuthenticationController();

  useEffect(() => {
    setLoggedIn(!!token);
  }, [setLoggedIn, token]);

  return (
    <Router>
      {loggedIn ? (
        <AuthenticatedRoutes />
      ) : (
        <Route render={() => <Login updateToken={updateToken} />} />
      )}
    </Router>
  );
};

export default App;

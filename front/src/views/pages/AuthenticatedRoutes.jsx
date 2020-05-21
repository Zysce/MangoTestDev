import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Home from "./home/Home";
import NewItem from "./newItem/NewItem";

const AuthenticatedRoutes = () => {
  return (
    <Switch>
      <Route exact key={"/home"} path={"/"} render={() => <Home />} />
      <Route
        exact
        key={"/newItem"}
        path={"/newItem"}
        render={() => <NewItem />}
      />
      <Redirect to={"/"} />
    </Switch>
  );
};

export default AuthenticatedRoutes;

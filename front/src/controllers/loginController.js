import { useState } from "react";
import useApiController from "./apiController";

const useLoginController = ({ updateToken }) => {
  const { post } = useApiController();

  const [login, setLogin] = useState();
  const [password, setPassword] = useState();

  const [error, setError] = useState();

  const loginUser = async (login, password) => {
    const response = await post("authentication/login", {
      username: login,
      password,
    });
    updateToken(response?.data?.value?.accessToken);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    setError(null);
    try {
      loginUser(login, password);
    } catch (err) {
      setError("Username/password incorrects");
    }
  };

  return {
    setLogin,
    setPassword,
    handleSubmit,
    error,
  };
};

export default useLoginController;

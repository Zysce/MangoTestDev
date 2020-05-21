import { useState } from 'react';

const useAuthenticationController = () => {
  const [token, updateToken] = useState(window.localStorage.getItem('tkn'));

  const [loggedIn, setLoggedIn] = useState(!!token);

  
  const wrapperUpdateToken = (tkn) => {
    window.localStorage.setItem('tkn', tkn);
    updateToken(tkn);
  };
  return {
    loggedIn,
    setLoggedIn,
    token,
    updateToken: wrapperUpdateToken
  };
};

export default useAuthenticationController;
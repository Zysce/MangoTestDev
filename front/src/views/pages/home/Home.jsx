import React, { useState, useEffect } from "react";
import useApiController from "../../../controllers/apiController";

const Home = () => {
  const [items, setItems] = useState([]);

  const { get } = useApiController();

  try {
  } catch (err) {
    console.error(err);
  }

  return <div>Home</div>;
};

export default Home;

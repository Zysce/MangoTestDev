import { useState, useEffect } from "react";
import useApiController from "./apiController";
import { useHistory } from "react-router-dom";

const useItemListController = () => {
  const [items, setItems] = useState([]);

  const { get } = useApiController();

  let history = useHistory();

  const addNew = () => {
    history.push("/newItem");
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await get("item");
        setItems(response?.data || []);
      } catch (error) {
        console.error(error);
      }
    };
    fetchData();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return {
    items,
    addNew,
  };
};

export default useItemListController;

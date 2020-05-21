import { useState } from "react";
import useApiController from "./apiController";
import { useHistory } from "react-router-dom";

const useItemListController = () => {
  const [title, setTitle] = useState();
  const [description, setDescription] = useState();
  const [image, setImage] = useState();

  const { post } = useApiController();

  let history = useHistory();

  const cancel = () => {
    history.push("/");
  };

  const submit = async (e) => {
    e.preventDefault();
    const item = {
      title,
      description,
      image,
    };
    try {
      await post("item", item);
      cancel();
    } catch (error) {
      console.error(error);
    }
  };

  const getFile = (e) => {
    var reader = new FileReader();
    reader.readAsDataURL(e.target.files[0]);
    reader.onload = function (ev) {
      setImage(ev.target.result);
    };
  };

  return {
    cancel,
    submit,
    setTitle,
    setDescription,
    getFile,
  };
};

export default useItemListController;

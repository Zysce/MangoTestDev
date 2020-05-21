import React from "react";
import useItemController from "../../../controllers/itemController";
import "./newItem.scss";

const NewItem = () => {
  const {
    cancel,
    submit,
    setTitle,
    setDescription,
    getFile,
  } = useItemController();

  return (
    <div className="content">
      <div className="title">Add new item</div>
      <form onSubmit={submit}>
        <div className="title-field">
          <label htmlFor="title">Title</label>
          <input
            id="title"
            type="text"
            name="title"
            onChange={(e) => setTitle(e.target.value)}
          />
        </div>
        <div className="description">
          <label htmlFor="description">Description</label>
          <input
            id="description"
            type="text"
            name="description"
            onChange={(e) => setDescription(e.target.value)}
          />
        </div>
        <div className="image">
          <label for="image"> Select an image (jpg only)</label>
          <input
            type="file"
            name="image"
            id="image"
            accept=".jpg,.jpeg"
            onChange={getFile}
          />
        </div>
        <div className="actions">
          <button className="add-button" onClick={cancel}>
            Cancel
          </button>
          <button className="add-button" type="submit">
            Add
          </button>
        </div>
      </form>
    </div>
  );
};

export default NewItem;

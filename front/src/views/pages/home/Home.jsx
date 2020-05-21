import React from "react";
import useItemListController from "../../../controllers/itemListController";
import "./home.scss";

const Home = () => {
  const { items, addNew } = useItemListController();

  return (
    <div className="content">
      <div className="header">
        <div className="title">Items</div>
        <button onClick={addNew}>Add</button>
      </div>
      <div className="list">
        {items.map((item) => (
          <ul>
            <li>{item.title}</li>
            <li>{item.description}</li>
            <li>
              <img
                className="img"
                src={"data:image/jpg;base64," + item.image}
                alt={item.title}
              />
            </li>
          </ul>
        ))}
      </div>
    </div>
  );
};

export default Home;

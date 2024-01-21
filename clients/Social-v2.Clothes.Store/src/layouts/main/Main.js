import React from "react";
import { Outlet } from "react-router-dom";
import NavBar from "./Navbar";
import ClothesFooter from "./Footer";

const Main = () => {
  return (
    <>
      <NavBar />
      <Outlet />
      <div className="p-8" />
      <ClothesFooter />
    </>
  );
};

export default Main;

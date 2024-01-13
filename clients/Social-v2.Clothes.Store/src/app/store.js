import { configureStore } from "@reduxjs/toolkit";
import userReducer from "../slices/userSlice";
import cartSlice from "../slices/cartSlice";

const store = configureStore({
  reducer: {
    user: userReducer,
    cart: cartSlice
  },
});

export default store;


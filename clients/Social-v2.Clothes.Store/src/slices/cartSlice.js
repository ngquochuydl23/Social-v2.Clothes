import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    cart: null,
    isLoading: true,
    isError: false,
    error: "",
  };

const cartSlice = createSlice({
    name: "cart",
    initialState,
    reducers: {
        setCart: (state, action) => {
            state.cart = action.payload;
        },
        clear: (state) => {
            state.cart = null;
        },
    },
});

export const { setCart, clear, addCartItem } = cartSlice.actions;
export default cartSlice.reducer;

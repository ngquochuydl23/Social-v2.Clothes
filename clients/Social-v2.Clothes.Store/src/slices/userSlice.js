import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    user: null,
    isLoading: true,
    isError: false,
    error: "",
  };

const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        setUser: (state, action) => {
            state.user = action.payload;
        },
        stopLoading: (state) => {
            state.isLoading = false;
        },
        logout: (state) => {
            state.user = null;
            localStorage.removeItem("accessToken");
        },
    },
    // extraReducers: (builder) => {
    //     builder.addCase(fetchUser.pending, (state) => {
    //         state.isLoading = true;
    //     });
    //     builder.addCase(fetchUser.fulfilled, (state, action) => {
    //         state.isLoading = false;
    //         state.user = action.payload;
    //     });
    //     builder.addCase(fetchUser.rejected, (state, action) => {
    //         state.isLoading = false;
    //         state.isError = true;
    //         state.error = action.payload;
    //     });
    // },
});

export const { setUser, stopLoading, logout } = userSlice.actions;
export default userSlice.reducer;

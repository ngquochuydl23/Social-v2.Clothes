import React, { useEffect } from "react";
import { RouterProvider } from "react-router-dom";
import routes from "./routes/routes";
import { Toaster } from "react-hot-toast";
import { useDispatch } from "react-redux";
import FullScreenLoading from "./components/loading/FullScreenLoading";
import { persistLogin } from "./services/api/user-api";
import { setUser } from "./slices/userSlice";
import { getMyCart } from "./services/api/cart-api";
import { setCart } from "./slices/cartSlice";

function App() {
    const dispatch = useDispatch();
    const isLoading = false

    useEffect(() => {
        const token = localStorage.getItem("accessToken");
        if (token?.length) {
            persistLogin()
                .then((user) => {

                    dispatch(setUser(user));
                    getMyCart()
                        .then((res) => {
                            console.log(res);
                            dispatch(setCart(res));
                        })
                        .catch((err) => { throw err });
                })
                .catch((err) => console.log(err));


        }
    }, [dispatch]);

    return isLoading ? (
        <FullScreenLoading />
    ) : (
        <>
            <RouterProvider router={routes} />
            <Toaster position="top-center" reverseOrder={true} />
        </>
    );
}

export default App;

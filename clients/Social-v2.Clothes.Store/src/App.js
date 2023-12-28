import React, { useEffect } from "react";
import { RouterProvider } from "react-router-dom";
import routes from "./routes/routes";
import { Toaster } from "react-hot-toast";
import { useDispatch } from "react-redux";
import FullScreenLoading from "./components/loading/FullScreenLoading";
import { persistLogin } from "./services/api/user-api";
import { setUser } from "./slices/userSlice";

function App() {
    const dispatch = useDispatch();
    const isLoading = false

    useEffect(() => {
        console.log("Fetch user api");
        const token = localStorage.getItem("accessToken");
        if (token?.length) {
            persistLogin()
                .then((user) => dispatch(setUser(user)))
                .catch((err) => console.log(err))
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

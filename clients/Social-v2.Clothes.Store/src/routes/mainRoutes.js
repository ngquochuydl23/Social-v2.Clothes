import { lazy } from "react";
import SplitRouter from "./SplitRouter";
import Main from "../layouts/main/Main";
import AccountLayout from '../layouts/account';
// import NotFound from "../pages/NotFound";
import Signin from "../pages/main/Signin";
import Signup from "../pages/main/Signup";
import ForgotPassword from "../pages/main/ForgotPassword";
import Contact from "../pages/main/Contact";
import About from "../pages/main/About";
import ProductDescription from "../pages/main/ProductDescription";
import Profile from "../pages/main/Profile";
import Order from "../pages/main/Order";
import ComingSoon from "../components/main/ComingSoon";
import ShippingAddress from "../pages/main/ShippingAddress";
import Wishlist from "../pages/main/Wishlist";
import MyVoucher from "../pages/main/MyVoucher";
const Home = lazy(() => import("../pages/main/Home"));

const mainRoutes = {
  path: "/",
  element: <Main />,
  children: [
    {
      path: "/",
      element: (
        <SplitRouter>
          <Home />
        </SplitRouter>
      ),
    },
    {
      path: "/sign-in",
      element: (
        <SplitRouter>
          <Signin />
        </SplitRouter>
      ),
    },
    {
      path: "/sign-up",
      element: (
        <SplitRouter>
          <Signup />
        </SplitRouter>
      ),
    },
    {
      path: "/forgot-password",
      element: (
        <SplitRouter>
          <ForgotPassword />
        </SplitRouter>
      ),
    },
    {
      path: "/contact-us",
      element: (
        <SplitRouter>
          <Contact />
        </SplitRouter>
      ),
    },
    {
      path: "/about-us",
      element: (
        <SplitRouter>
          <About />
        </SplitRouter>
      ),
    },
    {
      path: "/account",
      element: <AccountLayout />,
      children: [
        {
          path: "info",
          element: (
            <SplitRouter>
              <Profile />
            </SplitRouter>
          ),
        },
        {
          path: "shipping-address",
          element: (
            <SplitRouter>
              <ShippingAddress />
            </SplitRouter>
          ),
        },
        {
          path: "my-order",
          element: (
            <SplitRouter>
              <Order />
            </SplitRouter>
          ),
        },
        {
          path: "wishlist",
          element: (
            <SplitRouter>
              <Wishlist />
            </SplitRouter>
          ),
        },
        {
          path: "my-vouchers",
          element: (
            <SplitRouter>
              <MyVoucher />
            </SplitRouter>
          ),
        },
      ]
    },
    {
      path: "/product/:title",
      element: (
        <SplitRouter>
          <ProductDescription />
        </SplitRouter>
      ),
    },
    {
      path: "/*",
      element: (
        <SplitRouter>
          {/* <NotFound /> */}
          <ComingSoon />
        </SplitRouter>
      ),
    },
  ],
};

export default mainRoutes;

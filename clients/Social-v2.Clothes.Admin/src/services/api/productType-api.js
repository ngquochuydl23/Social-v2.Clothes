import { http } from "../https";

export const getProductTypes = () => http.get("/ProductType");

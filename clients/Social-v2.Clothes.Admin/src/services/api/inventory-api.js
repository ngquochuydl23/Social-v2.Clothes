import { http } from "../https";

export const getInventories = ({  }) =>
  http.get("/Inventory", {
    params: {

    },
  });

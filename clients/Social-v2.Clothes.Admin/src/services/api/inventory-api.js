import { http } from "../https";

export const getInventories = ({  }) =>
  http.get("/admin/Inventory", {
    params: {

    },
  });


import { http } from "../https";

export const getCategories = ({ hierarchy, forGender }) =>
  http.get("/Category", {
    params: {
      isActive: true,
      hierarchy,
      forGender,
    },
  });

export const addCategories = (body) => http.post("/Category", body);

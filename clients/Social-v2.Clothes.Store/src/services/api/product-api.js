import { http } from '../https'

export const getProductDetail = (id) => http.get('/store/Product/' + id);

export const getProductVarient = (id) => http.get("/store/Product/" + id + "/varient");

export const getNewArrivals = () => http.get("/store/Product/newArrivals")


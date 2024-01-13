import { http } from '../https'

export const getProductDetail = (id) => http.get('store/Product/' + id);

export const getProductVarientByQueries = (id, body) => http.get("/store/Product/" + id + "/varient/withParams");

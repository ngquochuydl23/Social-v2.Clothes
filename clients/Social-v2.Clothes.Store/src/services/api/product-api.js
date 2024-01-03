import { http } from '../https'

export const getProductDetail = (id) => http.get('/Product/' + id);

export const getProductVarientByQueries = (id, body) => http.get("/Product/" + id + "/varient/withParams");

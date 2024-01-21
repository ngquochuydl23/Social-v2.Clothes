import { http } from '../https'

export const addProduct = (body) => http.post('/Admin/Product', body);

export const getProducts = () => http.get('/Admin/Product');

export const getProduct = (productId) => http.get('/Admin/Product/' + productId);

export const deleteProduct = (productId) => http.delete('/Admin/Product/' + productId);

export const getProductVarients = (productId) =>  http.get('/Admin/Product/' + productId + "/varients");
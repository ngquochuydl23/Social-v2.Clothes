import { http } from '../https'

export const addProduct = (body) => http.post('/Product', body);

export const getProducts = () => http.get('/Product');

export const getProduct = (productId) => http.get('/Product/' + productId);

export const deleteProduct = (productId) => http.delete('/Product/' + productId);

export const getProductVarients = (productId) =>  http.get('/Product/' + productId + "/varients");
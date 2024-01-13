import { http } from '../https'

export const getShippingAddresses = () =>
  http.get('/store/DeliveryAddress');

export const deleteShippingAddress = (addressId) =>
  http.delete('/store/DeliveryAddress/' + addressId);


export const addShippingAddress = (body) =>
  http.post('/store/DeliveryAddress/', body);
import { http } from '../https'

export const getShippingAddresses = () =>
  http.get('/DeliveryAddress');

export const deleteShippingAddress = (addressId) =>
  http.delete('/DeliveryAddress/' + addressId);


export const addShippingAddress = (body) =>
  http.post('/DeliveryAddress/', body);
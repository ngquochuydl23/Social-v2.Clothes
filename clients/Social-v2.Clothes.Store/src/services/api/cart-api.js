import { http } from '../https'

export const getMyCart = (cartId) => http.get('store/Cart/MyCart');
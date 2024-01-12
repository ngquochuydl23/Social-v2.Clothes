import { http } from '../https'

export const getOrders = () => http.get('/Order');
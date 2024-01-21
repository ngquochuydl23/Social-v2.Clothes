import { http } from '../https'

export const getOrders = () => http.get('/Admin/Order');
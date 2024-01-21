import { http } from '../https'

export const getCustomers = () => http.get('/admin/Customer');
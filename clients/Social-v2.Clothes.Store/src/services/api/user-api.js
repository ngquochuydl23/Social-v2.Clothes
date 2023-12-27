import { http } from '../https'

export const signIn = (phoneNumber, password) =>
  http.post('/User/login', { phoneNumber, password })


export const persistLogin = () =>
  http.get('/User/persistLogin');
import { http } from '../https'

export const getWishlist = () =>
    http.get('/Wishlist')
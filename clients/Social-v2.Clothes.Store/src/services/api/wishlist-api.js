import { http } from '../https'

export const getWishlist = () =>
    http.get('/store/Wishlist')
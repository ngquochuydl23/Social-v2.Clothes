import React, { useEffect } from "react";
import { Box, Button, CircularProgress, Link, Stack, Typography } from "@mui/material";
import { format } from "number-currency-format";
import LazyLoadingImage from "../../components/LazyLoadingImage";
import { useState } from "react";
import { getWishlist } from "../../services/api/wishlist-api";

const Wishlist = () => {

    const [loading, setLoading] = useState(false);
    const [wishlist, setWishlist] = useState([]);

    useEffect(() => {
        setLoading(true);
        getWishlist()
            .then((res) => setWishlist(res))
            .catch((err) => console.log(err))
            .finally(() => setLoading(false));
    }, [])

    const WishlistItem = ({ id, productVarient }) => {
        return (
            <Link
                sx={{ textDecoration: 'none' }}
                href="/product">
                <div
                    key={id}
                    className="flex py-5 last:pb-0">
                    <div className="relative h-[120px] w-[120px] flex-shrink-0 overflow-hidden rounded-xl bg-slate-100">
                        <LazyLoadingImage
                            src={productVarient?.product?.thumbnail}
                            alt={productVarient?.product?.thumbnail}
                            height={"100%"}
                            width="100%"
                            className={"object-contain object-center h-[120px] w-[120px] object-cover"}
                        />
                    </div>
                    <div className="ml-4 flex flex-1 flex-col">
                        <Stack ml="10px">
                            <Box>
                                <Typography
                                    fontWeight="600"
                                    fontSize="16px"
                                    variant="subtitle1">
                                    {productVarient?.product?.title}
                                </Typography>
                                <Typography
                                    fontSize="14px"
                                    fontWeight="500"
                                    color="#696969"
                                    variant="subtitle2">
                                    {productVarient?.title}
                                </Typography>
                            </Box>
                            <Stack
                                mt="16px"
                                alignItems="center"
                                justifyContent="space-between"
                                direction="row">
                                <Typography
                                    fontWeight="600"
                                    fontSize="20px"
                                    variant="subtitle2">
                                    {format(productVarient.price, { currency: 'đ', thumbnail: ',' })}
                                </Typography>
                            </Stack>
                        </Stack>
                    </div>
                    <Button
                        // onClick={() => setOpenAlert(true)}
                        sx={{ color: 'red' }}>
                        Xóa
                    </Button>
                </div>
            </Link>
        )
    }

    return (
        <Box mt="56px" sx={{ width: '100%' }}>
            <Typography
                mb="20px"
                fontWeight="800"
                variant="h4">Yêu Thích</Typography>
            {loading
                ?
                <Stack
                    justifyContent="center"
                    alignItems="center"
                    sx={{
                        width: '100%',
                        height: '100%'
                    }}>
                    <CircularProgress color="secondary" sx={{ color: 'black' }} />
                </Stack>
                : wishlist.map((wishlistItem) => (
                    <WishlistItem {...wishlistItem} />
                ))
            }
        </Box>
    );
};

export default Wishlist;

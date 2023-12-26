import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import { useSelector } from "react-redux";
import { useUpdatePhotoMutation } from "../../features/update/updateApi";
import { useUpdateUserMutation } from "../../features/auth/authApi";
import LazyLoadingImage from "../../components/LazyLoadingImage";
import { Box, Button, Container, Divider, FormControlLabel, Grid, MenuItem, Stack, Switch, TextField, Typography } from '@mui/material';

const addresses = [
    {
        "id": 1,
        "name": "Vũ Hoàng Uyên Nhi",
        "phoneNumber": "0868684962",
        "detailAddress": "59 Xô Viết Nghệ Tĩnh",
        "provinceOrCity": "Tỉnh Lâm Đồng",
        "district": "Phường 7",
        "wardOrCommune": "Thành phố Đà Lạt",
        "isDefault": true
    },
    {
        "id": 2,
        "name": "Vũ Hoàng Uyên Nhi",
        "phoneNumber": "0868684962",
        "detailAddress": "Số 1 Nguyễn Thị Minh Khai",
        "provinceOrCity": "TP Hồ Chí Minh",
        "district": "Phường Bến Nghé",
        "wardOrCommune": "Quận 1",
        "isDefault": false
    }
]

const ShippingAddress = () => {
    const AddressItem = ({
        name,
        district,
        isDefault,
        detailAddress,
        phoneNumber,
        provinceOrCity,
        wardOrCommune
    }) => {
        return (
            <Box py="15px" sx={{ width: '100%' }}>
                <Stack
                    direction="row"
                    justifyContent="space-between">
                    <Box>
                        <Stack direction="row">
                            <Typography variant="subtitle1">{name}</Typography>
                            {isDefault &&
                                <Box ml="15px">
                                    Default
                                </Box>
                            }
                        </Stack>
                        <Typography
                            mt="10px"
                            variant="subtitle1">{phoneNumber}</Typography>
                        <Typography variant="subtitle1">{detailAddress}, {district}, {wardOrCommune}, {provinceOrCity}</Typography>
                    </Box>
                    <Stack direction="row">
                        <Button>Edit</Button>
                        <Button>Delete</Button>
                    </Stack>
                </Stack>
                <Divider sx={{ mt: '10px' }} />
            </Box>
        )
    }

    return (
        <Box mt="56px" sx={{ width: '100%' }}>
            <Stack direction="row" justifyContent="space-between">
                <Typography mb="20px" variant="h4">{`Shipping Addresses`}</Typography>
                <Button>
                    Add new address
                </Button>
            </Stack>
            {addresses.map((address) => (
                <AddressItem {...address} />
            ))}
        </Box>
    );
};

export default ShippingAddress;

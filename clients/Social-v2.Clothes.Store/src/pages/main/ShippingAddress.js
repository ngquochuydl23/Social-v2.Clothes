import React, { useEffect, useState } from "react";
import { Box, Button, Divider, Stack, Typography } from '@mui/material';
import AlertDialog from "../../components/alert-dialog";
import CreateUpdateShippingAddressDialog from "../../components/shipping-address/createUpdateShippingAddressDialog";
import { getShippingAddresses, deleteShippingAddress, addShippingAddress } from "../../services/api/shipping-address-api";
import CircularProgress from '@mui/material/CircularProgress';
import Backdrop from '@mui/material/Backdrop';

const ShippingAddress = () => {
    const [openCreateUpdateDialog, setOpenCreateUpdateDialog] = useState({
        open: false,
        address: null
    });
    const [loading, setLoading] = useState(false);
    const [addresses, setAddresses] = useState([]);
    const [openBackdrop, setOpenBackdrop] = useState(false);

    useEffect(() => {
        setLoading(true);
        getShippingAddresses()
            .then((addresses) => {
                setAddresses(addresses);
            })
            .catch((err) => console.log(err))
            .finally(() => setLoading(false));
    }, [])

    const AddressItem = ({
        id,
        name,
        district,
        isDefault,
        detailAddress,
        phoneNumber,
        provinceOrCity,
        wardOrCommune,
        onRemovedAddress,
        onEditAddress
    }) => {
        const [openAlert, setOpenAlert] = useState(false);
        return (
            <Box
                py="15px" sx={{ width: '100%' }}>
                <Stack
                    direction="row"
                    justifyContent="space-between">
                    <Box>
                        <Stack direction="row">
                            <Typography
                                sx={{
                                    fontSize: '16px',
                                    fontWeight: '600'
                                }}
                                variant="subtitle1">
                                {name}
                            </Typography>
                            {isDefault &&
                                <Box
                                    display="flex"
                                    px="10px"
                                    justifyContent="center"
                                    alignItems="center"
                                    sx={{
                                        fontSize: '12px',

                                        bgcolor: 'black',
                                        borderRadius: '200px',
                                        color: 'white'
                                    }}
                                    ml="15px">
                                    Mặc định
                                </Box>
                            }
                        </Stack>
                        <Typography
                            mt="10px"
                            variant="subtitle1">{phoneNumber}</Typography>
                        <Typography variant="subtitle1">{detailAddress}, {district}, {wardOrCommune}, {provinceOrCity}</Typography>
                    </Box>
                    <Stack direction="row">
                        <Button onClick={() => onEditAddress({
                            id,
                            name,
                            district,
                            isDefault,
                            detailAddress,
                            phoneNumber,
                            provinceOrCity,
                            wardOrCommune
                        })}>
                            Sửa
                        </Button>
                        <Button
                            onClick={() => setOpenAlert(true)}
                            sx={{ color: 'red' }}>
                            Xóa
                        </Button>
                    </Stack>
                </Stack>
                <Divider sx={{ mt: '10px' }} />
                <AlertDialog
                    open={openAlert}
                    handleClose={() => setOpenAlert(false)}
                    onLeftClick={() => setOpenAlert(false)}
                    onRightClick={() => onRemovedAddress(id)}
                    title={`Remove shipping address`}
                    rightTxt={'Ok'}
                    leftTxt={`Cancel`}
                    sxRightBtn={{ color: 'red' }}
                    content={`Are you sure to delete this address ?. This will be permanently removed.`}
                />
            </Box>
        )
    }

    return (
        <Box mt="56px" sx={{ width: '100%' }}>
            <Stack direction="row" justifyContent="space-between">
                <Typography
                    mb="20px"
                    fontWeight="800"
                    variant="h4">Địa chỉ giao hàng</Typography>
                <Button
                    onClick={() => setOpenCreateUpdateDialog({ address: null, open: true })}
                    sx={{ height: '40px' }}
                    variant="contained">
                    Thêm địa chỉ
                </Button>
            </Stack>
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
                : addresses.map((address) => (
                    <AddressItem
                        onEditAddress={(address) => {
                            setOpenCreateUpdateDialog({
                                open: true,
                                address: address
                            })
                        }}
                        onRemovedAddress={(id) => {
                            setOpenBackdrop(true);
                            deleteShippingAddress(id)
                                .then(() => setAddresses(addresses.filter(address => address.id !== id)))
                                .catch((err) => console.log(err))
                                .finally(() => setOpenBackdrop(false))
                        }}
                        {...address} />
                ))
            }
            <CreateUpdateShippingAddressDialog
                onCreated={(newAddress) => {

                    setOpenBackdrop(true)
                    addShippingAddress({ ...newAddress })
                        .then((item) => setAddresses([...addresses, item]))
                        .catch((err) => console.log(err))
                        .finally(() => setOpenBackdrop(false))
                }}
                onUpdated={(newAddress) => {
                    console.log(newAddress);
                    //addShippingAddress()
                }}
                address={openCreateUpdateDialog.address}
                open={openCreateUpdateDialog.open}
                handleClose={() => setOpenCreateUpdateDialog({ open: false, address: null })} />
            <Backdrop
                sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
                open={openBackdrop}
                onClick={() => setOpenBackdrop(false)}>
                <CircularProgress color="inherit" />
            </Backdrop>
        </Box>
    );
};

export default ShippingAddress;

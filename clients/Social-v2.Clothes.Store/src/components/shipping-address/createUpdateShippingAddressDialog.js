import * as React from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import { useFormik } from 'formik';
import { Grid, MenuItem, Select, Stack, TextField, Typography } from '@mui/material';
import tree from 'hanhchinhvn/dist/tree.json'
import tinh_tp from 'hanhchinhvn/dist/tinh_tp.json'
import * as Yup from 'yup';
import { useState } from 'react';

export default function CreateUpdateShippingAddressDialog({
    open, handleClose, onCreated, onUpdated, address
}) {
    const [districts, setDistricts] = useState([]);
    const [wardOrCommunes, setWardOrCommunes] = useState([]);

    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            id: undefined,
            name: '',
            district: null,
            isDefault: false,
            detailAddress: '',
            phoneNumber: '',
            provinceOrCity: null,
            wardOrCommune: null,
        },
        validationSchema: Yup.object().shape({
            name: Yup.string()
                .required('Vui lòng nhập họ tên'),
            phoneNumber: Yup.string()
                .required('Vui lòng nhập số điện thoại'),
            detailAddress: Yup.string()
                .required('Vui lòng nhập địa chỉ chi tiết'),
            district: Yup.string()
                .required('Vui lòng chọn Quận/huyện'),
            provinceOrCity: Yup.string()
                .required('Vui lòng chọn Tỉnh/thành phố'),
            wardOrCommune: Yup.string()
                .required('Vui lòng chọn Xã/phường'),
        }),
        onSubmit: values => {
            if (Boolean(address)) {
                onUpdated(values);
            } else {
                onCreated(values);
            }
            formik.resetForm();
            handleClose();
        },
    });

    const getProvinceOrCity = (provinceCityName) => {
        return Object
            .values(tree)
            .find(x => x.name === provinceCityName);
    }

    const getDistrictsFromProvinceOrCity = (provinceCityName) => {
        return Object.values(getProvinceOrCity(provinceCityName)["quan-huyen"]);
    }

    const getWardOrCommunesByDistrict = (districtName) => {
        return Object.values(districts.find(x => x.name === districtName)['xa-phuong']);
    }

    React.useEffect(() => {
        if (open && Boolean(address)) {
            formik.setValues(address)
            setDistricts(getDistrictsFromProvinceOrCity(address.provinceOrCity));
        }
    }, [open])

    React.useEffect(() => {
        if (open && Boolean(districts)) {
            setWardOrCommunes(getWardOrCommunesByDistrict(address.district))
        }
    }, [districts])

    return (
        <Dialog
            maxWidth='lg'
            open={open}
            onClose={handleClose}
            aria-labelledby="alert-dialog-title"
            aria-describedby="alert-dialog-description">
            <form onSubmit={formik.handleSubmit}>
                <DialogTitle id="alert-dialog-title">
                    <Typography
                        fontSize="18px"
                        variant='h5'
                        mb="10px"
                        mt='10px'
                        fontWeight="600">
                        {!Boolean(address)
                            ? 'Thêm địa chỉ giao hàng'
                            : 'Cập nhật địa chỉ giao hàng'
                        }
                    </Typography>
                </DialogTitle>
                <DialogContent sx={{ width: '500px' }}>
                    <TextField
                        sx={{ mt: '5px' }}
                        fullWidth
                        onChange={formik.handleChange}
                        value={formik.values.name}
                        id="name"
                        onBlur={formik.handleBlur}
                        error={formik.errors.name && formik.touched.name}
                        helperText={formik.errors.name}
                        label="Họ và tên"
                    />
                    <TextField
                        sx={{ mt: '15px' }}
                        fullWidth
                        onChange={formik.handleChange}
                        value={formik.values.phoneNumber}
                        onBlur={formik.handleBlur}
                        error={formik.errors.phoneNumber && formik.touched.phoneNumber}
                        helperText={formik.errors.phoneNumber}
                        id="phoneNumber"
                        label="Số điện thoại"
                    />
                    <Grid
                        mt="10px"
                        container
                        rowSpacing="15px"
                        columnSpacing="10px"
                        justifyContent="space-between">
                        <Grid item lg={6}>
                            <Select
                                fullWidth
                                select
                                onChange={(e) => {
                                    const provinceOrCity = getProvinceOrCity(e.target.value);
                                    setDistricts(getDistrictsFromProvinceOrCity(provinceOrCity.name));

                                    formik.setFieldValue('provinceOrCity', provinceOrCity.name);
                                    formik.setFieldValue('district', null);
                                    formik.setFieldValue('wardOrCommune', null);
                                }}
                                value={formik.values.provinceOrCity}
                                onBlur={formik.handleBlur}
                                error={formik.errors.provinceOrCity && formik.touched.provinceOrCity}
                                helperText={formik.errors.provinceOrCity}
                                id="provinceOrCity"
                                label="Tỉnh/Thành phố">
                                {Object.values(tinh_tp).map(({ name, code }) => {
                                    return (
                                        <MenuItem
                                            key={code}
                                            value={name}>
                                            {name}
                                        </MenuItem>
                                    )
                                })}
                            </Select>
                        </Grid>
                        <Grid item lg={6}>
                            <Select
                                select
                                fullWidth
                                onChange={(e) => {
                                    const district = e.target.value;
                                    setWardOrCommunes(getWardOrCommunesByDistrict(district))
                                    formik.setFieldValue('district', district);
                                    formik.setFieldValue('wardOrCommune', null);
                                }}
                                value={formik.values.district}
                                onBlur={formik.handleBlur}
                                error={formik.errors.district && formik.touched.district}
                                helperText={formik.errors.district}
                                id="district"
                                label="Quận/Huyện">
                                {districts.map(({ name, code }) => {
                                    return (
                                        <MenuItem
                                            key={code}
                                            value={name}>
                                            {name}
                                        </MenuItem>
                                    )
                                })}
                            </Select>
                        </Grid>
                        <Grid item lg={12}>
                            <Select
                                fullWidth
                                select
                                onChange={(e) => {
                                    formik.setFieldValue('wardOrCommune', e.target.value);
                                }}
                                value={formik.values.wardOrCommune}
                                onBlur={formik.handleBlur}
                                error={formik.errors.wardOrCommune && formik.touched.wardOrCommune}
                                helperText={formik.errors.wardOrCommune}
                                id="wardOrCommune"
                                label="Xã/Phường">
                                {wardOrCommunes.map(({ name, code }) => {
                                    return (
                                        <MenuItem
                                            key={code}
                                            value={name}>
                                            {name}
                                        </MenuItem>
                                    )
                                })}
                            </Select>
                        </Grid>
                    </Grid>
                    <TextField
                        fullWidth
                        sx={{ mt: '15px' }}
                        onChange={formik.handleChange}
                        value={formik.values.detailAddress}
                        onBlur={formik.handleBlur}
                        error={formik.errors.detailAddress && formik.touched.detailAddress}
                        helperText={formik.errors.detailAddress}
                        id="detailAddress"
                        label="Địa chỉ chi tiết"
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>
                        Hủy
                    </Button>
                    <Button
                        type='submit'
                        autoFocus>
                        Thêm
                    </Button>
                </DialogActions>
            </form>
        </Dialog >
    );
}
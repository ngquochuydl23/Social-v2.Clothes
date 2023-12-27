import React, { useState } from "react";
import LazyLoadingImage from "../../components/LazyLoadingImage";
import { Button, MenuItem, Snackbar, TextField, Typography } from '@mui/material';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { useFormik } from "formik";
import * as Yup from 'yup';
import Alert from '@mui/material/Alert';
import AlertTitle from '@mui/material/AlertTitle';

const Profile = () => {
    const [openSuccessAlert, setOpenSuccessAlert] = useState(false);
    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            fullName: '',
            phoneNumber: '',
            email: '',
            gender: null,
            birthday: null,
        },
        validationSchema: Yup.object().shape({
            fullName: Yup.string()
                .required('Vui lòng nhập họ tên'),
            phoneNumber: Yup.string()
                .required('Vui lòng nhập số điện thoại'),
            email: Yup.string()
                .email('Vui lòng nhập đúng định dạng')
                .required('Vui lòng nhập địa chỉ chi tiết'),
            gender: Yup.number()
                .oneOf([0, 1]),
        }),
        onSubmit: values => {
            setOpenSuccessAlert(true);
            formik.setValues(values)
        },
    });

    const getUserInfo = () => {

    }

    return (
        <div className="container mx-auto lg:px-0 px-4">
            <div className="max-w-4xl mx-auto pt-14 sm:pt-26 pb-24 lg:pb-32">
                <div className="space-y-10 sm:space-y-12">
                    <Typography
                        mb="20px"
                        fontWeight="800"
                        variant="h4">Thông tin cá nhân</Typography>
                    <div className="flex flex-col md:flex-row">
                        <div className="flex-shrink-0 flex items-start">
                            <div className="relative rounded-full overflow-hidden flex">
                                <LazyLoadingImage
                                    src={"https://img.freepik.com/premium-psd/3d-male-cute-cartoon-character-avatar-isolated-3d-rendering_235528-1280.jpg"}
                                    className="w-32 h-32 rounded-full object-cover object-center z-0"
                                    height={"128"}
                                    width={"128"}
                                />
                            </div>
                        </div>
                        <form
                            onSubmit={formik.handleSubmit}
                            className="flex-grow mt-10 md:mt-0 md:pl-16 max-w-3xl space-y-6">
                            <TextField
                                fullWidth
                                id="fullName"
                                label="Họ và tên"
                                onChange={formik.handleChange}
                                onBlur={formik.handleBlur}
                                error={formik.errors.fullName && formik.touched.fullName}
                                helperText={formik.errors.fullName}
                                value={formik.values.fullName}
                            />
                            <TextField
                                fullWidth
                                id="email"
                                label="Địa chỉ email"
                                onChange={formik.handleChange}
                                onBlur={formik.handleBlur}
                                error={formik.errors.email && formik.touched.email}
                                helperText={formik.errors.email}
                                value={formik.values.email}
                            />
                            <LocalizationProvider dateAdapter={AdapterDayjs}>
                                <DatePicker
                                    sx={{ width: '100%' }}
                                    fullWidth
                                    id="birthday"
                                    onAccept={(value) => formik.setFieldValue('birthday', value)}
                                    onBlur={formik.handleBlur}
                                    error={formik.errors.birthday && formik.touched.birthday}
                                    helperText={formik.errors.birthday}
                                    value={formik.values.birthday}
                                    format="DD/MM/YYYY"
                                    label="Ngày sinh" />
                            </LocalizationProvider>
                            <TextField
                                fullWidth
                                select
                                onChange={(e) => {
                                    console.log(e.target.value);
                                    formik.setFieldValue('gender', e.target.value)
                                }}
                                onBlur={formik.handleBlur}
                                error={formik.errors.gender && formik.touched.gender}
                                helperText={formik.errors.gender}
                                value={formik.values.gender}
                                id="gender"
                                label="Giới tính">
                                <MenuItem
                                    key={0}
                                    value={0}>
                                    Nữ
                                </MenuItem>
                                <MenuItem
                                    key={1}
                                    value={1}>
                                    Nam
                                </MenuItem>
                            </TextField>
                            <TextField
                                required
                                fullWidth
                                id="phoneNumber"
                                label="Số điện thoại"
                                onChange={formik.handleChange}
                                onBlur={formik.handleBlur}
                                error={formik.errors.phoneNumber && formik.touched.phoneNumber}
                                helperText={formik.errors.phoneNumber}
                                value={formik.values.phoneNumber}
                            />
                            <Button
                                disabled={formik.values === formik.initialValues}
                                type="submit"
                                fullWidth
                                sx={{ height: '50px' }}
                                variant="contained">
                                Lưu
                            </Button>
                            <Snackbar
                                anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
                                open={openSuccessAlert}
                                autoHideDuration={3000}
                                onClose={() => setOpenSuccessAlert(false)}>
                                <Alert severity="success">
                                    <AlertTitle>Success</AlertTitle>
                                    This is a success alert — <strong>check it out!</strong>
                                </Alert>
                            </Snackbar>
                        </form>
                    </div>
                </div>
            </div>
        </div >
    );
};

export default Profile;

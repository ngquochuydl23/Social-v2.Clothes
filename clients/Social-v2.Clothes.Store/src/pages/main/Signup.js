import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { Alert, AlertTitle, MenuItem, Snackbar, TextField } from "@mui/material";
import { useFormik } from "formik";
import * as Yup from 'yup';
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import moment from "moment";
import dayjs from "dayjs";
import { signUp } from "../../services/api/user-api";

const Signup = () => {
    const navigate = useNavigate();
    const [openErrorAlert, setOpenErrorAlert] = useState(false);

    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            fullName: '',
            phoneNumber: '',
            confirmPassword: '',
            email: '',
            password: '',
            birthday: undefined,
            gender: 0
        },
        validationSchema: Yup.object().shape({
            fullName: Yup.string()
                .required('Vui lòng nhập họ và tên'),
            phoneNumber: Yup.string()
                .max(11, 'Vui lòng nhập đúng định dạng')
                .required('Vui lòng nhập số điện thoại'),
            confirmPassword: Yup.string()
                .oneOf([Yup.ref('password'), null], 'Mật khẩu phải khớp'),
            email: Yup.string()
                .email('Vui lòng nhập đúng định dạng email')
                .required('Vui lòng nhập email'),
            password: Yup.string()
                .min(8, 'Vui lòng nhập tối thiểu 8 kí tự')
                .required('Vui lòng nhập mật khẩu'),
            gender: Yup.number()
                .oneOf([0, 1])
                .required('Vui lòng chọn giới tính')
        }),
        onSubmit: async values => {
            const user = await signUp(values)
                .catch((err) => setOpenErrorAlert(true));

            navigate('/sign-in');
        },
    });

    return (
        <>
            <div className="mt-8 sm:mx-auto sm:w-full sm:max-w-md">
                <div className="bg-white py-2 px-6 rounded-lg sm:px-10">
                    <h2 className="mt-2 text-center text-3xl font-extrabold text-gray-900">
                        Đăng ký
                    </h2>
                    <p className="mt-2 text-center text-sm text-gray-600 max-w">
                        Bạn đã có tài khoản?
                        <Link
                            to="/sign-in"
                            className="font-medium text-indigo-600 hover:text-indigo-500 ml-1">
                            Đăng nhập
                        </Link>
                    </p>
                </div>

                <div className="mt-8 sm:mx-auto sm:w-full sm:max-w-md">
                    <div className="bg-white py-2 px-6 rounded-lg sm:px-10">
                        <form
                            className="mb-0 space-y-6"
                            onSubmit={formik.handleSubmit}>
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
                                id="phoneNumber"
                                label="Số điện thoại"
                                onChange={formik.handleChange}
                                onBlur={formik.handleBlur}
                                error={formik.errors.phoneNumber && formik.touched.phoneNumber}
                                helperText={formik.errors.phoneNumber}
                                value={formik.values.phoneNumber}
                            />
                            <TextField
                                fullWidth
                                id="password"
                                label="Mật khẩu"
                                onChange={formik.handleChange}
                                onBlur={formik.handleBlur}
                                error={formik.errors.password && formik.touched.password}
                                helperText={formik.errors.password}
                                value={formik.values.password}
                            />
                            <TextField
                                fullWidth
                                id="confirmPassword"
                                label="Xác nhận mật khẩu"
                                onChange={formik.handleChange}
                                onBlur={formik.handleBlur}
                                error={formik.errors.confirmPassword && formik.touched.confirmPassword}
                                helperText={formik.errors.confirmPassword}
                                value={formik.values.confirmPassword}
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
                                    onChange={(value) => {
                                        formik.setFieldValue('birthday', moment(value[`$d`]).format())
                                    }}
                                    onBlur={formik.handleBlur}
                                    error={formik.errors.birthday && formik.touched.birthday}
                                    helperText={formik.errors.birthday}
                                    value={dayjs(formik.values.birthday)}
                                    format="DD/MM/YYYY"
                                    label="Ngày sinh" />
                            </LocalizationProvider>
                            <TextField
                                fullWidth
                                select
                                onChange={(e) => {
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
                            {/* form submit button */}
                            <div>
                                <button type="submit" className="w-full btn-primary">
                                    Sign up
                                </button>
                            </div>
                            <Snackbar
                                anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
                                open={openErrorAlert}
                                autoHideDuration={6000}
                                onClose={() => setOpenErrorAlert(false)}>
                                <Alert
                                    severity="error"
                                    variant="filled">
                                    <AlertTitle>Đăng ký không thành công</AlertTitle>
                                    Số điện thoại hay email của bạn đã được sử dụng — <strong>Thử lại!</strong>
                                </Alert>
                            </Snackbar>
                        </form>
                    </div>
                </div>
            </div>
        </>
    );
};

export default Signup;

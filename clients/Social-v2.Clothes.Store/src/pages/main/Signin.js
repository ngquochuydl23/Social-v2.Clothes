import React, { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { TextField } from "@mui/material";
import { useFormik } from "formik";
import * as Yup from 'yup';
import { signIn } from "../../services/api/user-api";
import { useSelector, useDispatch } from 'react-redux';
import { setUser } from '../../slices/userSlice';

const Signin = () => {
	const navigate = useNavigate();
	const { user } = useSelector((state) => state.user)
	const dispatch = useDispatch()

	useEffect(() => {
		if (user.id) {
			navigate("/account/info");
		}
	}, [user])

	const formik = useFormik({
		enableReinitialize: true,
		initialValues: {
			phoneNumber: '',
			password: ''
		},
		validationSchema: Yup.object().shape({
			phoneNumber: Yup.string()
				.required('Vui lòng nhập số điện thoại'),
			password: Yup.string()
				.required('Vui lòng nhập mật khẩu')
		}),
		onSubmit: async values => {
			const response = await signIn(values.phoneNumber, values.password);
			localStorage.setItem("accessToken", response.token);

			dispatch(setUser(response.user));
		},
	});

	return (
		<div className="mt-20 bg-white flex flex-col justify-center px-6 lg:px-8">
			<div className="sm:mx-auto sm:w-full sm:max-w-md">
				<h2 className="mt-2 text-center text-3xl font-extrabold text-gray-900">
					Đăng nhập
				</h2>
				<p className="mt-2 text-center text-sm text-gray-600 max-w">
					Bạn không có tài khoản?
					<Link
						to="/sign-up"
						className="font-medium text-indigo-600 hover:text-indigo-500 ml-1">
						Đăng ký
					</Link>
				</p>
			</div>
			<div className="mt-8 sm:mx-auto sm:w-full sm:max-w-md">
				<div className="bg-white py-2 px-6 rounded-lg sm:px-10">
					<form
						onSubmit={formik.handleSubmit}
						className="mb-0 space-y-6">
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
							type="password"
							label="Mật khẩu"
							onChange={formik.handleChange}
							onBlur={formik.handleBlur}
							error={formik.errors.password && formik.touched.password}
							helperText={formik.errors.password}
							value={formik.values.password}
						/>
						<div>
							<button className="w-full btn-primary">Sign in</button>
						</div>
					</form>
				</div>
			</div>
		</div >
	);
};

export default Signin;
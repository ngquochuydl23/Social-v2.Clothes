import { Box, Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, FormControl, InputAdornment, Stack, TextField, Typography } from "@mui/material";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useEffect, useState } from "react";
import AlertDialog from "src/components/alert-dialog";

var currencyFormatter = require('currency-formatter');

const EditProductSkuDialog = ({
    open,
    productSku,
    handleClose,
    onProductEdited }) => {

    const [openAlert, setOpenAlert] = useState(false);
    const onClose = (event, reason) => {
        if (reason && reason === "backdropClick" && (formik.values.title || formik.values.optionValues.length > 0)) {
            setOpenAlert(true);
            return;
        }
        handleClose();
    }

    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            title: productSku.title,
            price: productSku.price,
            proSkuMedias: [],
            stock: productSku.stock
        },
        onSubmit: value => {
            onProductEdited(value);
            handleClose();
            formik.resetForm();
        },
        validationSchema: Yup.object({
            title: Yup.string()
                .required("Please enter option title!"),
            stock: Yup.number()
                .required("Please enter stock")
                .min(0, "Stock must be positive number"),
            price: Yup.number()
                .required("Please enter price")
                .min(0, "Price must be positive number"),
            proSkuMedias: Yup.array()
                .of(
                    Yup.object().shape({
                        url: Yup
                            .string()
                            .required(),
                        mime: Yup
                            .string()
                            .required(),
                        width: Yup
                            .number()
                            .required(),
                        height: Yup
                            .number()
                            .required(),
                    })
                )
            // .required('Please upload images for this sku'),
        })
    });

    useEffect(() => {

        if (!open) {
            formik.resetForm();
        } else {
            formik.setFieldValue(productSku);
        }
    }, [open])

    return (
        <Dialog
            maxWidth={'lg'}
            open={open}
            disableBackdropClick
            onClose={onClose}>
            <form onSubmit={formik.handleSubmit}>
                <DialogTitle>Edit product sku</DialogTitle>
                <DialogContent>
                    <Stack
                        marginTop={"10px"}
                        direction="row"
                        alignItems="center">
                        <Typography
                            minWidth="150px"
                            fontSize="16px"
                            marginRight="20px"
                            variant="subtitle2">
                            Title*
                        </Typography>
                        <TextField
                            id="title"
                            placeholder="Enter option title"
                            onBlur={formik.handleBlur}
                            error={formik.errors.title && formik.touched.title}
                            helperText={formik.errors.title}
                            value={formik.values.title}
                            onChange={formik.handleChange}
                            hiddenLabel
                            sx={{ width: '45ch' }}
                        />
                    </Stack>
                    <Stack
                        marginTop={"10px"}
                        direction="row"
                        alignItems="center">
                        <Typography
                            minWidth="150px"
                            fontSize="16px"
                            marginRight="20px"
                            variant="subtitle2">
                            Price*
                        </Typography>
                        <TextField
                            id="price"
                            type="text"
                            placeholder="Enter option title"
                            onBlur={formik.handleBlur}
                            error={formik.errors.price && formik.touched.price}
                            helperText={formik.errors.price}
                            value={currencyFormatter.format(formik.values.price, {
                                code: 'VND',
                                thousand: ',',
                            })}
                            onChange={(e) => {
                                formik.setFieldValue('price', String(currencyFormatter.unformat(e.target.value, { code: 'VND' })))
                            }}
                            hiddenLabel
                            sx={{ width: '45ch' }}
                        />
                    </Stack>
                    <Stack
                        marginTop="15px"
                        direction="row"
                        alignItems="center">
                        <Typography
                            minWidth="150px"
                            fontSize="16px"
                            marginRight="20px"
                            variant="subtitle2">
                            Stock*
                        </Typography>
                        <TextField
                            id="stock"
                            type="number"
                            placeholder="Enter in stock"
                            onBlur={formik.handleBlur}
                            error={formik.errors.stock && formik.touched.stock}
                            helperText={formik.errors.stock}
                            value={formik.values.stock}
                            onChange={formik.handleChange}
                            hiddenLabel
                            sx={{ width: '45ch' }}
                        />
                    </Stack>
                </DialogContent>
                <DialogActions>
                    <Button
                        onClick={() => {
                            if (formik.values !== formik.initialValues) {
                                setOpenAlert(true);
                                return;
                            }
                            handleClose()
                            formik.resetForm()
                        }}>
                        Close
                    </Button>
                    <Button
                        disabled={
                            (formik.errors.title || formik.errors.price || formik.errors.stock)
                            || (formik.initialValues === formik.values)
                        }
                        type="submit">Change</Button>
                </DialogActions>
            </form>
            <AlertDialog
                title={"Discard changes?"}
                leftTxt={"Cancel"}
                rightTxt={"Discard"}
                content={"Are you sure you want to discard changes? This action cannot be undone."}
                open={openAlert}
                onRightClick={() => {
                    handleClose()
                    formik.resetForm()
                }}
                onLeftClick={() => setOpenAlert(false)}
                handleClose={() => setOpenAlert(false)} />
        </Dialog>
    )
}

export default EditProductSkuDialog;
import { Box, Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, FormControl, InputAdornment, Stack, TextField, Typography } from "@mui/material";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useEffect, useState } from "react";
import AlertDialog from "src/components/alert-dialog";

var currencyFormatter = require('currency-formatter');

const ApplyForSkusDialog = ({
    open,
    handleClose,
    onApply
}) => {
    const formik = useFormik({
        enableReinitialize: true,
        initialValues: {
            price: 0,
            stock: 0
        },
        onSubmit: value => {
            onApply(value);
            handleClose();
            formik.resetForm();
        },
        validationSchema: Yup.object({
            stock: Yup.number()
                .min(0, "Stock must be positive number"),
            price: Yup.number()
                .min(0, "Price must be positive number"),
        })
    });


    useEffect(() => {
        if (!open) {
            formik.resetForm();
        }
    }, [open])

    return (
        <Dialog
            maxWidth={'lg'}
            open={open}
            disableBackdropClick
            onClose={handleClose}>
            <form onSubmit={formik.handleSubmit}>
                <DialogTitle id="alert-dialog-title">
                    Apply for skus
                </DialogTitle>
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
                                formik.setFieldValue('price', currencyFormatter.unformat(e.target.value, { code: 'VND' }))
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
                    <Button onClick={() => {
                        handleClose()
                    }}>Cancel</Button>
                    <Button type="submit" autoFocus>
                        Apply
                    </Button>
                </DialogActions>
            </form>
        </Dialog>
    )
}

export default ApplyForSkusDialog;
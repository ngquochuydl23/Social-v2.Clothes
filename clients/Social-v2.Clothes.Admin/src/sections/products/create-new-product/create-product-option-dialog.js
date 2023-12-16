import { Box, Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, FormControl, InputAdornment, Stack, TextField, Typography } from "@mui/material";
import { MuiChipsInput } from 'mui-chips-input'
import { useFormik } from "formik";
import * as Yup from "yup";
import { useEffect, useState } from "react";
import AlertDialog from "src/components/alert-dialog";

const CreateProductOptionDialog = ({ open, handleClose, onCreateOption }) => {
    const [openAlert, setOpenAlert] = useState(false);
    const onClose = (event, reason) => {
        if (reason && reason === "backdropClick" && (formik.values.title || formik.values.optionValues.length > 0)) {
            setOpenAlert(true);
            return;
        }
        handleClose();
    }

    const formik = useFormik({
        initialValues: {
            title: '',
            optionValues: []
        },
        onSubmit: value => {
            handleClose();
            onCreateOption(value);
        },
        validationSchema: Yup.object({
            title: Yup.string()
                .required("Please enter option title!"),
            optionValues: Yup.array()
                .of(Yup.string())
                .min(2, "Enter at least two option values")
                .required("Please enter option values!")
        })
    });

    useEffect(() => {
        formik.resetForm();
    }, [open])

    return (
        <Dialog
            maxWidth={'lg'}
            open={open}
            disableBackdropClick
            onClose={onClose}>
            <form onSubmit={formik.handleSubmit}>
                <DialogTitle>Add new option</DialogTitle>
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
                            sx={{ width: '45ch', }}
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
                            Option values*
                        </Typography>
                        <MuiChipsInput
                            id="optionValues"
                            onBlur={formik.handleBlur}
                            value={formik.values.optionValues}
                            error={formik.errors.optionValues && formik.touched.optionValues}
                            helperText={formik.errors.optionValues}
                            onChange={(options) => {
                                formik.setFieldValue('optionValues', options)
                            }}
                            placeholder="Enter option values"
                            hiddenLabel
                            sx={{
                                width: '45ch',
                                minHeight: '40px',
                            }}
                        />
                    </Stack>
                </DialogContent>
                <DialogActions>
                    <Button onClick={() => {
                        if (formik.values.title || formik.values.optionValues.length > 0) {
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
                            (formik.errors.optionValues || formik.errors.title)
                            || (formik.initialValues === formik.values)
                        }
                        type="submit">Add</Button>
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
        </Dialog >
    )
}

export default CreateProductOptionDialog;
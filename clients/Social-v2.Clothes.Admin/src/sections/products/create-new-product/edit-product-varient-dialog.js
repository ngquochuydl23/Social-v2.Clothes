import { Box, Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, FormControl, Grid, InputAdornment, Stack, TextField, Typography } from "@mui/material";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useEffect, useState } from "react";
import AlertDialog from "src/components/alert-dialog";
import _ from "lodash";
import ClearIcon from '@mui/icons-material/Clear';
import FormHelperText from '@mui/material/FormHelperText';
import { uploadFile, uploadFiles } from "src/services/api/upload-api";

var currencyFormatter = require('currency-formatter');



const AddProductVarientMedia = ({ onUploaded, varientMedias, onDropAllMedia }) => {
    const [proVarientMedias, setProVarientMedias] = useState(varientMedias || []);
    const [hasUploaded, setHasUploaded] = useState(false);

    const uploadMedias = async (unUploadedImages) => {
        console.log(unUploadedImages);

        if (unUploadedImages.length > 0) {
            var files = _.map(unUploadedImages, (image) => image.localFile);

            const { medias } = await uploadFiles(files)
                .catch((err) => console.log(err))

            const uploadedImages = unUploadedImages.map((image, idx) => ({
                ...image,
                url: medias[idx].url
            }))

            onUploaded([...uploadedImages, proVarientMedias]);
        }
    }

    useEffect(() => {
        setProVarientMedias(varientMedias);
    }, [])

    useEffect(() => {
        uploadMedias(_.filter(proVarientMedias, (varientMedia) => !varientMedia.url))
    }, [proVarientMedias])

    return (
        <Box sx={{ width: '100%' }}>
            <Box
                sx={{
                    border: 'dashed 1px #696969',
                    width: '100%',
                    padding: '5px',
                    minHeight: '120px'
                }}>
                <Grid container
                    spacing={{ lg: '5px' }}>
                    {_.map(proVarientMedias, (varientMedia, idx) => (
                        <Grid
                            item
                            lg={4}>
                            <div style={{ display: 'flex', flexDirection: 'column' }}>
                                <img
                                    style={{
                                        position: 'relative',
                                        aspectRatio: 1,
                                        objectFit: 'cover'
                                    }}
                                    width="100%"
                                    src={Boolean(varientMedia.url) ? varientMedia.url : URL.createObjectURL(varientMedia.localFile)} />
                                <div
                                    onClick={() => setProSkuMedias(proVarientMedias.filter((item, index) => index !== idx))}
                                    style={{
                                        display: 'flex',
                                        position: 'absolute',
                                        zIndex: 2,
                                        margin: '10px',
                                        padding: '2.5px',
                                        alignSelf: 'flex-end',
                                        backgroundColor: 'rgba(255, 255, 255, 0.5)'
                                    }}>
                                    <ClearIcon />
                                </div>
                            </div>
                        </Grid>
                    ))}
                </Grid>
            </Box>
            <input
                multiple
                onChange={(event) => {
                    var files = event.target.files;
                    setHasUploaded(false);

                    if (files.length > 0) {
                        setProVarientMedias([...proVarientMedias, ..._.map(files, (file, idx) => {
                            return {
                                idx: proVarientMedias.length + idx,
                                url: undefined,
                                localFile: file,
                                width: file.width || 1200,
                                height: file.height || 1200,
                                mime: file.type
                            }
                        })])
                    }
                }}
                style={{ display: 'none' }}
                type="file"
                accept="image/*"
                id="pickSkuImage" />
            <Button
                fullWidth
                onClick={() => {
                    document.getElementById("pickSkuImage").click()
                }}
                sx={{
                    my: '20px',
                    borderRadius: '4px',
                    height: '30px',
                    fontSize: '14px',
                }}
                variant='contained'>
                Add new media
            </Button>
        </Box>
    )
}

const EditProductVarientDialog = ({
    open,
    productVarient,
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
            title: productVarient.title,
            price: productVarient.price,
            proVarientMedias: productVarient.proVarientMedias,
            stock: productVarient.stock
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
            proVarientMedias: Yup.array()
                .min(0, "Please upload at least one media")
                // .of(
                //     Yup.object().shape({
                //         url: Yup
                //             .string()
                //             .required(),
                //         mime: Yup
                //             .string()
                //             .required(),
                //         width: Yup
                //             .number()
                //             .required(),
                //         height: Yup
                //             .number()
                //             .required(),
                //     })
                // )
                .required('Please upload images for this sku'),
        })
    });

    useEffect(() => {

        if (!open) {
            formik.resetForm();
        } else {
            formik.setFieldValue(productVarient);
        }
    }, [open])

    return (
        <Dialog
            maxWidth={'sm'}
            open={open}
            disableBackdropClick
            onClose={onClose}>
            <form onSubmit={formik.handleSubmit}>
                <DialogTitle>Edit product varient</DialogTitle>
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
                    <Stack
                        marginTop="15px"
                        direction="row">
                        <Typography
                            minWidth="150px"
                            fontSize="16px"
                            marginRight="20px"
                            variant="subtitle2">
                            Product Images*
                        </Typography>
                        <AddProductVarientMedia
                            varientMedias={productVarient.proVarientMedias}
                            onDropAllMedia={() => {

                                formik.setFieldValue('proVarientMedias', [])
                                formik.setFieldTouched('proVarientMedias', true)
                            }}
                            onUploaded={(proVarientMedias) => {
                                formik.setFieldValue('proVarientMedias', proVarientMedias)
                                //  formik.setFieldTouched('proSkuMedias', true)
                            }} />

                    </Stack>
                    {(formik.errors.proSkuMedias && formik.touched.proSkuMedias) &&
                        <Typography>
                            {formik.errors.proSkuMedias}
                        </Typography>
                    }
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
                            (formik.errors.title || formik.errors.price || formik.errors.stock || formik.errors.proVarientMedias)
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

export default EditProductVarientDialog;
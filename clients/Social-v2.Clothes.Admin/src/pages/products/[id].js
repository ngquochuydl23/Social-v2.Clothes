import Head from 'next/head';
import {
    Box,
    Button,
    Container,
    Stack,
    Typography,
    Unstable_Grid2 as Grid,
    Popover,
    Drawer,
    Snackbar,
    Alert,
    AlertTitle
} from '@mui/material';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import ProductDetailOptionItem from 'src/sections/products/product-detail/product-detail-option-item';
import _ from 'lodash';
import ProductDetailVarientItem from 'src/sections/products/product-detail/product-detail-varient';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import { useEffect, useState } from 'react';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import AlertDialog from 'src/components/alert-dialog';
import EditGeneralInfo from 'src/sections/products/edit-product/edit-general-info';
import CloseIcon from '@mui/icons-material/Close';
import { useRouter } from 'next/router';
import {
    deleteProduct,
    getProduct,
    getProductVarients
} from 'src/services/api/product-api';
import Backdrop from '@mui/material/Backdrop';
import CircularProgress from '@mui/material/CircularProgress';

const ProductDetailPage = () => {

    const [openEditGeneralDrawer, setOpenEditGeneralDrawer] = useState(false);
    const [openAlert, setOpenAlert] = useState(false);
    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);
    const idPopover = open ? 'simple-popover' : undefined;

    const [product, setProduct] = useState();
    const [loading, setLoading] = useState(true);
    const [showDeleteSuccess, setShowDeleteSuccess] = useState(false);

    const router = useRouter();
    const { id } = router.query;

    const getProductDetail = async () => {
        const productResponse = await getProduct(id);
        const productVarients = await getProductVarients(id);

        setProduct({ ...productResponse, productVarients })
    }

    const onDeleteProduct = () => {
        if (id) {
            deleteProduct(id)
                .then(() => {
                    setShowDeleteSuccess(true);
                    router.back();
                })
                .catch((err) => console.log(err))
        }
    }

    useEffect(() => {
        setLoading(true);

        getProductDetail()
            .catch((err) => console.log(err))
            .finally(() => setLoading(false));
    }, [id])

    if (loading) return null;

    return (
        <>
            <Head>
                <title>
                    {product.title}
                </title>
            </Head>
            <Box
                component="main"
                sx={{ flexGrow: 1 }}>
                <Container maxWidth="lg">
                    <Stack direction="row">
                        <Box flex={1.5}>
                            <Stack
                                alignItems="center"
                                justifyContent="space-between"
                                direction="row">
                                <Typography
                                    mt="22px"
                                    mb="20px"
                                    fontSize="26px"
                                    variant='h3'>
                                    {product.title}
                                </Typography>
                                <Stack
                                    color="black"
                                    direction="row">
                                    <Button
                                        sx={{
                                            width: '120px',
                                            borderRadius: '4px',
                                            height: '30px',
                                            fontSize: '14px',
                                            borderColor: '#606060',
                                            color: '#606060'
                                        }}
                                        variant='outlined'>
                                        Published
                                    </Button>
                                    <Button
                                        onClick={(event) => setAnchorEl(event.currentTarget)}
                                        sx={{ color: '#696969', height: '30px', }}>
                                        <MoreVertIcon />
                                    </Button>
                                    <Popover
                                        id={idPopover}
                                        open={open}
                                        anchorEl={anchorEl}
                                        onClose={() => setAnchorEl(null)}
                                        anchorOrigin={{
                                            vertical: 'bottom',
                                            horizontal: 'left',
                                        }}
                                        PaperProps={{ sx: { width: 200, padding: '10px' } }}
                                        transformOrigin={{
                                            vertical: 'top',
                                            horizontal: 'left',
                                        }}>
                                        <Stack
                                            sx={{
                                                width: '100%',
                                                backgroundColor: 'white'
                                            }}>
                                            <Button
                                                onClick={() => {
                                                    setAnchorEl(null);
                                                    setOpenEditGeneralDrawer(true);
                                                }}
                                                startIcon={<EditIcon />}
                                                sx={{ color: '#696969' }}
                                                variant='text'>
                                                Edit general info
                                            </Button>
                                            <Button
                                                onClick={() => setOpenAlert(true)}
                                                sx={{ color: 'red' }}
                                                startIcon={<DeleteIcon />}
                                                variant='text'>
                                                Delete product
                                            </Button>
                                        </Stack>
                                    </Popover>
                                </Stack>
                            </Stack>
                            <Typography
                                mb="40px"
                                color="#696969"
                                fontStyle="300"
                                fontSize="16px"
                                variant='caption'>
                                {product.subtitle}
                            </Typography>
                            <Box>

                            </Box>
                            <Box>
                                <Typography
                                    mt="22px"
                                    mb="20px"
                                    fontSize="20px"
                                    variant='h3'>
                                    Options
                                </Typography>
                                <Grid container >
                                    {_.map(product.options, (option, index) => (
                                        <Grid item xs={6}>
                                            <ProductDetailOptionItem
                                                index={index}
                                                title={option.title}
                                                optionValues={option.optionValues}
                                            />
                                        </Grid>
                                    ))}
                                </Grid>
                            </Box>
                            <Box>
                                <Typography
                                    mt="22px"
                                    mb="20px"
                                    fontSize="20px"
                                    variant='h3'>
                                    Variants
                                </Typography>
                                <Stack>
                                    {_.map(product.productVarients, (varient, index) => (
                                        <Grid item xs={6}>
                                            <ProductDetailVarientItem
                                                productTitle={varient.productTitle}
                                                {...varient}

                                            />
                                        </Grid>
                                    ))}
                                </Stack>
                            </Box>
                            <Box mb={'40px'}>
                                <Typography
                                    mt="22px"
                                    mb="20px"
                                    fontSize="20px"
                                    variant='h3'>
                                    Attributes
                                </Typography>
                                <Typography
                                    fontSize="18px"
                                    variant='subtitle1'>
                                    Dimensions
                                </Typography>
                                <Stack
                                    mt={"10px"}
                                    direction="row"
                                    justifyContent="space-between">
                                    <Typography
                                        fontSize="14px"
                                        variant='subtitle2'>
                                        Height
                                    </Typography>
                                    <Typography
                                        fontSize="14px"
                                        variant='subtitle2'>
                                        {`114cm`}
                                    </Typography>
                                </Stack>
                                <Stack
                                    mt={"10px"}
                                    direction="row"
                                    justifyContent="space-between">
                                    <Typography
                                        fontSize="14px"
                                        variant='subtitle2'>
                                        Width
                                    </Typography>
                                    <Typography
                                        fontSize="14px"
                                        variant='subtitle2'>
                                        {`57cm`}
                                    </Typography>
                                </Stack>
                                <Stack
                                    mt={"10px"}
                                    direction="row"
                                    justifyContent="space-between">
                                    <Typography
                                        fontSize="14px"
                                        variant='subtitle2'>
                                        Length
                                    </Typography>
                                    <Typography
                                        fontSize="14px"
                                        variant='subtitle2'>
                                        {`48cm`}
                                    </Typography>
                                </Stack>
                                <Stack
                                    mt={"10px"}
                                    direction="row"
                                    justifyContent="space-between">
                                    <Typography
                                        fontSize="14px"
                                        variant='subtitle2'>
                                        Length
                                    </Typography>
                                    <Typography
                                        fontSize="14px"
                                        variant='subtitle2'>
                                        {`800g`}
                                    </Typography>
                                </Stack>
                            </Box>
                        </Box>
                        <Box flex={1}>

                        </Box>
                    </Stack >
                </Container >
            </Box >
            <AlertDialog
                title={"Delete product?"}
                leftTxt={"Cancel"}
                rightTxt={"Yes"}
                content={"Are you sure you want to delete this product?"}
                open={openAlert}
                onRightClick={() => {
                    setOpenAlert(false);
                    onDeleteProduct();
                }}
                onLeftClick={() => setOpenAlert(false)}
                handleClose={() => setOpenAlert(false)} />
            <Drawer
                anchor="right"
                sx={{ maxWidth: '200px' }}
                open={openEditGeneralDrawer}
                onClose={() => setOpenEditGeneralDrawer(false)}>
                <Stack
                    sx={{ mt: '10px' }}
                    alignItems="center"
                    direction="row">
                    <Button
                        onClick={() => setOpenEditGeneralDrawer(false)}
                        sx={{ color: 'black' }}
                        variant='text'>
                        <CloseIcon />
                    </Button>
                    <Typography
                        fontSize="20px"
                        variant='h4'>
                        Edit general information
                    </Typography>
                </Stack>
                <EditGeneralInfo product={product} />
            </Drawer>
            <Snackbar
                anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
                open={showDeleteSuccess}
                autoHideDuration={6000}
                onClose={() => setShowDeleteSuccess(false)}>
                <Alert
                    severity="success"
                    variant="filled">
                    Xóa thành công
                </Alert>
            </Snackbar>
        </>
    )
}

ProductDetailPage.getLayout = (page) => (
    <DashboardLayout>
        {page}
    </DashboardLayout>
);

export default ProductDetailPage;

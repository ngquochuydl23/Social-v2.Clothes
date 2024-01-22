import Head from 'next/head';
import {
    Box,
    Container,
    Stack,
    Typography,
    Unstable_Grid2 as Grid,
    Avatar
} from '@mui/material';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import { useEffect, useState } from 'react';
import OrderDetailItem from 'src/sections/orders/order/order-detail-item';
import currencyFormatter from 'currency-formatter';
import OrderTimeline from 'src/sections/orders/order/order-timeline';
import { deepOrange, deepPurple } from '@mui/material/colors';
import { stringToColor } from 'src/utils/string-to-color';
import { getInitCharOfFullName } from 'src/utils/fullname-util';

const OrderDetailPage = () => {
    const [order, setOrder] = useState();

    useEffect(() => {

    }, [])

    return (
        <>
            <Head>
                <title>
                    #SC-04102003
                </title>
            </Head>
            <Box
                component="main"
                sx={{ flexGrow: 1 }}>
                <Container maxWidth="lg">
                    <Stack spacing={3}>
                        <Typography
                            mt="22px"
                            fontSize="30px"
                            variant='h3'>
                            Order #SC-04102003
                        </Typography>
                        <Typography
                            mt="10px"
                            variant="subtitle1">
                            25 January 2024, 23:01
                        </Typography>
                        <Stack
                            alignItems="center"
                            direction="row">
                            <Box
                                sx={{
                                    height: '60px',
                                    width: '60px',
                                    borderRadius: '200px',
                                    border: '2px solid #d3d3d3',
                                    padding: '5px',
                                }}>
                                <Avatar
                                    sx={{
                                        height: '100%',
                                        width: '100%'
                                    }}
                                    {...stringToColor('Thanh Phương')}>
                                    {getInitCharOfFullName('Thanh Phương')}
                                </Avatar>
                            </Box>
                            <Box ml="20px">
                                <Typography
                                    fontSize="16px"
                                    fontWeight="600"
                                    variant='subtitle1'>
                                    {`Nguyễn Thanh Phương`}
                                </Typography>
                                <Typography variant='subtitle2'>{`thanhphuong04102003@gmail.com`}</Typography>
                            </Box>
                        </Stack>
                        <Box>
                            <Typography
                                mt="22px"
                                mb="20px"
                                fontSize="24px"
                                variant='h3'>
                                Summary
                            </Typography>
                            <Stack
                                direction="column">
                                <OrderDetailItem />
                            </Stack>
                            <Stack
                                mt="25px"
                                direction="row"
                                justifyContent="space-between">
                                <Typography
                                    fontSize="16px"
                                    variant="subtitle1">
                                    Subtotal
                                </Typography>
                                <Typography
                                    fontSize="16px"
                                    variant="subtitle1">
                                    {currencyFormatter.format(125000, {
                                        code: 'VND',
                                        thousand: ',',
                                    })}
                                </Typography>
                            </Stack>
                            <Stack
                                mt="25px"
                                direction="row"
                                justifyContent="space-between">
                                <Typography
                                    fontSize="16px"
                                    variant="subtitle1">
                                    Discount
                                </Typography>
                                <Typography
                                    fontSize="16px"
                                    variant="subtitle1">
                                    {currencyFormatter.format(25000, {
                                        code: 'VND',
                                        thousand: ',',
                                    })}
                                </Typography>
                            </Stack>
                            <Stack
                                mt="25px"
                                direction="row"
                                justifyContent="space-between">
                                <Typography
                                    fontSize="16px"
                                    variant="subtitle1">
                                    Shipping
                                </Typography>
                                <Typography
                                    fontSize="16px"
                                    variant="subtitle1">
                                    {currencyFormatter.format(25000, {
                                        code: 'VND',
                                        thousand: ',',
                                    })}
                                </Typography>
                            </Stack>
                            <Stack
                                mt="15px"
                                direction="row"
                                justifyContent="space-between">
                                <Typography
                                    color="#696969"
                                    fontSize="14px"
                                    variant="subtitle1">
                                    Standared shipping fee
                                </Typography>
                                <Typography
                                    color="#696969"
                                    fontSize="14px"
                                    variant="subtitle1">
                                    {currencyFormatter.format(25000, {
                                        code: 'VND',
                                        thousand: ',',
                                    })}
                                </Typography>
                            </Stack>
                            <Stack
                                mt="15px"
                                direction="row"
                                justifyContent="space-between">
                                <Typography
                                    color="#696969"
                                    fontSize="14px"
                                    variant="subtitle1">
                                    Special shipping surcharge
                                </Typography>
                                <Typography
                                    fontSize="14px"
                                    color="#696969"
                                    variant="subtitle1">
                                    {currencyFormatter.format(25000, {
                                        code: 'VND',
                                        thousand: ',',
                                    })}
                                </Typography>
                            </Stack>
                            <Stack
                                mt="25px"
                                direction="row"
                                justifyContent="space-between">
                                <Typography
                                    fontSize="16px"
                                    variant="subtitle1">
                                    Tax
                                </Typography>
                                <Typography
                                    fontSize="16px"
                                    variant="subtitle1">
                                    {currencyFormatter.format(25000, {
                                        code: 'VND',
                                        thousand: ',',
                                    })}
                                </Typography>
                            </Stack>
                            <Stack
                                mt="25px"
                                direction="row"
                                justifyContent="space-between">
                                <Typography
                                    fontWeight="600"
                                    fontSize="22px"
                                    variant="subtitle1">
                                    Total
                                </Typography>
                                <Typography
                                    fontWeight="600"
                                    fontSize="22px"
                                    variant="subtitle1">
                                    {currencyFormatter.format(110000, {
                                        code: 'VND',
                                        thousand: ',',
                                    })}
                                </Typography>
                            </Stack>
                        </Box>
                        <Box>
                            <Typography
                                mt="22px"
                                mb="20px"
                                fontSize="24px"
                                variant='h3'>
                                Payments
                            </Typography>
                        </Box>
                        {/* <Box>
                            <Typography
                                mt="22px"
                                mb="20px"
                                fontSize="24px"
                                variant='h3'>
                                Timeline
                            </Typography>
                            <OrderTimeline />
                        </Box> */}
                    </Stack>
                </Container>
            </Box>
        </>
    )
}
OrderDetailPage.getLayout = (page) => (
    <DashboardLayout>
        {page}
    </DashboardLayout>
);

export default OrderDetailPage;

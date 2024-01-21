import Head from 'next/head';
import {
    Box,
    Container,
    Stack,
    Typography,
    Unstable_Grid2 as Grid
} from '@mui/material';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import { CustomerTable } from 'src/sections/customer/customer-table';
import { useEffect, useState } from 'react';
import { getCustomers } from 'src/services/api/customer-api';
import { OrderTable } from 'src/sections/orders/order-table';
import { getOrders } from 'src/services/api/order-api';

const OrderPage = () => {
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        getOrders()
            .then((res) => setOrders(res))
            .catch((err) => console.log(err))
    }, [])

    return (
        <>
            <Head>
                <title>
                    Orders
                </title>
            </Head>
            <Box
                component="main"
                sx={{ flexGrow: 1 }}>
                <Container maxWidth="lg">
                    <Stack spacing={3}>
                        <Typography variant="h4">
                            Orders
                        </Typography>
                        <OrderTable
                            orders={orders} />
                    </Stack>
                </Container>
            </Box>
        </>
    )
}
OrderPage.getLayout = (page) => (
    <DashboardLayout>
        {page}
    </DashboardLayout>
);

export default OrderPage;

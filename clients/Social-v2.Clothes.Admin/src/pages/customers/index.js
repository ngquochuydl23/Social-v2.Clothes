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

const CustomerPage = () => {
    const [customer, setCustomer] = useState([]);

    useEffect(() => {
        getCustomers()
            .then((res) => setCustomer(res))
            .catch((err) => console.log(err));
    }, [])

    return (
        <>
            <Head>
                <title>
                    Customers
                </title>
            </Head>
            <Box
                component="main"
                sx={{ flexGrow: 1 }}>
                <Container maxWidth="lg">
                    <Stack spacing={3}>
                        <Typography variant="h4">
                            Customers
                        </Typography>
                        <CustomerTable customers={customer} />
                    </Stack>
                </Container>
            </Box>
        </>
    )
}
CustomerPage.getLayout = (page) => (
    <DashboardLayout>
        {page}
    </DashboardLayout>
);

export default CustomerPage;

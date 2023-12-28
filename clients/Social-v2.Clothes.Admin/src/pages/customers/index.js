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


const customers = [
    {
        id: 1,
        name: 'Nguyễn Quốc Huy',
        avatar: 'https://img.freepik.com/premium-psd/3d-male-cute-cartoon-character-avatar-isolated-3d-rendering_235528-1280.jpg',
        email: 'nguyenquochuydl123@gmail.com',
        createdAt: '2019-04-11T10:20:30Z',
        orders: 25,
    },
    {
        id: 2,
        name: 'Nguyễn Thanh Phương',
        avatar: 'https://img.freepik.com/premium-photo/cartoon-character-beautiful-smiling-girl-with-long-hair-blue-eyes-simple-background_688921-2970.jpg?w=2000',
        email: 'thanhphuong04102003@gmail.com',
        createdAt: '2019-04-11T10:20:30Z',
        orders: 25,
    }
];


const CustomerPage = () => (
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
                    <CustomerTable customers={customers} />
                </Stack>
            </Container>
        </Box>
    </>
);

CustomerPage.getLayout = (page) => (
    <DashboardLayout>
        {page}
    </DashboardLayout>
);

export default CustomerPage;

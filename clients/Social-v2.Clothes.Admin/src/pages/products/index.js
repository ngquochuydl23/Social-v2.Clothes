import Head from 'next/head';
import {
	Box,
	Container,
	Stack,
	Typography,
	Unstable_Grid2 as Grid
} from '@mui/material';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import { ProductTable } from 'src/sections/products/product-table';
import { useEffect, useState } from 'react';
import { getProducts } from 'src/services/api/product-api';


const songs = [
	{
		id: 'jeans-basics-dang-regular-straight',
		name: 'Jeans Basics dáng Regular Straight',
		thumbnail: 'https://media2.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2023/23CMCW.JE003.11_52.jpg',
		collection: 'Winter 2023',
		status: 'Published',
		createdAt: '2019-04-11T10:20:30Z'
	}
];


const Page = () => {

	const [products, setProducts] = useState([]);

	useEffect(() => {
		getProducts()
			.then((res) => setProducts(res))
			.catch((err) => console.log(err))
	}, [])


	return (
		<div>
			<Head>
				<title>
					Products
				</title>
			</Head>
			<Box
				component="main"
				sx={{ flexGrow: 1 }}>
				<Container maxWidth="lg">
					<Stack spacing={3}>
						<Typography variant="h4">
							Products
						</Typography>
						<ProductTable products={products} />
					</Stack>
				</Container>
			</Box>
		</div>
	)
}

Page.getLayout = (page) => (
	<DashboardLayout>
		{page}
	</DashboardLayout>
);

export default Page;

import Head from 'next/head';
import {
	Box,
	Container,
	Stack,
	Typography,
	Unstable_Grid2 as Grid,
	Button
} from '@mui/material';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import { ProductTable } from 'src/sections/products/product-table';
import { useEffect, useState } from 'react';
import { getProducts } from 'src/services/api/product-api';
import AddIcon from '@mui/icons-material/Add';

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
					<Stack
						marginTop="20px"
						spacing={3}>
						<Stack
							alignItems="center"
							direction="row"
							justifyContent="space-between">
							<Typography variant="h4">
								Products
							</Typography>
							<Button
								href='products/create-new-product'
								startIcon={<AddIcon />}
								sx={{
									height: '30px',
									marginLeft: '10px',
									borderRadius: '10px',
								}}
								variant="contained"
								fullWidth={false}>
								New product
							</Button>
						</Stack>
						<ProductTable
							products={products} />
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

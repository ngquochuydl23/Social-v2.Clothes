import Head from 'next/head';
import ArrowUpOnSquareIcon from '@heroicons/react/24/solid/ArrowUpOnSquareIcon';
import ArrowDownOnSquareIcon from '@heroicons/react/24/solid/ArrowDownOnSquareIcon';
import PlusIcon from '@heroicons/react/24/solid/PlusIcon';
import {
  Box,
  Button,
  Container,
  Pagination,
  Stack,
  SvgIcon,
  Typography,
  Unstable_Grid2 as Grid
} from '@mui/material';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import { CompanyCard } from 'src/sections/companies/company-card';
import { CompaniesSearch } from 'src/sections/companies/companies-search';
import millify from 'millify';
import { OverviewListenerInPeriod } from 'src/sections/products/overview-listener-in-period';
import { OverviewListenerGender } from 'src/sections/products/overview-listener-gender';
import { OverviewListenerAgeGroup } from 'src/sections/products/overview-listener-age-group';
import { ProductTable } from 'src/sections/products/product-table';


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


const Page = () => (
  <>
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
          <ProductTable products={songs} />
        </Stack>
      </Container>
    </Box>
  </>
);

Page.getLayout = (page) => (
  <DashboardLayout>
    {page}
  </DashboardLayout>
);

export default Page;

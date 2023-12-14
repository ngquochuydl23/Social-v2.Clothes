import { useCallback, useMemo, useState } from 'react';
import Head from 'next/head';
import { subDays, subHours } from 'date-fns';
import ArrowDownOnSquareIcon from '@heroicons/react/24/solid/ArrowDownOnSquareIcon';
import ArrowUpOnSquareIcon from '@heroicons/react/24/solid/ArrowUpOnSquareIcon';
import PlusIcon from '@heroicons/react/24/solid/PlusIcon';
import { Box, Button, Container, Fab, Stack, SvgIcon, Typography } from '@mui/material';
import { useSelection } from 'src/hooks/use-selection';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import { CustomersTable } from 'src/sections/customer/customers-table';
import { CustomersSearch } from 'src/sections/customer/customers-search';
import { applyPagination } from 'src/utils/apply-pagination';
import AddIcon from '@mui/icons-material/Add';
const now = new Date();

const data = [
  {
    id: '5e887ac47eed253091be10cb',
    songTitle: 'Close to me (Lại gần em)',
    streamCount: 1000000,
    thumbnail: 'https://photo-resize-zmp3.zmdcdn.me/w256_r1x1_jpeg/covers/d/c/dcadeb7fa3c0f086845cef885f15486f_1474268660.jpg',
    listenerCount: 2300000,
    viewerCount: 2300000,
    listenerCount: 123999,
    saveCount: 2222222,
  },
  {
    id: '5e887ac47eed253091be10c1',
    songTitle: 'Close to me (Lại gần em)',
    streamCount: 1000000,
    thumbnail: 'https://photo-resize-zmp3.zmdcdn.me/w256_r1x1_jpeg/covers/d/c/dcadeb7fa3c0f086845cef885f15486f_1474268660.jpg',
    listenerCount: 2300000,
    viewerCount: 2300000,
    listenerCount: 123999,
    saveCount: 2222222,
  },
  {
    id: '5e887ac47eed253091be10c1',
    songTitle: 'Close to me (Lại gần em)',
    streamCount: 1000000,
    thumbnail: 'https://photo-resize-zmp3.zmdcdn.me/w256_r1x1_jpeg/covers/d/c/dcadeb7fa3c0f086845cef885f15486f_1474268660.jpg',
    listenerCount: 2300000,
    viewerCount: 2300000,
    listenerCount: 123999,
    saveCount: 2222222,
  }, {
    id: '5e887ac47eed253091be10c1',
    songTitle: 'Close to me (Lại gần em)',
    streamCount: 1000000,
    thumbnail: 'https://photo-resize-zmp3.zmdcdn.me/w256_r1x1_jpeg/covers/d/c/dcadeb7fa3c0f086845cef885f15486f_1474268660.jpg',
    listenerCount: 2300000,
    viewerCount: 2300000,
    listenerCount: 123999,
    saveCount: 2222222,
  },
  {
    id: '5e887ac47eed253091be10c1',
    songTitle: 'Close to me (Lại gần em)',
    streamCount: 1000000,
    thumbnail: 'https://photo-resize-zmp3.zmdcdn.me/w256_r1x1_jpeg/covers/d/c/dcadeb7fa3c0f086845cef885f15486f_1474268660.jpg',
    listenerCount: 2300000,
    viewerCount: 2300000,
    listenerCount: 123999,
    saveCount: 2222222,
  }
];

const useCustomers = (page, rowsPerPage) => {
  return useMemo(
    () => {
      return applyPagination(data, page, rowsPerPage);
    },
    [page, rowsPerPage]
  );
};

const useCustomerIds = (customers) => {
  return useMemo(
    () => {
      return customers.map((customer) => customer.id);
    },
    [customers]
  );
};

const Page = () => {
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);
  const customers = useCustomers(page, rowsPerPage);
  const customersIds = useCustomerIds(customers);
  const customersSelection = useSelection(customersIds);

  const handlePageChange = useCallback(
    (event, value) => {
      setPage(value);
    },
    []
  );

  const handleRowsPerPageChange = useCallback(
    (event) => {
      setRowsPerPage(event.target.value);
    },
    []
  );

  return (
    <>
      <Head>
        <title>
          Music
        </title>
      </Head>
      <Box
        component="main"
        sx={{ flexGrow: 1 }}>
        <Container maxWidth="xl">
          <Stack spacing={3}>
            <Typography variant="h2">
              Music
            </Typography>
            <Stack
              sx={{ marginTop: '40px' }}
              direction="row"
              justifyContent="space-between"
              spacing={4}>
              <CustomersSearch />
            </Stack>
            <CustomersTable
              count={data.length}
              items={customers}
              onDeselectAll={customersSelection.handleDeselectAll}
              onDeselectOne={customersSelection.handleDeselectOne}
              onPageChange={handlePageChange}
              onRowsPerPageChange={handleRowsPerPageChange}
              onSelectAll={customersSelection.handleSelectAll}
              onSelectOne={customersSelection.handleSelectOne}
              page={page}
              rowsPerPage={rowsPerPage}
              selected={customersSelection.selected}
            />
          </Stack>
        </Container>
      </Box>
    </>
  );
};

Page.getLayout = (page) => (
  <DashboardLayout>
    {page}
  </DashboardLayout>
);

export default Page;

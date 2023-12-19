import { Box, Container, Stack, TextField, Typography } from "@mui/material";
import Head from "next/head";
import React from "react";
import { Layout as DashboardLayout } from "src/layouts/dashboard/layout";
import { useTheme } from "@mui/material/styles";
import SwipeableViews from "react-swipeable-views";
import { InventoryTable } from "src/sections/inventory/inventory-table";
import TablePagination from "@mui/material/TablePagination";
import { StyledTab, StyledTabs } from "src/sections/inventory/tab-inventory";
import { Scrollbar } from "src/components/scrollbar";

const inventoryDTOS = [
  {
    id: "5e887ac47eed253091be10cb",
    name: "Jeans Basics dáng Regular Straight",
    thumbnail:
      "https://media2.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2023/23CMCW.JE003.11_52.jpg",
    variants: ["Small", "White", "Hooded"],
    sku: "ROBE_001",
    incoming: 0,
    committed: 16,
    available: 240,
    createdAt: "2019-04-11T10:20:30Z",
  },
  {
    id: "5e887ac47eed253091be10cb",
    name: "Jeans Basics dáng Regular Straight",
    thumbnail:
      "https://media2.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2023/23CMCW.JE003.11_52.jpg",
    variants: ["Small", "White", "Hooded"],
    sku: "ROBE_001",
    incoming: 0,
    committed: 16,
    available: 240,
    createdAt: "2019-04-11T10:20:30Z",
  },
  {
    id: "5e887ac47eed253091be10cb",
    name: "Jeans Basics dáng Regular Straight",
    thumbnail:
      "https://media2.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2023/23CMCW.JE003.11_52.jpg",
    variants: ["Small", "White", "Hooded"],
    sku: "ROBE_001",
    incoming: 0,
    committed: 16,
    available: 240,
    createdAt: "2019-04-11T10:20:30Z",
  },
  {
    id: "5e887ac47eed253091be10cb",
    name: "Jeans Basics dáng Regular Straight",
    thumbnail:
      "https://media2.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2023/23CMCW.JE003.11_52.jpg",
    variants: ["Small", "White", "Hooded"],
    sku: "ROBE_001",
    incoming: 0,
    committed: 16,
    available: 240,
    createdAt: "2019-04-11T10:20:30Z",
  },
  {
    id: "5e887ac47eed253091be10cb",
    name: "Jeans Basics dáng Regular Straight",
    thumbnail:
      "https://media2.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2023/23CMCW.JE003.11_52.jpg",
    variants: ["Small", "White", "Hooded"],
    sku: "ROBE_001",
    incoming: 0,
    committed: 16,
    available: 240,
    createdAt: "2019-04-11T10:20:30Z",
  },
];

function TabPanel(props) {
  const { children, value, index, ...other } = props;

  return (
    <div>
      {value === index && <InventoryTable inventories={inventoryDTOS}>{children}</InventoryTable>}
    </div>
  );
}

const Page = () => {
  const theme = useTheme(); 
  const [value, setValue] = React.useState(0);
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(10);

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  const handleChangeIndex = (index) => {
    setValue(index);
  };


  return (
    <>
      <Head>
        <title>Inventory</title>
      </Head>

      <Box component="main" sx={{ flexGrow: 1 }}>
        <Container maxWidth="lg">
          
          <StyledTabs
            value={value}
            onChange={handleChange}
            aria-label="styled tabs example">
            <StyledTab label="Inventories" />
            <StyledTab label="Locations" />
            <StyledTab label="Transfers" />
            <StyledTab label="Suppliers" />
          </StyledTabs>

          <SwipeableViews
            axis={theme.direction === "rtl" ? "x-reverse" : "x"}
            index={value}
            onChangeIndex={handleChangeIndex}>
            <TabPanel value={value} index={0} dir={theme.direction} />
            <TabPanel value={value} index={1} dir={theme.direction} />
            <TabPanel value={value} index={2} dir={theme.direction} />
            <TabPanel value={value} index={3} dir={theme.direction} />
          </SwipeableViews>
          <Scrollbar>
            <TablePagination
              component="div"
              count={100}
              page={page}
              onPageChange={handleChangePage}
              rowsPerPage={rowsPerPage}
              onRowsPerPageChange={handleChangeRowsPerPage}
            />
          </Scrollbar>
        </Container>
      </Box>
    </>
  );
};

Page.getLayout = (page) => <DashboardLayout>{page}</DashboardLayout>;

export default Page;

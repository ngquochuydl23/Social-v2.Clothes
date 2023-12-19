import { Box, Container, Stack, TextField, Typography } from "@mui/material";
import Head from "next/head";
import React from "react";
import { Layout as DashboardLayout } from "src/layouts/dashboard/layout";
import SearchIcon from "@mui/icons-material/Search";
import { styled } from "@mui/material/styles";
import Paper from "@mui/material/Paper";
import Button from "@mui/material/Button";
import AppBar from "@mui/material/AppBar";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import { useTheme } from "@mui/material/styles";
import SwipeableViews from "react-swipeable-views";
import PropTypes from "prop-types";
import { InventoryTable } from "src/sections/inventory/inventory-table";
import TablePagination from "@mui/material/TablePagination";

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
  ,
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
  ,
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

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: "center",
  color: theme.palette.text.secondary,
}));

function a11yProps(index) {
  return {
    id: `action-tab-${index}`,
    "aria-controls": `action-tabpanel-${index}`,
  };
}

function TabPanel(props) {
  const { children, value, index, ...other } = props;

  return (
    <>
      {value === index && <InventoryTable inventories={inventoryDTOS}>{children}</InventoryTable>}
    </>
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

  const transitionDuration = {
    enter: theme.transitions.duration.enteringScreen,
    exit: theme.transitions.duration.leavingScreen,
  };

  console.log(page);
  console.log(rowsPerPage);
  return (
    <>
      <Head>
        <title>Inventory</title>
      </Head>

      <Box component="main" sx={{ flexGrow: 1 }}>
        <Container maxWidth="lg">
          <Box>
            <AppBar position="static" color="default">
              <Tabs
                value={value}
                onChange={handleChange}
                indicatorColor="primary"
                textColor="primary"
                variant="fullWidth"
                aria-label="action tabs example"
              >
                <Tab label="Inventory list" {...a11yProps(0)} />
                <Tab label="Locations" {...a11yProps(1)} />
                <Tab label="Transfer" {...a11yProps(2)} />
                <Tab label="Purchase orders" {...a11yProps(2)} />
              </Tabs>
            </AppBar>
          </Box>

          <Stack direction="row" spacing={3} justifyContent="space-between" alignItems="center">
            <Typography variant="h4">Inventory list</Typography>

            <Box sx={{ display: "flex", alignItems: "flex-end" }}>
              <SearchIcon sx={{ color: "action.active", mr: 1, my: 0.5 }} />
              <TextField id="input-with-sx" label="Find something" variant="standard" />
            </Box>
          </Stack>

          <SwipeableViews
            axis={theme.direction === "rtl" ? "x-reverse" : "x"}
            index={value}
            onChangeIndex={handleChangeIndex}
          >
            <TabPanel value={value} index={0} dir={theme.direction} />
            <TabPanel value={value} index={1} dir={theme.direction} />
            <TabPanel value={value} index={2} dir={theme.direction} />
            <TabPanel value={value} index={3} dir={theme.direction} />
          </SwipeableViews>

          <TablePagination
            component="div"
            count={100}
            page={page}
            onPageChange={handleChangePage}
            rowsPerPage={rowsPerPage}
            onRowsPerPageChange={handleChangeRowsPerPage}
          />
        </Container>
      </Box>
    </>
  );
};

Page.getLayout = (page) => <DashboardLayout>{page}</DashboardLayout>;

export default Page;

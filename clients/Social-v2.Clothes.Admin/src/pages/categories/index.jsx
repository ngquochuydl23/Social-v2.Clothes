import Head from "next/head";
import ArrowUpOnSquareIcon from "@heroicons/react/24/solid/ArrowUpOnSquareIcon";
import ArrowDownOnSquareIcon from "@heroicons/react/24/solid/ArrowDownOnSquareIcon";
import PlusIcon from "@heroicons/react/24/solid/PlusIcon";
import {
  Box,
  Button,
  Container,
  Pagination,
  Stack,
  SvgIcon,
  Typography,
  Unstable_Grid2 as Grid,
} from "@mui/material";
import { Layout as DashboardLayout } from "src/layouts/dashboard/layout";
import { CompanyCard } from "src/sections/companies/company-card";
import { CompaniesSearch } from "src/sections/companies/companies-search";
import millify from "millify";
import { OverviewListenerInPeriod } from "src/sections/products/overview-listener-in-period";
import { OverviewListenerGender } from "src/sections/products/overview-listener-gender";
import { OverviewListenerAgeGroup } from "src/sections/products/overview-listener-age-group";
import { ProductTable } from "src/sections/products/product-table";
import { CategoryTable } from "src/sections/categories/CategoryTable";

const songs = [
  {
    id: "ao",
    name: "Áo",
    decription: "",
    isActive: true,
    handle: "/ao",
    createdAt: "2019-04-11T10:20:30Z",
  },
  {
    id: "ao-polo",
    name: "Áo Polo",
    decription: "",
    isActive: true,
    handle: "/ao-polo",
    parentCategoryID: "ao",
    createdAt: "2019-04-11T10:20:30Z",
  },
  {
    id: "ao-polo",
    name: "Áo Polo",
    decription: "",
    isActive: false,
    handle: "/ao-polo",
    createdAt: "2019-04-11T10:20:30Z",
  },
  {
    id: "ao-polo",
    name: "Áo Polo",
    decription: "",
    isActive: false,
    handle: "/ao-polo",
    createdAt: "2019-04-11T10:20:30Z",
  },
  {
    id: "ao-polo",
    name: "Áo Polo",
    decription: "",
    isActive: true,
    handle: "/ao-polo",
    createdAt: "2019-04-11T10:20:30Z",
  },
];

const Page = () => (
  <>
    <Head>
      <title>Category | Devias Kit</title>
    </Head>
    <Box component="main" sx={{ flexGrow: 1 }}>
      <Container maxWidth="lg">
        <Stack spacing={3}>
          <Typography variant="h4">Category</Typography>
          <CategoryTable categories={songs} />
        </Stack>
      </Container>
    </Box>
  </>
);

Page.getLayout = (page) => <DashboardLayout>{page}</DashboardLayout>;

export default Page;

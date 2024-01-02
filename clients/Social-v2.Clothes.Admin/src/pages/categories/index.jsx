import Head from "next/head";
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
import { CategoryTable } from "src/sections/categories/CategoryTable";
import React, { useState, useEffect } from "react";
import { getCategories } from "src/services/api/category-api";

const Page = () => {
  const [categories, setCategory] = useState([]);
  const [hierarchy, setHierarchy] = useState(Boolean(false));
  const [gender, setGender] = useState(0);

  useEffect(() => {
    getCategories(hierarchy, gender)
      .then((res) => setCategory(res))
      .catch((error) => console.log(error));
  }, []);

  return (
    <>
      <Head>
        <title>Category | Devias Kit</title>
      </Head>
      <Box component="main" sx={{ flexGrow: 1 }}>
        <Container maxWidth="lg">
          <Stack spacing={3}>
            <Typography variant="h4">Category</Typography>
            <CategoryTable categories={categories} />
          </Stack>
        </Container>
      </Box>
    </>
  );
};

Page.getLayout = (page) => <DashboardLayout>{page}</DashboardLayout>;

export default Page;

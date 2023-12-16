import Head from "next/head";
import {
  Box,
  Button,
  Container,
  Divider,
  FormControl,
  FormControlLabel,
  Grid,
  InputLabel,
  MenuItem,
  Select,
  Stack,
  Switch,
  TextField,
  Typography,
} from "@mui/material";
import { SettingsNotifications } from "src/sections/settings/settings-notifications";
import { SettingsPassword } from "src/sections/settings/settings-password";
import { Layout as DashboardLayout } from "src/layouts/dashboard/layout";
import { SettingSectionItem } from "src/sections/settings/setting-section-item";
import _ from "lodash";
import { Form, Formik, useFormik } from "formik";
import { Scrollbar } from "src/components/scrollbar";
import SelectCategories from "src/sections/products/create-new-product/select-categories";
import { useState } from "react";
import PickProductThumbnail from "src/sections/products/create-new-product/pick-product-thumbnail";

const categories = [
  {
    value: "ao-polo",
    label: "Áo Polo",
  },
  {
    value: "quan-jean",
    label: "Quần Jean",
  },
];

const CreateNewProduct = () => {
  const [handle, setHandle] = useState("");
  const formik = useFormik({
    initialValues: {
      name: "",
      description: "",
      isActive: true,
      handle: "",
      parentCategoryId: "",
    },
    onSubmit: (values) => {
      alert(JSON.stringify(values, null, 2));
      window.history.back();
    },
  });
  return (
    <>
      <Head>
        <title>New category</title>
      </Head>
      <Scrollbar>
        <Box component="main" sx={{ flexGrow: 1 }}>
          <Container maxWidth="lg">
            <Stack spacing={3}>
              <Typography variant="h4">Create new category</Typography>
              <form onSubmit={formik.handleSubmit}>
                <Stack marginTop={"20px"} direction="row" spacing="15px">
                  <TextField
                    required
                    fullWidth
                    onChange={(e) => {
                      formik.handleChange(e);
                      formik.setFieldValue("handle", e.target.value);
                      setHandle(e.target.value);
                    }}
                    value={formik.values.name}
                    id="name"
                    label="Title"
                  />
                </Stack>
                <Typography sx={{ marginY: "10px", width: "50%" }} variant="caption">
                  Give your category a short and clear title.
                </Typography>
                <TextField
                  sx={{ marginTop: "20px" }}
                  required
                  fullWidth
                  disabled
                  value={handle}
                  label="Handle"
                />
                <TextField
                  sx={{ marginTop: "20px" }}
                  required
                  fullWidth
                  multiline
                  rows={4}
                  id="description"
                  label="Description"
                  onChange={formik.handleChange}
                  value={formik.values.description}
                />
                <Typography sx={{ marginY: "10px", width: "50%" }} variant="caption">
                  Give your category a short and clear description. 120-160 characters is the
                  recommended length for search engines.
                </Typography>
                <Typography sx={{ marginY: "10px", width: "50%" }} variant="caption">
                  Give your category a short and clear description. 120-160 characters is the
                  recommended length for search engines.
                </Typography>
                <FormControlLabel
                  fullWidth
                  sx={{
                    width: "100%",
                    justifyContent: "space-between",
                    marginLeft: 0,
                    marginTop: "20px",
                  }}
                  control={
                    <Switch
                      onChange={formik.handleChange}
                      value={formik.values.isActive}
                      id="isGiftCard"
                      color="primary"
                    />
                  }
                  label={
                    <Box fullWidth>
                      <Typography variant="subtitle1">Status</Typography>
                      <Typography variant="caption">
                        When unchecked this product will be hidden out site.
                      </Typography>
                    </Box>
                  }
                  labelPlacement="start"
                />
                <Divider sx={{ marginY: "20px" }} />
                <FormControl
                  fullWidth
                  sx={{
                    width: "100%",
                    justifyContent: "space-between",
                    marginLeft: 0,
                    marginTop: "20px",
                  }}
                >
                  <InputLabel id="demo-simple-select-label">Parent Category</InputLabel>
                  <Select
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    value={formik.values.parentCategoryId}
                    label="Parent Category"
                    onChange={(e) => formik.setFieldValue("parentCategoryId", e.target.value)}
                  >
                    {categories.map((option) => (
                      <MenuItem key={option.value} value={option.value}>
                        {option.label}
                      </MenuItem>
                    ))}
                  </Select>
                  <Typography variant="caption">
                    Select parent category for one if available
                  </Typography>
                </FormControl>
                <Divider sx={{ marginY: "20px" }} />
                <Button
                  sx={{
                    borderRadius: "10px",
                    height: "50px",
                    marginY: "20px",
                  }}
                  variant="contained"
                  fullWidth
                  type="submit"
                >
                  Create Category
                </Button>
              </form>
            </Stack>
          </Container>
        </Box>
      </Scrollbar>
    </>
  );
};

CreateNewProduct.getLayout = (page) => <DashboardLayout>{page}</DashboardLayout>;

export default CreateNewProduct;

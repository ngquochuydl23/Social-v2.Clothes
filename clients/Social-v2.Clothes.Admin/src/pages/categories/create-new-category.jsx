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

const CreateNewProduct = () => {
  const [handle, setHandle] = useState("");
  const formik = useFormik({
    initialValues: {
      name: "",
      subtitle: "",
      description: "",
      isActive: true,
      handle: "",
      parentCategoryId: "",
    },
    onSubmit: (values) => {
      alert(JSON.stringify(values, null, 2));
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
                    value={formik.values.title}
                    id="title"
                    label="Title"
                  />
                  <TextField
                    required
                    fullWidth
                    id="subtitle"
                    label="Subtitle"
                    onChange={formik.handleChange}
                    value={formik.values.subtitle}
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
                      value={formik.values.isGiftCard}
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
                <SelectCategories
                  onReturnCategories={(categories) => {
                    formik.setFieldValue("categories", categories);
                  }}
                />
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

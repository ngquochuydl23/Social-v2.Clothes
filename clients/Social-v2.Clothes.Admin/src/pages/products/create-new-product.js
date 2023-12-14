import Head from 'next/head';
import { Box, Button, Container, Divider, FormControlLabel, Grid, MenuItem, Stack, Switch, TextField, Typography } from '@mui/material';
import { SettingsNotifications } from 'src/sections/settings/settings-notifications';
import { SettingsPassword } from 'src/sections/settings/settings-password';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import { SettingSectionItem } from 'src/sections/settings/setting-section-item';
import _ from 'lodash';
import { Form, Formik, useFormik } from 'formik';
import { Scrollbar } from 'src/components/scrollbar';
import SelectCategories from 'src/sections/products/create-new-product/select-categories';
import { useState } from 'react';
import PickProductThumbnail from 'src/sections/products/create-new-product/pick-product-thumbnail';

const collections = [
  {
    value: 'winter-2023',
    label: 'Winter 2023',
  },
  {
    value: 'spring-2024',
    label: 'Spring 2024',
  }
];

const CreateNewProduct = () => {
  const [handle, setHandle] = useState('');
  const formik = useFormik({
    initialValues: {
      title: '',
      subtitle: '',
      description: '',
      handle: '',
      isGiftCard: false,
      isDiscountable: false,
      collectionId: null,
      categories: [],
      thumbnail: null,
    },
    onSubmit: values => {
      alert(JSON.stringify(values, null, 2));
    },
  });
  return (
    (<>
      <Head>
        <title>
          New product
        </title>
      </Head>
      <Scrollbar>
        <Box
          component="main"
          sx={{ flexGrow: 1 }}>
          <Container maxWidth="lg">
            <Stack spacing={3}>
              <Typography variant="h4">
                Create new product
              </Typography>
              <form onSubmit={formik.handleSubmit}>
                <PickProductThumbnail
                  onReceiveThumbnail={(thumbnail) => formik.setFieldValue('thumbnail', thumbnail)} />
                <Stack
                  marginTop={"20px"}
                  direction="row"
                  spacing="15px">
                  <TextField
                    required
                    fullWidth
                    onChange={(e) => {
                      formik.handleChange(e);
                      formik.setFieldValue('handle', e.target.value);
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
                <Typography
                  sx={{ marginY: '10px', width: '50%' }}
                  variant='caption'>
                  Give your product a short and clear title.
                  50-60 characters is the recommended length for search engines.
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
                <Typography
                  sx={{ marginY: '10px', width: '50%' }}
                  variant='caption'>
                  Give your product a short and clear description.
                  120-160 characters is the recommended length for search engines.
                </Typography>
                <FormControlLabel
                  value="start"
                  fullWidth
                  sx={{
                    width: '100%',
                    justifyContent: 'space-between',
                    marginLeft: 0,
                    marginTop: '20px'
                  }}
                  control={<Switch
                    id="isDiscountable"
                    value={formik.values.isDiscountable}
                    onChange={formik.handleChange}
                    color="primary" />}
                  label={
                    <Box fullWidth>
                      <Typography variant='subtitle1'>Discountable</Typography>
                      <Typography variant='caption'>When unchecked discounts will not be applied to this product.</Typography>
                    </Box>
                  }
                  labelPlacement="start"
                />
                <Divider sx={{ marginTop: '20px' }} />
                <FormControlLabel
                  fullWidth
                  sx={{
                    width: '100%',
                    justifyContent: 'space-between',
                    marginLeft: 0,
                    marginTop: '20px'
                  }}
                  control={<Switch
                    onChange={formik.handleChange}
                    value={formik.values.isGiftCard}
                    id="isGiftCard"
                    color="primary" />}
                  label={
                    <Box fullWidth>
                      <Typography variant='subtitle1'>Gift card</Typography>
                      <Typography variant='caption'>When unchecked discounts will not be applied to this product.</Typography>
                    </Box>
                  }
                  labelPlacement="start"
                />
                <Divider sx={{ marginY: '20px' }} />
                <SelectCategories
                  onReturnCategories={(categories) => {
                    formik.setFieldValue('categories', categories);
                  }} />
                <Divider sx={{ marginY: '20px' }} />
                <Box>
                  <Typography variant='subtitle1'>Select collection (option)</Typography>
                  <Typography variant='caption'>When unchecked discounts will not be applied to this product.</Typography>
                  <TextField
                    sx={{ marginTop: '10px' }}
                    id="collectionId"
                    select
                    fullWidth
                    onChange={(e) => formik.setFieldValue('collectionId', e.target.value)}
                    placeholder='Please select collection'
                    label="Collection">
                    {collections.map((option) => (
                      <MenuItem
                        key={option.value}
                        value={option.value}>
                        {option.label}
                      </MenuItem>
                    ))}
                  </TextField>
                </Box>
                <Divider sx={{ marginY: '20px' }} />
                <Box>
                  <Typography variant='subtitle1'>Create product skus</Typography>
                  <Typography variant='caption'>Add skus of this product.
                    Offer your customers different options for price, color, format, size, shape, etc.</Typography>
                </Box>
                <Button
                  sx={{
                    borderRadius: '10px',
                    height: '50px',
                    marginY: '20px'
                  }}
                  variant='contained'
                  fullWidth
                  type='submit'>Create Product</Button>
              </form>
            </Stack>
          </Container>
        </Box>
      </Scrollbar>
    </>)
  )
};

CreateNewProduct.getLayout = (page) => (
  <DashboardLayout>
    {page}
  </DashboardLayout>
);

export default CreateNewProduct;
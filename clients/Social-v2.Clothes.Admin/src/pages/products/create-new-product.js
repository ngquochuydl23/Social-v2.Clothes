import Head from 'next/head';
import { Box, Button, Container, Divider, FormControlLabel, Grid, MenuItem, Stack, Switch, TextField, Typography } from '@mui/material';
import { SettingsNotifications } from 'src/sections/settings/settings-notifications';
import { SettingsPassword } from 'src/sections/settings/settings-password';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import { SettingSectionItem } from 'src/sections/settings/setting-section-item';
import _ from 'lodash';
import { Form, Formik } from 'formik';
import { Scrollbar } from 'src/components/scrollbar';
import SelectCategories from 'src/sections/products/create-new-product/select-categories';
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

const CreateNewProduct = () => (
  <>
    <Head>
      <title>
        New product | Devias Kit
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

            <Formik
              initialValues={{
                title: '',
                subtitle: '',
                description: '',
                handle: ''
              }}
              onSubmit={async (values) => {
                await new Promise((r) => setTimeout(r, 500));
                alert(JSON.stringify(values, null, 2));
              }}>
              <Form>
                <Stack>
                  <img
                    style={{
                      height: '150px',
                      width: '150px',
                      borderRadius: '10px'
                    }}
                    src='https://media2.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2023/23CMCW.JE003.11_52.jpg' />
                </Stack>

                <Stack
                  marginTop={"20px"}
                  direction="row"
                  spacing="15px">
                  <TextField
                    required
                    fullWidth
                    id="title"
                    label="Title"
                  />
                  <TextField
                    required
                    fullWidth
                    id="subtitle"
                    label="Subtitle"
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
                  id="handle"
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
                  control={<Switch color="primary" />}
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
                  value="start"
                  fullWidth
                  sx={{
                    width: '100%',
                    justifyContent: 'space-between',
                    marginLeft: 0,
                    marginTop: '20px'
                  }}
                  control={<Switch color="primary" />}
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
                  onReturnCategories={(categories) => { console.log(categories) }} />
                <Divider sx={{ marginY: '20px' }} />
                <Box>
                  <Typography variant='subtitle1'>Select collection (option)</Typography>
                  <Typography variant='caption'>When unchecked discounts will not be applied to this product.</Typography>
                  <TextField
                    sx={{ marginTop: '10px' }}
                    id="outlined-select-currency"
                    select
                    fullWidth
                    placeholder='Please select collection'
                    label="Collection"
                  >
                    {collections.map((option) => (
                      <MenuItem key={option.value} value={option.value}>
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
              </Form>
            </Formik>
          </Stack>
        </Container>
      </Box>
    </Scrollbar>
  </>
);

CreateNewProduct.getLayout = (page) => (
  <DashboardLayout>
    {page}
  </DashboardLayout>
);

export default CreateNewProduct;

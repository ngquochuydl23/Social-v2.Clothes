import Head from 'next/head';
import { Box, Container, Grid, Stack, Typography } from '@mui/material';
import { SettingsNotifications } from 'src/sections/settings/settings-notifications';
import { SettingsPassword } from 'src/sections/settings/settings-password';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import { SettingSectionItem } from 'src/sections/settings/setting-section-item';
import _ from 'lodash';


const menuSetting = [
  {
    title: 'Personal information',
    subtitle: 'Manage your own personal Medusa Profile',
    path: '/personal-information'
  },
  {
    title: 'Taxes',
    subtitle: 'Manage how taxes are calculated and shown in your store',
    path: '/taxes'
  },
  {
    title: 'Shipping & Delivery',
    subtitle: 'Choose where you ship and how much you charge for it',
    path: '/taxes'
  },
  {
    title: 'Regions',
    subtitle: 'Manage the markets that you will operate within',
    path: '/taxes'
  }
]

const Page = () => (
  <>
    <Head>
      <title>
        Settings | Devias Kit
      </title>
    </Head>
    <Box
      component="main"
      sx={{
        flexGrow: 1,
        py: 8
      }}
    >
      <Container maxWidth="lg">
        <Stack spacing={3}>
          <Typography variant="h4">
            Settings
          </Typography>
          <Typography variant="p">
            Manage the settings for your Social-v2.Clothes
          </Typography>
          <Grid
            container
            rowSpacing="20px"
            columnSpacing='20px'>
            {_.map(menuSetting, (item, id) => {
              return (
                <Grid
                  key={id}
                  item
                  xs={6}>
                  <SettingSectionItem
                    title={item.title}
                    subtitle={item.subtitle} />
                </Grid>
              )
            })}
          </Grid>
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

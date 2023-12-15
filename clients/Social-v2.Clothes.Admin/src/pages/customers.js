import { TabContext, TabPanel } from '@mui/lab';
import { Box, Stack, Typography, Unstable_Grid2 as Grid, Tab, styled, Tabs, Button, SvgIcon } from '@mui/material';
import React from 'react';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import ProfileBio from 'src/sections/profile/profile-bio';
import { indigo } from 'src/theme/colors';
import { createTypography } from 'src/theme/create-typography';

const StyledTabs = styled((props) => (
  <Tabs
    {...props}
    sx={{ paddingX: '50px' }}
    TabIndicatorProps={{ children: <span className="MuiTabs-indicatorSpan" /> }}
  />
))({
  '& .MuiTabs-indicator': {
    display: 'flex',
    justifyContent: 'center',
    backgroundColor: 'transparent',
  },
  '& .MuiTabs-indicatorSpan': {
    maxWidth: 40,
    height: '5px',
    width: '100%',
    backgroundColor: indigo.main,
  },
});

const StyledTab = styled((props) => (
  <Tab disableRipple {...props} />
))(({ theme }) => ({
  textTransform: 'uppercase',
  fontWeight: createTypography().button.fontWeight,
  fontSize: createTypography().button.fontSize,
  fontStyle: createTypography().button.fontStyle,
  marginRight: theme.spacing(1),
  color: 'rgba(0, 0, 0, 0.7)',
  '&.Mui-selected': {
    color: indigo.main,
  },
  '&.Mui-focusVisible': {
    backgroundColor: 'rgba(100, 95, 228, 0.32)',
  },
}));

const Page = () => {
  const [tab, setTab] = React.useState('0');

  const handleChangeTab = (event, newValue) => {
    setTab(newValue);
  };
  return (
    <>
      <title>
        Artist Profile
      </title>
      <Box
        component="main"
        sx={{ flexGrow: 1 }}>
        <Stack direction="column">
          <div style={{ display: 'flex', position: 'relative' }}>
            <img
              style={{
                aspectRatio: 3 / 1,
                objectFit: 'cover'
              }}
              width="100%"
              src='https://i.ytimg.com/vi/8sJl66EANuE/maxresdefault.jpg' />
            <div
              style={{
                height: '100%',
                width: '100%',
                backgroundImage: 'linear-gradient(to bottom, rgba(0, 0, 0, 0.1) , rgba(0, 0, 0, 0.8))',
                position: 'absolute',
                color: '#fff',
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'flex-end',
                padding: '50px'
              }}>
              <Typography
                variant='h4'>
                Artist
              </Typography>
              <Stack
                direction="row"
                alignItems="end"
                justifyContent="space-between">
                <Typography
                  variant='h1'>
                  {`Hoang Yen Chibi`}
                </Typography>
                <Button
                  sx={{
                    color: '#fff',
                    borderColor: '#fff',
                    borderRadius: '7.5px',
                    height: '40px',
                    width: '150px',
                    borderRadius: '30px'
                  }}
                  startIcon={(
                    <SvgIcon fontSize="small">

                    </SvgIcon>
                  )}
                  variant="outlined">
                  Add
                </Button>
              </Stack>
            </div>
          </div>
          <TabContext value={tab}>
            <StyledTabs
              value={tab}
              onChange={handleChangeTab}
              aria-label="styled tabs example">
              <StyledTab label="Overview" value="0" />
              <StyledTab label="About" value="1" />
              <StyledTab label="Concerts" value="3" />
            </StyledTabs>
            <TabPanel value="0">Item One</TabPanel>
            <TabPanel value="1">
              <ProfileBio artistId={1} />
            </TabPanel>
            <TabPanel value="3">Item Three</TabPanel>
          </TabContext>
        </Stack>
      </Box>
    </>
  )
};

Page.getLayout = (page) => (
  <DashboardLayout hideHeader>
    {page}
  </DashboardLayout>
);

export default Page;


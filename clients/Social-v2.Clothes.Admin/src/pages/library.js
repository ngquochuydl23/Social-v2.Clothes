import React, { useCallback, useMemo, useState } from 'react';
import Head from 'next/head';
import { Box, Container, Stack, Tab, Tabs, Typography, styled } from '@mui/material';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import { indigo } from 'src/theme/colors';
import { TabContext, TabPanel } from '@mui/lab';
import { createTypography } from 'src/theme/create-typography';
import SongLibrarySection, { SongLibraryTable } from 'src/sections/library/song-library';

const songs = [
  {
    id: '5e887ac47eed253091be10cb',
    songTitle: 'Close to me (Lại gần em)',
    thumbnail: 'https://photo-resize-zmp3.zmdcdn.me/w256_r1x1_jpeg/covers/d/c/dcadeb7fa3c0f086845cef885f15486f_1474268660.jpg',
    listenerCount: 2300000,
    duration: 243000,
    album: '#Ngunglamban',
    createdAt: '2019-04-11T10:20:30Z'
  },
  {
    id: '5e887ac47eed253091be10cb',
    songTitle: 'Close to me (Lại gần em)',
    thumbnail: 'https://photo-resize-zmp3.zmdcdn.me/w256_r1x1_jpeg/covers/d/c/dcadeb7fa3c0f086845cef885f15486f_1474268660.jpg',
    listenerCount: 2300000,
    duration: 243000,
    album: '#Ngunglamban',
    createdAt: '2019-04-11T10:20:30Z'
  },
  {
    id: '5e887ac47eed253091be10cb',
    songTitle: 'Close to me (Lại gần em)',
    thumbnail: 'https://photo-resize-zmp3.zmdcdn.me/w256_r1x1_jpeg/covers/d/c/dcadeb7fa3c0f086845cef885f15486f_1474268660.jpg',
    listenerCount: 2300000,
    duration: 243000,
    album: '#Ngunglamban',
    createdAt: '2019-04-11T10:20:30Z'
  },
  {
    id: '5e887ac47eed253091be10cb',
    songTitle: 'Close to me (Lại gần em)',
    thumbnail: 'https://photo-resize-zmp3.zmdcdn.me/w256_r1x1_jpeg/covers/d/c/dcadeb7fa3c0f086845cef885f15486f_1474268660.jpg',
    listenerCount: 2300000,
    duration: 243000,
    album: '#Ngunglamban',
    createdAt: '2019-04-11T10:20:30Z'
  },
  {
    id: '5e887ac47eed253091be10cb',
    songTitle: 'Close to me (Lại gần em)',
    thumbnail: 'https://photo-resize-zmp3.zmdcdn.me/w256_r1x1_jpeg/covers/d/c/dcadeb7fa3c0f086845cef885f15486f_1474268660.jpg',
    listenerCount: 2300000,
    duration: 243000,
    album: '#Ngunglamban',
    createdAt: '2019-04-11T10:20:30Z'
  },
  {
    id: '5e887ac47eed253091be10cb',
    songTitle: 'Close to me (Lại gần em)',
    thumbnail: 'https://photo-resize-zmp3.zmdcdn.me/w256_r1x1_jpeg/covers/d/c/dcadeb7fa3c0f086845cef885f15486f_1474268660.jpg',
    listenerCount: 2300000,
    duration: 243000,
    album: '#Ngunglamban',
    createdAt: '2019-04-11T10:20:30Z'
  }
];

const StyledTabs = styled((props) => (
  <Tabs
    {...props}
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
      <Head>
        <title>
          Music
        </title>
      </Head>
      <Box
        component="main"
        sx={{ flexGrow: 1 }}>
        <Container maxWidth="xl">
          <Stack spacing={3}>
            <Typography variant="h2">
              Library
            </Typography>
            <TabContext value={tab}>
              <StyledTabs
                value={tab}
                onChange={handleChangeTab}
                aria-label="styled tabs example">
                <StyledTab label="Songs" value="0" />
                <StyledTab label="Albums" value="1" />
                <StyledTab label="PLaylists" value="2" />
              </StyledTabs>
              <TabPanel
                value="0"
                sx={{ paddingX: 0 }}>
                <SongLibraryTable songs={songs} />
              </TabPanel>
              <TabPanel
                value="1"
                sx={{ paddingX: 0 }}>

              </TabPanel>
              <TabPanel
                value="2"
                sx={{ paddingX: 0 }}>

              </TabPanel>
            </TabContext>
          </Stack>
        </Container>
      </Box>
    </>
  );
};

Page.getLayout = (page) => (
  <DashboardLayout>
    {page}
  </DashboardLayout>
);

export default Page;

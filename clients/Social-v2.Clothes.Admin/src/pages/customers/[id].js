import { TabContext, TabPanel } from '@mui/lab';
import { Box, Stack, Typography, Unstable_Grid2 as Grid, Tab, styled, Tabs, Button, SvgIcon } from '@mui/material';
import React from 'react';
import { Layout as DashboardLayout } from 'src/layouts/dashboard/layout';
import ProfileBio from 'src/sections/profile/profile-bio';
import { indigo } from 'src/theme/colors';
import { createTypography } from 'src/theme/create-typography';

const Page = () => {
    return (
        <>
            <title>
                Customer
            </title>
            <Box
                component="main"
                sx={{ flexGrow: 1 }}>
                <Stack direction="column">


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


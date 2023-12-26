import { Box, Container, Stack, Typography } from "@mui/material";
import React, { useState } from "react";
import { Outlet } from "react-router-dom";
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';

function a11yProps(index) {
    return {
        id: `vertical-tab-${index}`,
        'aria-controls': `vertical-tabpanel-${index}`,
    };
}

const tabSx = {
    width: '100%',
    fontWeight: '500',
    textTransform: 'none',
    fontSize: '15px',
    fontFamily: 'Poppins',
    alignItems: 'flex-start',
    '&.Mui-selected': {
        color: 'white',
        backgroundColor: 'black',
        borderRadius: '7.5px'
    },
}

const AccountLayout = () => {
    const [value, setValue] = useState(0);

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };
    return (
        <Container>
            <Stack direction="row">
                <Tabs
                    indicatorColor="black"
                    orientation="vertical"
                    variant="scrollable"
                    value={value}
                    onChange={handleChange}
                    aria-label="Vertical tabs example"
                    sx={{
                        width: '400px',
                        mt: '56px',
                        mr: '100px',
                    }} >
                    <Tab
                        href="/account/info"
                        label="Personal Information" {...a11yProps(0)}
                        sx={tabSx} />
                    <Tab
                        href="/account/shipping-address"
                        label="Shipping Addresses" {...a11yProps(1)} sx={tabSx} />
                    <Tab label="Ordered History" {...a11yProps(2)} sx={tabSx} />
                    <Tab label="Vouchers" {...a11yProps(2)} sx={tabSx} />
                </Tabs>
                <Outlet />
            </Stack>

        </Container>
    );
};

export default AccountLayout;

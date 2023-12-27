import { Box, Container, Stack, Typography } from "@mui/material";
import React, { useState } from "react";
import { Outlet, useLocation } from "react-router-dom";
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';

const tabSx = {
    fontWeight: '500',
    padding: 0,
    textTransform: 'none',
    alignItems: 'flex-start',
    '&.Mui-selected': {
        color: 'white',
        backgroundColor: 'black',
        borderRadius: '7.5px'
    },
    '&.MuiTab-root': {
        width: '100%',
        marginLeft: 0,
        paddingLeft: '15px'
    },
}


const accountRoutes = [
    {
        label: "Thông tin cá nhân",
        path: "/account/info"
    },
    {
        label: "Địa chỉ giao hàng",
        path: "/account/shipping-address"
    },
    {
        label: "Đơn hàng của tôi",
        path: "/account/my-order"
    },
    {
        label: "Ví Vouchers",
        path: "/account/my-vouchers"
    }
]
const AccountLayout = () => {
    const [value, setValue] = useState(0);
    const { pathname } = useLocation()
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
                    value={accountRoutes.findIndex((route) => route.path === pathname)}
                    onChange={handleChange}
                    sx={{
                        width: '400px',
                        mt: '56px',
                        mr: '100px',
                    }}>
                    {accountRoutes.map((route) => (
                        <Tab
                            href={route.path}
                            label={route.label}
                            sx={tabSx} />
                    ))}
                </Tabs>
                <Outlet />
            </Stack>
        </Container>
    );
};

export default AccountLayout;
import { Box, Container, Stack, TextField, Typography } from "@mui/material";
import Head from "next/head";
import React, { useState } from "react";
import { useEffect } from "react";
import { Layout as DashboardLayout } from "src/layouts/dashboard/layout";
import { InventoryTable } from "src/sections/inventory/inventory-table";
import { getInventories } from "src/services/api/inventory-api";

const Page = () => {
    const [inventories, setInventories] = useState([]);
    useEffect(() => {
        getInventories({})
            .then((res) => {
                setInventories(res)
            })
            .catch((err) => console.log(err))
    }, [])


    return (
        <>
            <Head>
                <title>Inventory</title>
            </Head>
            <Box
                component="main"
                sx={{ flexGrow: 1 }}>
                <Container maxWidth="lg">
                    <Stack spacing={3}>
                        <Typography variant="h4">
                            Inventory List
                        </Typography>
                        <InventoryTable
                            inventories={inventories} />
                    </Stack>
                </Container>
            </Box>
        </>
    );
};

Page.getLayout = (page) => <DashboardLayout>{page}</DashboardLayout>;

export default Page;

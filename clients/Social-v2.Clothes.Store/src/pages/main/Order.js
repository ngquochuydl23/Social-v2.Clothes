import React from "react";
import { Box, Typography } from "@mui/material";

const Order = () => {
  return (
    <Box py="15px" sx={{ width: '100%' }}>
      <Typography
        mb="20px"
        fontWeight="800"
        variant="h4">{`My Orders`}</Typography>
    </Box >
  );
};

export default Order;

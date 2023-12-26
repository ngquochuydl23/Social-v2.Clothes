import React, { useState } from "react";
import {
  Card,
  CardContent,
  CardActions,
  Typography,
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogContentText,
  DialogActions,
  Chip,
  CardHeader,
  IconButton,
  Avatar,
  Grid,
} from "@mui/material";
import FiberManualRecordIcon from "@mui/icons-material/FiberManualRecord";
import MoreVertIcon from "@mui/icons-material/MoreVert";

const ordersData = [
  {
    id: 1,
    product: "Sản phẩm 1",
    productImage:
      "https://media2.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/May2022/DSC01382-copy.jpg",
    total: 100,
    date: "2023-01-01",
    status: "pending",
  },
  {
    id: 2,
    product: "Sản phẩm 2",
    productImage:
      "https://media2.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/May2022/DSC01382-copy.jpg",
    total: 150,
    date: "2023-01-02",
    status: "confirmed",
  },
  {
    id: 3,
    product: "Sản phẩm 3",
    productImage:
      "https://media2.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/May2022/DSC01382-copy.jpg",
    total: 200,
    date: "2023-01-03",
    status: "canceled",
  },
  // Thêm dữ liệu đơn hàng khác tại đây...
];

const Order = () => {
  const [selectedOrder, setSelectedOrder] = useState(null);

  const handleViewDetails = (order) => {
    setSelectedOrder(order);
  };

  const handleCloseDetails = () => {
    setSelectedOrder(null);
  };

  return (
    <>
      {ordersData.map((order) => (
        <React.Fragment key={order.id}>
          <Card>
            <CardHeader
              action={
                <IconButton aria-label="settings">
                  <MoreVertIcon />
                </IconButton>
              }
              title={"Fullfillment " + order.id}
            />

            <CardContent>
              <Grid container spacing={2} alignItems="center">
                <Grid item xs={1}>
                  <div
                    style={{ display: "flex", justifyContent: "flex-start" }}
                  >
                    <img src={order.productImage} alt={order.product} width={100} height={100}/>
                  </div>
                </Grid>
                <Grid item xs={7}>
                  <Typography variant="h5" component="div">
                    {order.product}
                  </Typography>
                  <Typography color="text.secondary">
                    {`Total: $${order.total} - Date: ${order.date}`}
                  </Typography>
                </Grid>
                <Grid item xs={4}>
                  <div style={{ display: "flex", justifyContent: "flex-end" }}>
                    <Chip
                      icon={
                        <FiberManualRecordIcon fontSize="4" color="warning" />
                      }
                      variant="dot"
                      label="awaits fulfilled"
                    />
                  </div>
                </Grid>
              </Grid>
            </CardContent>
            <CardActions>
              <Button size="small" onClick={() => handleViewDetails(order)}>
                View Details
              </Button>
            </CardActions>
          </Card>
          <br />
        </React.Fragment>
      ))}

      <Dialog open={Boolean(selectedOrder)} onClose={handleCloseDetails}>
        <DialogTitle>Order Details</DialogTitle>
        <DialogContent>
          {selectedOrder && (
            <div>
              <DialogContentText>
                Customer: {selectedOrder.customer}
              </DialogContentText>
              <DialogContentText>
                Total: ${selectedOrder.total}
              </DialogContentText>
              <DialogContentText>Date: {selectedOrder.date}</DialogContentText>
              {/* Thêm thông tin khác của đơn hàng tại đây... */}
            </div>
          )}
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseDetails}>Close</Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default Order;

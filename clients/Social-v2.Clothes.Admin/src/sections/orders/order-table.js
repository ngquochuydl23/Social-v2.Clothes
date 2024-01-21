import PropTypes from "prop-types";
import {
    Box,
    Button,
    Drawer,
    Popover,
    Stack,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TablePagination,
    TableRow,
    Typography,
} from "@mui/material";
import { Scrollbar } from "src/components/scrollbar";
import millify from "millify";
import { useState } from "react";
import LocationCityIcon from '@mui/icons-material/LocationCity';
import CloseIcon from '@mui/icons-material/Close';
import Link from "next/link";
import TuneIcon from '@mui/icons-material/Tune';
import OrderFilterPopover from "./order-filter-popover";

export const OrderTable = (props) => {
    const {
        count = 0,
        orders = [],
        onDeselectAll,
        onDeselectOne,
        onPageChange = () => { },
        onRowsPerPageChange,
        onSelectAll,
        onSelectOne,
        page = 0,
        rowsPerPage = 0,
        selected = [],
    } = props;
    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);
    const id = open ? 'simple-popover' : undefined;

    const [inventoryDrawer, setInventoryDrawer] = useState(null);

    const handleChangePage = (event, newPage) => {
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (event) => {

    };

    const handleChangeIndex = (index) => {

    };

    const handleChange = (event) => {
        setAge(event.target.value);
    };

    return (
        <Stack>
            <div style={{
                display: 'flex',
                flexDirection: 'row',
                marginTop: '15px',
                marginBottom: '15px',
                justifyContent: 'space-between'
            }}>
                <Button
                    sx={{
                        borderRadius: '10px',
                        height: '30px',
                        borderColor: '#d9d9d9',
                        color: '#696969'
                    }}
                    onClick={(event) => setAnchorEl(event.currentTarget)}
                    size="medium"
                    variant="outlined"
                    startIcon={<TuneIcon />}
                    fullWidth={false}>
                    Filter
                </Button>
                <Popover
                    id={id}
                    open={open}
                    anchorEl={anchorEl}
                    onClose={() => setAnchorEl(null)}
                    anchorOrigin={{
                        vertical: 'bottom',
                        horizontal: 'left',
                    }}
                    PaperProps={{ sx: { width: '250px', padding: '10px' } }}
                    transformOrigin={{
                        vertical: 'top',
                        horizontal: 'left',
                    }}>
                    <OrderFilterPopover />
                </Popover>
            </div>
            <Scrollbar>
                <Box
                    sx={{
                        flex: 1,
                        display: 'flex',
                        flexGrow: 1,
                        flexDirection: 'column'
                    }}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Order No.</TableCell>
                                <TableCell>Created At</TableCell>
                                <TableCell>Customers</TableCell>
                                <TableCell>Fulfillment</TableCell>
                                <TableCell>Status</TableCell>
                                <TableCell>Total</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {orders.map((order) => {
                                return (
                                    <TableRow
                                        hover
                                        sx={{ textDecoration: 'none' }}
                                        component={Link}
                                        href={'./orders/' + order.orderNo}
                                        key={order.orderNo}>
                                        <TableCell>{order.orderNo}</TableCell>
                                        <TableCell>{order.canceledAt}</TableCell>
                                        <TableCell>{`Nguyễn Thị Thanh Phương`}</TableCell>
                                        <TableCell>{order.fulfillmentStatus}</TableCell>
                                        <TableCell>{order.status}</TableCell>
                                        <TableCell>{order.total}</TableCell>
                                    </TableRow>
                                );
                            })}
                        </TableBody>
                    </Table>
                </Box>
            </Scrollbar>
            <TablePagination
                component="div"
                count={100}
                page={page}
                onPageChange={handleChangePage}
                rowsPerPage={rowsPerPage}
                onRowsPerPageChange={handleChangeRowsPerPage}
            />
            <Drawer
                anchor="right"
                sx={{ maxWidth: '200px' }}
                open={inventoryDrawer !== null}
                onClose={() => setInventoryDrawer(null)}>
                <Stack
                    sx={{ mt: '10px' }}
                    alignItems="center"
                    direction="row">
                    <Button
                        onClick={() => setInventoryDrawer(null)}
                        sx={{ color: 'black' }}
                        variant='text'>
                        <CloseIcon />
                    </Button>
                    <Typography
                        fontSize="20px"
                        variant='h4'>
                        Adjust availablity
                    </Typography>
                </Stack>
            </Drawer>
        </Stack >
    );
};

OrderTable.propTypes = {
    count: PropTypes.number,
    inventories: PropTypes.array,
    onDeselectAll: PropTypes.func,
    onDeselectOne: PropTypes.func,
    onPageChange: PropTypes.func,
    onRowsPerPageChange: PropTypes.func,
    onSelectAll: PropTypes.func,
    onSelectOne: PropTypes.func,
    page: PropTypes.number,
    rowsPerPage: PropTypes.number,
    selected: PropTypes.array,
};

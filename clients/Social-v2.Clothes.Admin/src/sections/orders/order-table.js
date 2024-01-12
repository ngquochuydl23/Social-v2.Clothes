import PropTypes from "prop-types";
import {
    Avatar,
    Box,
    Button,
    Drawer,
    FormControl,
    InputLabel,
    MenuItem,
    Popover,
    Select,
    Stack,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TablePagination,
    TableRow,
    TextField,
    Typography,
} from "@mui/material";
import { Scrollbar } from "src/components/scrollbar";
import millify from "millify";
import { useState } from "react";
import LocationCityIcon from '@mui/icons-material/LocationCity';
import CloseIcon from '@mui/icons-material/Close';

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
            <div
                style={{
                    display: "flex",
                    flexDirection: "row",
                    marginTop: "15px",
                    marginBottom: "15px",
                    justifyContent: "space-between",
                }}>
                {" "}
            </div>
            <Scrollbar>
                <Box
                    sx={{
                        flex: 1,
                        display: 'flex',
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

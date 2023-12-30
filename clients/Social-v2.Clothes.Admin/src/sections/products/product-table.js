import PropTypes from 'prop-types';
import {
    Avatar,
    Box,
    Button,
    Popover,
    Stack,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    Typography
} from '@mui/material';
import { Scrollbar } from 'src/components/scrollbar';
import millify from "millify";
import TuneIcon from '@mui/icons-material/Tune';
import AddIcon from '@mui/icons-material/Add';
import Link from 'next/link'
import { useState } from 'react';

export const ProductTable = (props) => {
    const {
        count = 0,
        products = [],
        onDeselectAll,
        onDeselectOne,
        onPageChange = () => { },
        onRowsPerPageChange,
        onSelectAll,
        onSelectOne,
        page = 0,
        rowsPerPage = 0,
        selected = []
    } = props;



    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);
    const id = open ? 'simple-popover' : undefined;

    return (

        <Stack>
            <div style={{
                display: 'flex',
                flexDirection: 'row',
                marginTop: '15px',
                marginBottom: '15px',
                justifyContent: 'space-between'
            }}>
                <div>
                    <Button
                        sx={{
                            borderRadius: '4px',
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
                        <Stack
                            sx={{
                                width: '100%',
                                backgroundColor: 'white'
                            }}>
                            abc
                            <Button
                                sx={{
                                    fontSize: '14px',
                                    height: '30px',
                                    borderRadius: '4px',
                                }}
                                variant="contained"
                                fullWidth={false}>
                                Apply
                            </Button>
                        </Stack>
                    </Popover>
                    <Button
                        sx={{
                            marginLeft: '10px',
                            borderRadius: '4px',
                            borderColor: '#d9d9d9',
                            color: '#696969'
                        }}
                        variant="outlined"
                        fullWidth={false}>
                        Unpublished
                    </Button>
                </div>
                <div>
                    <Button
                        href='products/create-new-product'
                        startIcon={<AddIcon />}
                        sx={{
                            marginLeft: '10px',
                            borderRadius: '4px',
                        }}
                        variant="contained"
                        fullWidth={false}>
                        New product
                    </Button>
                </div>
            </div>
            <Scrollbar>
                <Box sx={{ minWidth: 800 }}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell padding="checkbox">
                                    #
                                </TableCell>
                                <TableCell>
                                    Product
                                </TableCell>
                                <TableCell>
                                    Collection
                                </TableCell>
                                <TableCell>
                                    Status
                                </TableCell>
                                <TableCell>
                                    Inventory
                                </TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {products.map((product, index) => {
                                const isSelected = selected.includes(product.id);
                                return (
                                    <TableRow
                                        hover
                                        component={Link}
                                        href={"./products/" + product.id}
                                        sx={{ textDecoration: 'none' }}
                                        key={product.id}
                                        selected={isSelected}>
                                        <TableCell padding="checkbox">
                                            {index + 1}
                                        </TableCell>
                                        <TableCell>
                                            <Stack
                                                alignItems="center"
                                                direction="row"
                                                spacing={2}>
                                                <img
                                                    alt={product.title}
                                                    src={"https://clothes-dev.social-v2.com" + product.thumbnail}
                                                    style={{ height: '45px', width: '45px' }} />
                                                <Typography
                                                    sx={{ fontWeight: '600' }}
                                                    variant="subtitle2">
                                                    {product.title}
                                                </Typography>
                                            </Stack>
                                        </TableCell>
                                        <TableCell>
                                            {product.collection ? product.collection.title : `-`}
                                        </TableCell>
                                        <TableCell>
                                            {product.collection ? product.status : `-`}
                                        </TableCell>
                                        <TableCell>
                                            {product.listenerCount ? millify(product.listenerCount) : `-`}
                                        </TableCell>

                                    </TableRow>

                                );
                            })}
                        </TableBody>
                    </Table>
                </Box>
            </Scrollbar>
        </Stack >
    );
};

ProductTable.propTypes = {
    count: PropTypes.number,
    products: PropTypes.array,
    onDeselectAll: PropTypes.func,
    onDeselectOne: PropTypes.func,
    onPageChange: PropTypes.func,
    onRowsPerPageChange: PropTypes.func,
    onSelectAll: PropTypes.func,
    onSelectOne: PropTypes.func,
    page: PropTypes.number,
    rowsPerPage: PropTypes.number,
    selected: PropTypes.array
};

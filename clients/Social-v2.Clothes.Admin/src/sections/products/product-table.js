import PropTypes from 'prop-types';
import {
  Avatar,
  Box,
  Button,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TablePagination,
  TableRow,
  Typography
} from '@mui/material';
import { Scrollbar } from 'src/components/scrollbar';
import millify from "millify";
import format from 'format-duration';
import moment from 'moment/moment';
import { Filter } from '@mui/icons-material';
import TuneIcon from '@mui/icons-material/Tune';
import AddIcon from '@mui/icons-material/Add';

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
            size="medium"
            variant="outlined"
            startIcon={<TuneIcon />}
            fullWidth={false}>
            Filter
          </Button>
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
                          alt={product.name}
                          src={product.thumbnail}
                          style={{ height: '45px', width: '45px' }} />
                        <Typography
                          sx={{ fontWeight: '600' }}
                          variant="subtitle2">
                          {product.name}
                        </Typography>
                      </Stack>
                    </TableCell>
                    <TableCell>
                      {product.collection ? product.collection : `-`}
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
    </Stack>
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

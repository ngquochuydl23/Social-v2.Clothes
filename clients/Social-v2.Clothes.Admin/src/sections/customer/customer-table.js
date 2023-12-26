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
import Link from 'next/link';

export const CustomerTable = (props) => {
  const {
    count = 0,
    customers = [],
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
      <Scrollbar>
        <Box sx={{ minWidth: 800 }}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell padding="checkbox">
                  #
                </TableCell>
                <TableCell>
                  Name
                </TableCell>
                <TableCell>
                  Email
                </TableCell>
                <TableCell>
                  Orders
                </TableCell>
                <TableCell>
                  Date added
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {customers.map((customer, index) => {
                const isSelected = selected.includes(customer.id);
                return (
                  <TableRow
                    hover
                    component={Link}
                    sx={{ textDecoration: 'none' }}
                    href={"/customers/" + customer.id}
                    key={customer.id}
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
                          alt={customer.name}
                          src={customer.avatar || ""}
                          style={{
                            borderRadius: '100px',
                            height: '45px',
                            width: '45px'
                          }} />
                        <Typography
                          sx={{ fontWeight: '600' }}
                          variant="subtitle2">
                          {customer.name}
                        </Typography>
                      </Stack>
                    </TableCell>
                    <TableCell>
                      {customer.email}
                    </TableCell>
                    <TableCell>
                      {customer.orders}
                    </TableCell>
                    <TableCell>
                      {moment(customer.createdAt).format("MMM Do YY")}
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

CustomerTable.propTypes = {
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

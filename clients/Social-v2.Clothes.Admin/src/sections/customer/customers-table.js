import PropTypes from 'prop-types';
import { format } from 'date-fns';
import {
  Avatar,
  Box,
  Card,
  Checkbox,
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
import { getInitials } from 'src/utils/get-initials';
import millify from "millify";

export const CustomersTable = (props) => {
  const {
    count = 0,
    items = [],
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

  const selectedSome = (selected.length > 0) && (selected.length < items.length);
  const selectedAll = (items.length > 0) && (selected.length === items.length);

  return (
    <Scrollbar>
      <Box sx={{ minWidth: 800 }}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell padding="checkbox">
                #
              </TableCell>
              <TableCell>
                Title
              </TableCell>
              <TableCell>
                Listeners
              </TableCell>
              <TableCell>
                Views
              </TableCell>
              <TableCell>
                Streamers
              </TableCell>
              <TableCell>
                Saves
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {items.map((song, index) => {
              const isSelected = selected.includes(song.id);

              return (
                <TableRow
                  hover
                  key={song.id}
                  selected={isSelected}
                >
                  <TableCell padding="checkbox">
                    {index + 1}
                  </TableCell>
                  <TableCell>
                    <Stack
                      alignItems="center"
                      direction="row"
                      spacing={2}>
                      <img
                        alt={song.songTitle}
                        src={song.thumbnail}
                        style={{ height: '45px', width: '45px' }} />
                      <Typography
                        sx={{ fontWeight: '600' }}
                        variant="subtitle2">
                        {song.songTitle}
                      </Typography>
                    </Stack>
                  </TableCell>
                  <TableCell>
                    {millify(song.streamCount)}
                  </TableCell>
                  <TableCell>
                    {millify(song.listenerCount)}
                  </TableCell>
                  <TableCell>
                    {millify(song.viewerCount)}
                  </TableCell>
                  <TableCell>
                    {millify(song.saveCount)}
                  </TableCell>
                </TableRow>
              );
            })}
          </TableBody>
        </Table>
      </Box>
    </Scrollbar>
  );
};

CustomersTable.propTypes = {
  count: PropTypes.number,
  items: PropTypes.array,
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

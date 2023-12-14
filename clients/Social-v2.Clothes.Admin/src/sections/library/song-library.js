import PropTypes from 'prop-types';
import {
  Avatar,
  Box,
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

export const SongLibraryTable = (props) => {
  const {
    count = 0,
    songs = [],
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
                Album
              </TableCell>
              <TableCell>
                Listeners
              </TableCell>
              <TableCell>
                Duration
              </TableCell>
              <TableCell>
                Created At
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {songs.map((song, index) => {
              const isSelected = selected.includes(song.id);
              return (
                <TableRow
                  hover
                  key={song.id}
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
                    {song.album ? millify(song.album) : `-`}
                  </TableCell>
                  <TableCell>
                    {song.listenerCount ? millify(song.listenerCount) : `-`}
                  </TableCell>
                  <TableCell>
                    {song.duration ? format(song.duration) : `-`}
                  </TableCell>
                  <TableCell>
                    {moment(song.createdAt).format("DD/MM/yyyy")}
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

SongLibraryTable.propTypes = {
  count: PropTypes.number,
  songs: PropTypes.array,
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

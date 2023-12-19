import PropTypes from "prop-types";
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
  Typography,
} from "@mui/material";
import { Scrollbar } from "src/components/scrollbar";
import millify from "millify";
import format from "format-duration";
import moment from "moment/moment";
import { Filter } from "@mui/icons-material";
import TuneIcon from "@mui/icons-material/Tune";
import AddIcon from "@mui/icons-material/Add";

export const InventoryTable = (props) => {
  const {
    count = 0,
    inventories = [],
    onDeselectAll,
    onDeselectOne,
    onPageChange = () => {},
    onRowsPerPageChange,
    onSelectAll,
    onSelectOne,
    page = 0,
    rowsPerPage = 0,
    selected = [],
  } = props;

  return (
    <Stack>
      <div
        style={{
          display: "flex",
          flexDirection: "row",
          marginTop: "15px",
          marginBottom: "15px",
          justifyContent: "space-between",
        }}
      >
        {" "}
      </div>
      <Scrollbar>
        <Box sx={{ minWidth: 800 }}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell padding="checkbox">Id</TableCell>
                <TableCell>Item</TableCell>
                <TableCell>Variants</TableCell>
                <TableCell>Sku</TableCell>
                <TableCell>Incoming</TableCell>
                <TableCell>Committed</TableCell>
                <TableCell>Available</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {inventories.map((inventory, index) => {
                const isSelected = selected.includes(inventory.id);
                console.log(inventory.variants);
                return (
                  <TableRow hover key={inventory.id} selected={isSelected}>
                    <TableCell padding="checkbox">{index + 1}</TableCell>
                    <TableCell>
                      <Stack alignItems="center" direction="row" spacing={2}>
                        <img
                          alt={inventory.name}
                          src={inventory.thumbnail}
                          style={{ height: "45px", width: "45px" }}
                        />
                        <Typography sx={{ fontWeight: "600" }} variant="subtitle2">
                          {inventory.name}
                        </Typography>
                      </Stack>
                    </TableCell>
                    <TableCell>{inventory.variants ? inventory.variants : `-`}</TableCell>
                    <TableCell>{inventory.sku ? millify(inventory.sku) : `-`}</TableCell>
                    <TableCell>{inventory.incoming ? millify(inventory.incoming) : `-`}</TableCell>
                    <TableCell>
                      {inventory.committed ? millify(inventory.committed) : `-`}
                    </TableCell>
                    <TableCell>
                      {inventory.available ? millify(inventory.available) : `-`}
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

InventoryTable.propTypes = {
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

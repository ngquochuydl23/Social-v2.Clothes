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
import AdjustInventoryForm from "./adjust-inventory-form";

export const InventoryTable = (props) => {
  const {
    count = 0,
    inventories = [],
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

  const [age, setAge] = useState('');
  const [inventoryDrawer, setInventoryDrawer] = useState(null);

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
                <TableCell padding="checkbox">Id</TableCell>
                <TableCell>Item</TableCell>
                <TableCell>Variants</TableCell>
                <TableCell>Sku</TableCell>
                <TableCell>Incoming</TableCell>
                <TableCell>Reserved</TableCell>
                <TableCell>Stock</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {inventories.map((inventory, index) => {
                return (
                  <TableRow
                    onClick={() => setInventoryDrawer(inventory)}
                    hover
                    key={inventory.id}>
                    <TableCell padding="checkbox">{index + 1}</TableCell>
                    <TableCell>
                      <Stack alignItems="center" direction="row" spacing={2}>
                        <img
                          alt={inventory.productVarient.productTitle}
                          src={"https://clothes-dev.social-v2.com/" + inventory.productVarient.thumbnail}
                          style={{ height: "45px", width: "45px" }}
                        />
                        <Typography sx={{ fontWeight: "600" }} variant="subtitle2">
                          {inventory.productVarient.title}
                        </Typography>
                      </Stack>
                    </TableCell>
                    <TableCell>{inventory.productVarient.productTitle}</TableCell>
                    <TableCell>{inventory.productVarient.id}</TableCell>
                    <TableCell>{0}</TableCell>
                    <TableCell>
                      {inventory.reservedQuantity}
                    </TableCell>
                    <TableCell>
                      {inventory.stockedQuantity}
                    </TableCell>
                  </TableRow>
                );
              })}
            </TableBody>
          </Table>
        </Box>
      </Scrollbar>
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
        <AdjustInventoryForm
          onSave={() => {
            setInventoryDrawer(null)
          }}
          inventory={inventoryDrawer} />
      </Drawer>
    </Stack >
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

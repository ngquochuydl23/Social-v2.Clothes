import PropTypes from "prop-types";
import {
  Avatar,
  Box,
  Button,
  FormControlLabel,
  Stack,
  Switch,
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
import { useState } from "react";

export const CategoryTable = (props) => {
  const {
    count = 0,
    categories = [],
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

  const [isActive, setIsActive] = useState(false);

  const handleToggle = () => {
    setIsActive(!isActive);
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
        }}
      >
        <div>
          <Button
            sx={{
              borderRadius: "4px",
              borderColor: "#d9d9d9",
              color: "#696969",
            }}
            size="medium"
            variant="outlined"
            startIcon={<TuneIcon />}
            fullWidth={false}
          >
            Filter
          </Button>
          <Button
            sx={{
              marginLeft: "10px",
              borderRadius: "4px",
              borderColor: "#d9d9d9",
              color: "#696969",
            }}
            variant="outlined"
            fullWidth={false}
          >
            Unpublished
          </Button>
        </div>
        <div>
          <Button
            href="categories/create-new-category"
            startIcon={<AddIcon />}
            sx={{
              marginLeft: "10px",
              borderRadius: "4px",
            }}
            variant="contained"
            fullWidth={false}
          >
            New category
          </Button>
        </div>
      </div>
      <Scrollbar>
        <Box sx={{ minWidth: 800 }}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell padding="checkbox">#</TableCell>
                <TableCell>Name</TableCell>
                <TableCell>Status</TableCell>
                <TableCell>Slug</TableCell>
                <TableCell>Description</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {categories.map((category, index) => {
                const isSelected = selected.includes(category.id);
                return (
                  <TableRow hover key={category.id} selected={isSelected}>
                    <TableCell padding="checkbox">{index + 1}</TableCell>
                    <TableCell>
                      <Stack alignItems="center" direction="row" spacing={2}>
                        <Typography sx={{ fontWeight: "600" }} variant="subtitle2">
                          {category.parentCategoryID == null ? category.name : "__" + category.name}
                        </Typography>
                      </Stack>
                    </TableCell>
                    <TableCell>
                      {category.isActive ? "Active" : "Inactive"}
                    </TableCell>
                    <TableCell>{category.handle}</TableCell>
                    <TableCell>{category.decription}</TableCell>
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

CategoryTable.propTypes = {
  count: PropTypes.number,
  categories: PropTypes.array,
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

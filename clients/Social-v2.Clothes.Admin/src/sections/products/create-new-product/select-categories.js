import { Button, Checkbox, Chip, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Divider, FormControl, FormControlLabel, FormGroup, FormLabel, Grid, Typography } from "@mui/material";
import { Box, Stack } from "@mui/system";
import _ from "lodash";
import { useEffect, useState } from "react";
import Select from 'react-select';

const data = [
  {
    id: 'quan-jeans',
    name: 'Quần Jeans',
    productCount: 200
  },
  {
    id: 'quan-nam',
    name: 'Quần Nam',
    productCount: 20
  }
]

const SelectCategories = ({ onReturnCategories }) => {
  const [originCategories, setOriginCategories] = useState([]);

  useEffect(() => {
    setOriginCategories(data);
  }, [])

  return (
    <Box>
      <Typography variant='subtitle1'>Select categories*</Typography>
      <Typography variant='caption'>Pick a category for this product.</Typography>
      <Box marginY={'20px'}>
        <Select
          onChange={opts => {
            onReturnCategories(_.map(opts, (item) => ({
              categoryId: item.value
            })));
          }}
          isMulti
          options={_.map(originCategories, (category) => ({
            label: category.name,
            value: category.id
          }))}
        />
      </Box>
    </Box>

  )
}

export default SelectCategories;
import { Button, Checkbox, Chip, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Divider, FormControl, FormControlLabel, FormGroup, FormLabel, Grid, Typography } from "@mui/material";
import { Box, Stack } from "@mui/system";
import _ from "lodash";
import { useEffect, useState } from "react";
import Select from 'react-select';
import { getCategories } from "src/services/api/category-api";


const SelectCategories = ({ onReturnCategories }) => {
  const [originCategories, setOriginCategories] = useState([]);

  useEffect(() => {
    getCategories({ hierarchy: false })
      .then((res) => {
        setOriginCategories(res);
      })
      .catch((err) => console.log(err))
  }, [])


  return (
    <Box>
      <Typography variant='subtitle1'>Select categories*</Typography>
      <Typography variant='caption'>When unchecked discounts will not be applied to this product.</Typography>
      <Box marginY={'20px'}>
        <Select
          onChange={opts => {
            onReturnCategories(_.map(opts, (item) => ({
              categoryId: item.value
            })));
          }}
          isSearchable
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
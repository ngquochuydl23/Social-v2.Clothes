import { Button, Checkbox, Chip, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Divider, FormControl, FormControlLabel, FormGroup, FormLabel, Typography } from "@mui/material";
import { Box, Stack } from "@mui/system";
import _ from "lodash";
import { useEffect, useState } from "react";


const cate = [
  {
    id: 'quan-jeans',
    name: 'Quần Jeans',
    productCount: 200
  },
  {
    id: 'quan-nam',
    name: 'Quần Nam',
    productCount: 200
  }
]

const CategoryItem = ({
  id,
  name
}) => {
  return (
    <Box
      sx={{
        backgroundColor: '#f5f5f5',
        padding: '15px'
      }}>
      <Typography variant="body1">{name}</Typography>
    </Box>
  )
}

const SelectCategories = ({ onReturnCategories }) => {
  const [open, setOpen] = useState(false);
  const [originCategories, setOriginCategories] = useState([]);
  const [keyword, setKeyword] = useState('');
  const [selectedCategories, setSelectedCategories] = useState([
    {
      id: 'quan-jeans',
      name: 'Quần Jeans'
    },
    {
      id: 'quan-nam',
      name: 'Quần Nam'
    }
  ]);

  useEffect(() => {
    setOriginCategories(cate);
  }, [])


  useEffect(() => {
    onReturnCategories(selectedCategories)
  }, [selectedCategories])

  return (
    <Box>
      <Typography variant='subtitle1'>Select categories*</Typography>
      <Typography variant='caption'>When unchecked discounts will not be applied to this product.</Typography>
      <Stack
        marginY={"10px"}
        direction="row"
        spacing={1}>
        {_.map(selectedCategories, (item) => (
          <Chip
            id={item.id}
            key={item.id}
            label={item.name}
            onDelete={() => {
              setCategories(_.filter(selectedCategories, (x) => x.id !== item.id))
            }} />
        ))}
      </Stack>
      <Button
        onClick={() => setOpen(true)}
        fullWidth
        sx={{
          borderRadius: '4px',
          borderColor: '#d9d9d9',
          color: '#696969'
        }}
        variant="outlined">Add category</Button>
      <Dialog
        open={open}
        sx={{ '& .MuiDialog-paper': { width: '80%' } }}
        onClose={() => setOpen(false)}
        scroll='paper'
        aria-labelledby="scroll-dialog-title"
        aria-describedby="scroll-dialog-description">
        <DialogTitle id="scroll-dialog-title">Select categories</DialogTitle>
        <DialogContent >

          <FormControl sx={{ width: '100%' }}>
            <FormGroup>
              {_.map(originCategories, (item) => {
                return (
                  <FormControlLabel
                    sx={{
                      width: '100%',
                      marginLeft: 0,
                      marginTop: '20px'
                    }}
                    control={
                      <Checkbox onChange={() => { }} />
                    }
                    label={
                      <Box marginLeft={"20px"}>
                        <Typography variant='subtitle1'>{item.name}</Typography>
                        <Typography variant='caption'>{item.productCount} products</Typography>
                      </Box>
                    }
                  />
                )
              })}
            </FormGroup>
          </FormControl>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setOpen(false)}>Cancel</Button>
          <Button onClick={() => setOpen(false)}>Ok</Button>
        </DialogActions>
      </Dialog>
    </Box>

  )
}

export default SelectCategories;
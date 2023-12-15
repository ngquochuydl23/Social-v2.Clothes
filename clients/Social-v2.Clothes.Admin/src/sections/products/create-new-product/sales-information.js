import { useEffect, useState } from "react";
import ProductOptionItem from "./product-option-item";
import CreateProductOptionDialog from "./create-product-option-dialog";
import AddIcon from '@mui/icons-material/Add';
import autoGenerateSkus from "src/utils/auto-generate-skus";
import _ from "lodash";
import ProductSkuItem from "./produc-sku-item";
const { Typography, Box, Button, Stack, TextField, InputAdornment, FormControlLabel, Checkbox } = require("@mui/material");

const SalesInformation = ({ onChangeSaleInfo }) => {
  const [openDialog, setOpenDialog] = useState(false);
  const [hasOptions, setHasOptions] = useState(false);
  const [options, setOptions] = useState([]);

  const [singlePrice, setSinglePrice] = useState(0);
  const [singleInStock, setSingleInStock] = useState(0);

  useEffect(() => {
    // onChangeSaleInfo({
    //   hasOptions: hasOptions,
    //   single: {
    //     price: singlePrice,
    //     inStock: singleInStock
    //   }
    // })
  }, [singlePrice, singleInStock])

  useEffect(() => {
    if (options.length > 0) {
      onChangeSaleInfo({
        hasOptions: hasOptions,
        options
      })
    }
  }, [options])

  return (
    <Box>
      <Typography variant='subtitle1'>Sales information</Typography>
      <Typography variant='caption'>Used for products that come in different variations.</Typography>
      <br></br>
      <FormControlLabel
        requireds
        control={
          <Checkbox
            value={hasOptions}
            onChange={() => setHasOptions(!hasOptions)} />
        }
        label="Check for multiple options" />
      <Box marginBottom={'20px'}>
        {hasOptions
          ? (<Stack
            mt={'20px'}
            direction="column">
            <Typography
              minWidth="150px"
              fontSize="16px"
              marginRight="20px"
              variant="subtitle2">
              Product Options
            </Typography>
            <Stack direction="column" >
              {_.map(options, (option, index) => {
                return (
                  <ProductOptionItem
                    index={index}
                    onDeleteOption={(idx) => {
                      setOptions(options.filter((item, index) => index !== idx))
                    }}
                    {...option}
                  />)
              })}
            </Stack>
            <Button
              fullWidth={false}
              onClick={() => setOpenDialog(true)}
              sx={{
                mt: '20px',
                width: '200px',
                borderRadius: '4px',
                height: '30px',
                fontSize: '14px',
                borderColor: '#606060',
                color: '#606060'
              }}
              startIcon={
                <AddIcon />
              }
              variant='outlined'>
              Add Product Option
            </Button>
            <Typography
              minWidth="150px"
              fontSize="16px"
              mt={"20px"}
              marginRight="20px"
              variant="subtitle2">
              Product Skus From Options
            </Typography>
            <Stack direction="column" >
              {_.map(autoGenerateSkus(options), (productSku) => {
                return (
                  <ProductSkuItem {...productSku}/>
                )
              })}
            </Stack>
          </Stack>)
          : (<Box>
            <Stack
              direction="row"
              alignItems="center">
              <Typography
                minWidth="150px"
                fontSize="16px"
                marginRight="20px"
                variant="subtitle2">
                Price*
              </Typography>
              <TextField
                hiddenLabel
                id="outlined-start-adornment"
                sx={{
                  width: '25ch',
                  height: '40px',
                }}
                onChange={(e) => setSinglePrice(e.target.value)}
                InputProps={{
                  borderRadius: '4px',
                  startAdornment: <InputAdornment position="start">đ</InputAdornment>,
                }}
              />
            </Stack>
            <Stack
              mt="15px"
              direction="row"
              alignItems="center">
              <Typography
                minWidth="150px"
                fontSize="16px"
                marginRight="20px"
                variant="subtitle2">
                In stock*
              </Typography>
              <TextField
                hiddenLabel
                onChange={(e) => setSingleInStock(e.target.value)}
                inputMode="numeric"
                id="outlined-start-adornment"
                sx={{
                  width: '25ch',
                  height: '40px',
                }}
              />
            </Stack>
          </Box>)}
      </Box>
      <CreateProductOptionDialog
        open={openDialog}
        onCreateOption={(option) => {
          setOptions([...options, option]);
        }}
        handleClose={() => setOpenDialog(false)} />
    </Box>
  )
}

export default SalesInformation;
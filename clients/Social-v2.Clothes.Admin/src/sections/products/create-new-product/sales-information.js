import { useEffect, useState } from "react";
import ProductOptionItem from "./product-option-item";
import CreateProductOptionDialog from "./create-product-option-dialog";
import AddIcon from '@mui/icons-material/Add';
import autoGenerateVarients from "src/utils/autoGenerateVarients";
import _ from "lodash";
import ApplyForSkusDialog from "./apply-for-skus-dialog";
import ProductVarientItem from "./product-varient-item";
const { Typography, Box, Button, Stack, TextField, InputAdornment, FormControlLabel, Checkbox, Divider } = require("@mui/material");

const SalesInformation = ({ onChangeSaleInfo }) => {
    const [openDialog, setOpenDialog] = useState(false);
    const [openApplyDialog, setOpenApplyDialog] = useState(false);


    const [hasOptions, setHasOptions] = useState(false);
    const [options, setOptions] = useState([]);




    const [productVarients, setProductVarients] = useState([]);

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
                options,
                productVarients
            })
        }
    }, [options, productVarients])

    return (
        <Box>
            <Typography
                mt="22px"
                fontSize="20px"
                variant='h3'>
                {String("Sales information").toUpperCase()}
            </Typography>
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
                                            const newOptions = options.filter((item, index) => index !== idx);
                                            setProductVarients(autoGenerateVarients(newOptions))
                                            setOptions(newOptions);
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
                            Thêm tùy chọn
                        </Button>
                        <Divider sx={{ marginTop: '20px' }} />
                        {options.length > 0 &&
                            <Stack
                                direction="row"
                                justifyContent="space-between">
                                <Stack mt={"20px"}>
                                    <Typography
                                        minWidth="150px"
                                        fontSize="16px"
                                        marginRight="20px"
                                        variant="subtitle2">
                                        Product Skus From Options
                                    </Typography>
                                    <Typography
                                        minWidth="150px"
                                        marginRight="20px"
                                        variant="caption">
                                        Based on the same product definition but with unique identifiers.
                                    </Typography>
                                </Stack>
                                <Button
                                    fullWidth={false}
                                    onClick={() => setOpenApplyDialog(true)}
                                    sx={{
                                        my: '20px',
                                        width: '200px',
                                        borderRadius: '4px',
                                        height: '30px',
                                        fontSize: '14px',
                                    }}
                                    variant='contained'>
                                    Apply for all skus
                                </Button>
                            </Stack>
                        }
                        <Stack direction="column" >
                            {options.length > 0 && _.map(productVarients, (productVarient, index) => {
                                return (
                                    <ProductVarientItem
                                        {...productVarient}
                                        onEdited={(newPVarient) => {

                                            let copyNewPVarient = [...productVarients];
                                            copyNewPVarient[index] = newPVarient
                                            console.log(copyNewPVarient[index]);
                                            setProductVarients(copyNewPVarient);
                                        }}
                                    />
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
                    setProductVarients(autoGenerateVarients([...options, option]))
                }}
                handleClose={() => setOpenDialog(false)} />
            <ApplyForSkusDialog
                open={openApplyDialog}
                onApply={(value) => {
                    if (!value.price && !value.stock)
                        return;

                    setProductVarients(_.map(productVarients, (item) => {
                        item.price = value.price || item.price
                        item.stock = value.stock || item.stock

                        return item;
                    }))
                }}
                handleClose={() => setOpenApplyDialog(false)}
            />
        </Box>
    )
}

export default SalesInformation;
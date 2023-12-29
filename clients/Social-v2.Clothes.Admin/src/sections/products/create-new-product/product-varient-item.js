import { Box, Button, Typography, Stack, Divider } from "@mui/material"
import EditIcon from '@mui/icons-material/Edit';
import EditProductVarientDialog from './edit-product-varient-dialog';
import { useEffect, useState } from 'react';
var currencyFormatter = require('currency-formatter');

const ProductVarientItem = ({
    title,
    price,
    stock,
    varientValues,
    proVarientMedias,
    onEdited
}) => {
    const [productVarient, setProductVarient] = useState({
        title: title,
        price: price,
        varientValues: varientValues,
        proVarientMedias: proVarientMedias || [],
        stock: stock
    })
    const [open, setOpen] = useState(false);

    useEffect(() => {
        setProductVarient({
            title: title,
            price: price,
            varientValues: varientValues,
            proVarientMedias: proVarientMedias || [],
            stock: stock
        })
    }, [title, price, stock, varientValues, proVarientMedias])

    return (
        <Box my={'10px'}>
            <Stack
                direction="row"
                alignItems="center">
                <Typography
                    width={'40px'}
                    height={'40px'}
                    backgroundColor="#f5f5f5"
                    sx={{
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: "center",
                        marginRight: '20px',
                        borderRadius: '5px'
                    }}
                    textAlign={'center'}
                    fontSize="16px"
                    variant="h4">
                </Typography>
                <Stack sx={{ display: 'flex', flex: 1 }}>
                    <Typography
                        sx={{ width: '100%' }}
                        fontSize="16px"
                        marginRight="20px"
                        variant="subtitle2">
                        {productVarient.title}
                    </Typography>
                    <Typography
                        sx={{ color: '#696969', fontWeight: 400, width: '100%' }}
                        fontSize="14px"
                        marginRight="20px"
                        variant="caption">
                        {productVarient.varientValues.map(item => item.value).join('/')}
                    </Typography>
                </Stack>
                <Typography
                    fontSize="14px"
                    marginRight="20px"
                    variant="subtitle2">
                    {currencyFormatter.format(productVarient.price, {
                        code: 'VND',
                        thousand: ',',
                    })}
                </Typography>
                <Typography
                    fontSize="14px"
                    marginRight="20px"
                    variant="subtitle2">
                    {productVarient.stock || 0} available
                </Typography>
                <Button
                    onClick={() => setOpen(true)}
                    variant='outlined'
                    startIcon={<EditIcon />}
                    sx={{
                        height: '30px',
                        borderColor: '#696969',
                        borderRadius: '4px',
                        fontSize: '13px',
                        color: '#696969',
                        marginRight: '15px  '
                    }}>
                    Edit
                </Button>
            </Stack>
            <EditProductVarientDialog
                open={open}
                onProductEdited={(varientItem) => {
                    // onEdited({
                    //     ...productVarient,
                    //     ...newSku
                    // })
                    // setProductVarient({
                    //     ...productVarient,
                    //     ...newSku
                    // })

                    console.log(varientItem);
                }}
                productVarient={productVarient}
                handleClose={() => setOpen(false)}
            />
            {productVarient.proVarientMedias.length > 0 &&
                <Stack
                    spacing="10px"
                    direction="row"
                    sx={{
                        marginLeft: '60px',
                        marginTop: '20px'
                    }}>
                    {_.map(proVarientMedias, (proVarientMedia) => {
                        return (
                            <Box
                                overflow="hidden"
                                borderRadius="4px"
                                width="100px"
                                height="100px">
                                <img
                                    src={URL.createObjectURL(proVarientMedia.localFile)}
                                    width="100%"
                                    height="100%" />
                            </Box>
                        )
                    })}
                </Stack>}
            <Divider sx={{
                marginLeft: '60px',
                marginTop: '20px'
            }} />
        </Box >
    )
}

export default ProductVarientItem;
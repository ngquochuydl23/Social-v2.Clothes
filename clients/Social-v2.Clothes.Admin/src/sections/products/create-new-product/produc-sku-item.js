import { Box, Button, Typography, Stack, Divider } from "@mui/material"
import EditIcon from '@mui/icons-material/Edit';
import EditProductSkuDialog from './edit-product-sku-dialog';
import { useEffect, useState } from 'react';
var currencyFormatter = require('currency-formatter');

const ProductSkuItem = ({
    title,
    price,
    stock,
    skuValues,
    proSkuMedias,
    onEdited
}) => {
    const [productSku, setProductSku] = useState({
        title: title,
        price: price,
        skuValues: skuValues,
        proSkuMedias: proSkuMedias || [],
        stock: stock
    })
    const [open, setOpen] = useState(false);

    useEffect(() => {
        setProductSku({
            title: title,
            price: price,
            skuValues: skuValues,
            proSkuMedias: proSkuMedias || [],
            stock: stock
        })
    }, [title, price, stock, skuValues, proSkuMedias])

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
                        {productSku.title}
                    </Typography>
                    <Typography
                        sx={{ color: '#696969', fontWeight: 400, width: '100%' }}
                        fontSize="14px"
                        marginRight="20px"
                        variant="caption">
                        {productSku.skuValues.map(item => item.value).join('/')}
                    </Typography>
                </Stack>
                <Typography
                    fontSize="14px"
                    marginRight="20px"
                    variant="subtitle2">
                    {currencyFormatter.format(productSku.price, {
                        code: 'VND',
                        thousand: ',',
                    })}
                </Typography>
                <Typography
                    fontSize="14px"
                    marginRight="20px"
                    variant="subtitle2">
                    {productSku.stock || 0} available
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
            <EditProductSkuDialog
                open={open}
                onProductEdited={(newSku) => {
                    onEdited({
                        ...productSku,
                        ...newSku
                    })
                    setProductSku({
                        ...productSku,
                        ...newSku
                    })
                }}
                productSku={productSku}
                handleClose={() => setOpen(false)}
            />
            {productSku.proSkuMedias.length > 0 &&
                <Stack
                    spacing="10px"
                    direction="row"
                    sx={{
                        marginLeft: '60px',
                        marginTop: '20px'
                    }}>
                    {_.map(proSkuMedias, (productSkuMedia) => {
                        return (
                            <Box
                                overflow="hidden"
                                borderRadius="4px"
                                width="100px"
                                height="100px">
                                <img
                                    src={URL.createObjectURL(productSkuMedia.localFile)}
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

export default ProductSkuItem;
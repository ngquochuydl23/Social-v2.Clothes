import { Box, Button, Typography, Stack, Divider } from "@mui/material"
import EditIcon from '@mui/icons-material/Edit';
import { useEffect, useState } from 'react';
var currencyFormatter = require('currency-formatter');

const ProductDetailVarientItem = ({
    title,
    price,
    stock,
    skuValues,
    proSkuMedias,
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
            </Stack>
            <Divider sx={{
                marginTop: '20px'
            }} />
        </Box >
    )
}

export default ProductDetailVarientItem;
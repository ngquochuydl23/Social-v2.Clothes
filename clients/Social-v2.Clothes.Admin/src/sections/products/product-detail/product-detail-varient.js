import { Box, Button, Typography, Stack, Divider } from "@mui/material"
import EditIcon from '@mui/icons-material/Edit';
import { useEffect, useState } from 'react';
var currencyFormatter = require('currency-formatter');

const ProductDetailVarientItem = ({
    productTitle,
    title,
    price,
    stock,
    varientMedias,
}) => {
    const [productVarient, setProductVarient] = useState({
        title: title,
        price: price,
        varientMedias: varientMedias || [],
        stock: stock
    })
    const [open, setOpen] = useState(false);

    useEffect(() => {
        setProductVarient({
            title: title,
            price: price,
            varientMedias: varientMedias || [],
            stock: stock
        })
    }, [title, price, stock, varientMedias])

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
                        {productTitle}
                    </Typography>
                    <Typography
                        sx={{ color: '#696969', fontWeight: 400, width: '100%' }}
                        fontSize="14px"
                        marginRight="20px"
                        variant="caption">
                        {productVarient.title}
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
            </Stack>
            <Divider sx={{
                marginTop: '20px'
            }} />
        </Box >
    )
}

export default ProductDetailVarientItem;
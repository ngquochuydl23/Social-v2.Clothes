const { Box, Button, Typography, Stack } = require("@mui/material")
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';

const ProductSkuItem = ({
    title,
    price,
    skuValues
}) => {
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
                        {title}
                    </Typography>
                    <Typography
                        sx={{ color: '#696969', fontWeight: 400, width: '100%' }}
                        fontSize="14px"
                        marginRight="20px"
                        variant="caption">
                        {skuValues.map(item => item.value).join('/')}
                    </Typography>
                </Stack>
                <Typography
                    fontSize="14px"
                    marginRight="20px"
                    variant="subtitle2">
                    200 available
                </Typography>
                <Button
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
        </Box>
    )
}

export default ProductSkuItem;
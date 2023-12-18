const { Box, Stack, Typography, TextField, InputAdornment, Button } = require("@mui/material")
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import AddIcon from '@mui/icons-material/Add';

const ProductDetailOptionItem = ({ index, title, optionValues }) => {
    const getOptionValuesAsString = () => {
        var nOtherElements = optionValues.length - 3
        return optionValues.slice(0, 3).join(', ') + (nOtherElements > 0 ? ' + ' + nOtherElements + ' more' : '');
    }
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
                    #{index + 1}
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
                        {getOptionValuesAsString(optionValues)}
                    </Typography>
                </Stack>
            </Stack>
        </Box>
    )
}

export default ProductDetailOptionItem;
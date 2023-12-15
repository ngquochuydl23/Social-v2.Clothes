const { Box, Stack, Typography, TextField, InputAdornment } = require("@mui/material")

const ProductOptionItem = ({ title, optionValues }) => {
    return (
        <Box sx={{ backgroundColor: '#f5f5f5' }}>
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
        </Box>
    )
}

export default ProductOptionItem;
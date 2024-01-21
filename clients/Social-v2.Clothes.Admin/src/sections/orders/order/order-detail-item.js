import { Box, Divider, Stack, Typography } from "@mui/material";
import currencyFormatter from 'currency-formatter';

const OrderDetailItem = ({
    title,
    productTitle,
    thumbnail,
    quantity,
    price
}) => {
    return (
        <Box my={'10px'}>
            <Stack
                direction="row"
                alignItems="center">
                <img
                    style={{
                        height: '80px',
                        width: '60px',
                        backgroundColor: '#f5f5f5'
                    }}
                    src="https://down-vn.img.susercontent.com/file/vn-11134207-7qukw-lk3a75y1ygoy18" />
                <Stack
                    sx={{
                        ml: '20px',
                        display: 'flex',
                        flex: 1
                    }}>
                    <Typography
                        sx={{ width: '100%' }}
                        fontSize="16px"
                        marginRight="20px"
                        variant="subtitle2">
                        {`Áo thun Levents Logo Tee Basic`}
                    </Typography>
                    <Typography
                        sx={{ color: '#696969', fontWeight: 400, width: '100%' }}
                        fontSize="14px"
                        marginRight="20px"
                        variant="caption">
                        {`Đen/XL`}
                    </Typography>
                </Stack>
                <Typography
                    fontSize="16px"
                    marginRight="30px"
                    variant="subtitle2">
                    {currencyFormatter.format(125000, {
                        code: 'VND',
                        thousand: ',',
                    })}
                </Typography>
                <Typography
                    fontSize="16px"
                    marginRight="20px"
                    variant="subtitle2">
                    x{1 || 0}
                </Typography>
            </Stack>
            {/* <Divider sx={{ marginTop: '20px' }} /> */}
        </Box >
    )
}

export default OrderDetailItem;
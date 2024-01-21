import { Box, Button, Checkbox, FormControlLabel, Stack } from "@mui/material";

const OrderFilterPopover = () => {
    return (
        <Box>
            <Stack
                display="flex"
                spacing="10px"
                direction="row">

                <FormControlLabel
                    label="Parent"
                    control={
                        <Checkbox
                            checked={checked[0] && checked[1]}
                            indeterminate={checked[0] !== checked[1]}
                            onChange={handleChange1}
                        />
                    }
                />
                {children}

                <Button
                    sx={{
                        height: '30px',
                        borderRadius: '4px',
                        width: '50px',
                        fontSize: '14px'
                    }}
                    variant="outlined">Reset</Button>
                <Button
                    fullWidth
                    sx={{
                        height: '30px',
                        borderRadius: '4px',
                        fontSize: '14px'
                    }}
                    variant="contained">Apply</Button>
            </Stack>
        </Box>
    )
}

export default OrderFilterPopover;
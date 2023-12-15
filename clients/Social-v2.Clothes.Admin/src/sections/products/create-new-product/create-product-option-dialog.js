import { Box, Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, FormControl, InputAdornment, Stack, TextField, Typography } from "@mui/material";
import { useState } from "react";
import { Chips } from "primereact/chips";


const CreateProductOptionDialog = ({ open, handleClose }) => {
    const [option, setOption] = useState({
        title: '',
        optionValues: []
    });

    return (
        <Dialog
            maxWidth={'lg'}
            open={open}
            onClose={handleClose}>
            <DialogTitle>Optional sizes</DialogTitle>
            <DialogContent>
                <Stack
                    marginTop={"10px"}
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
                            width: '45ch',
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
                    marginTop="15px"
                    direction="row"
                    alignItems="center">
                    <Typography
                        minWidth="150px"
                        fontSize="16px"
                        marginRight="20px"
                        variant="subtitle2">
                        Option values*
                    </Typography>
                    <div
                        className="card p-fluid">
                        <Chips

                            style={{
                                borderRadius: '4px',
                                borderColor: '#d3d3d3',
                                borderWidth: 1,
                                width: '45ch',
                                minHeight: '40px',
                                '&:focus': {
                                    border: '1px solid green'
                                },
                            }}
                            value={option.optionValues}
                            onChange={(e) => setOption({
                                ...option,
                                optionValues: e.value
                            })}
                        />
                    </div>
                </Stack>
            </DialogContent>
            <DialogActions>
                <Button onClick={handleClose}>Close</Button>
            </DialogActions>
        </Dialog>
    )
}

export default CreateProductOptionDialog;
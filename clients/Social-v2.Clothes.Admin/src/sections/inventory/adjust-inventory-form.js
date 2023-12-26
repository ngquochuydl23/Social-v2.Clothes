import { Box, Button, Stack, TextField, Typography } from "@mui/material";
import { useFormik } from "formik";
import { useState } from "react";
import { Scrollbar } from "src/components/scrollbar";

const AdjustInventoryForm = ({ inventory, onSave }) => {
    const [handle, setHandle] = useState('');
    const formik = useFormik({
        // initialValues: {
        //     title: product.title,
        //     subtitle: product.subtitle,
        //     description: product.description,
        //     handle: product.handle,
        // },
        // onSubmit: values => {
        //     console.log(JSON.stringify(values, null));
        // },
    });

    if (inventory === null)
        return null;
    return (
        <Stack spacing={3}
            sx={{ width: '500px', padding: '30px' }}>
            <form >
                <Scrollbar sx={{ flexGrow: 1 }}>
                    <Box my={'10px'}>
                        <Stack
                            direction="row"
                            alignItems="center">
                            <img
                                style={{ borderRadius: '4px' }}
                                height="50px"
                                width="50px"
                                src={inventory.thumbnail} />
                            <Stack sx={{ display: 'flex', flex: 1, marginLeft: '10px' }}>
                                <Typography
                                    sx={{ width: '100%' }}
                                    fontSize="16px"
                                    fontWeight="600"
                                    marginRight="20px"
                                    variant="subtitle2">
                                    {inventory.name}
                                </Typography>
                                <Typography
                                    sx={{ color: '#696969', fontWeight: 400, width: '100%' }}
                                    fontSize="14px"
                                    marginRight="20px"
                                    variant="caption">
                                    {inventory.variants.join('-')}
                                </Typography>
                            </Stack>
                        </Stack>
                        <Stack
                            mt={"20px"}
                            direction="row"
                            justifyContent="space-between">
                            <Typography
                                fontSize="14px"
                                variant='subtitle2'>
                                Original quantity
                            </Typography>
                            <Typography
                                fontSize="14px"
                                variant='subtitle2'>
                                {`200`}
                            </Typography>
                        </Stack>
                        <TextField
                            sx={{ marginTop: "20px", width: '100%' }}
                            type="number"
                            id="adjustBy"
                            label="Adjust by"
                        />
                    </Box>

                </Scrollbar>
                <Button
                    sx={{
                        borderRadius: '10px',
                        mt: '20px',
                        mb: '20px',
                        height: '50px'
                    }}
                    fullWidth
                    variant="contained"
                    // disabled={
                    //     (formik.errors.title || formik.errors.subtitle || formik.errors.description)
                    //     || (formik.initialValues === formik.values)
                    // }
                    onClick={() => { onSave() }}
                    type="button">Save   and close</Button>
            </form>
        </Stack>
    )
}

export default AdjustInventoryForm;
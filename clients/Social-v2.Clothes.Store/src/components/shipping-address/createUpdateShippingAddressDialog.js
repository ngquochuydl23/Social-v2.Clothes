import * as React from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import { useFormik } from 'formik';
import { Grid, MenuItem, Stack, TextField, Typography } from '@mui/material';
import tinh_tp from 'hanhchinhvn/dist/tinh_tp.json'


export default function CreateUpdateShippingAddressDialog({
    open, handleClose, onCreated, onUpdated, address
}) {
    const [provinceOrCityIdx, setProvinceOrCityIdx] = React.useState(null);

    const getDistrictByProvinceCity = (provinceOrCityIdx) => {
        return require(`hanhchinhvn/dist/quan-huyen/${provinceOrCityIdx}.json`)
    }

    const formik = useFormik({
        enableReinitialize: true,
        initialValues : {
            id: undefined,
            name: '',
            district: '',
            isDefault: false,
            detailAddress: '',
            phoneNumber: '',
            provinceOrCity: '',
            wardOrCommune: '',
        },
        onSubmit: values => {
            alert(JSON.stringify(values, null, 2));
        },
    });

    React.useEffect(() => {
      if (open && Boolean(address)) {
        formik.setValues(address)
      }
    }, [open])

    return (
        <Dialog
            maxWidth='lg'
            open={open}
            onClose={handleClose}
            aria-labelledby="alert-dialog-title"
            aria-describedby="alert-dialog-description">
            <form>
                <DialogTitle id="alert-dialog-title">
                    <Typography
                        fontSize="18px"
                        variant='h5'
                        mb="10px"
                        mt='10px'
                        fontWeight="600">
                        {`Add Shipping Address`}
                    </Typography>
                </DialogTitle>
                <DialogContent sx={{ width: '500px' }}>
                    <TextField
                        sx={{ mt: '5px' }}
                        required
                        fullWidth
                        onChange={formik.handleChange}
                        value={formik.values.name}
                        id="name"
                        label="Name"
                    />
                    <TextField
                        sx={{ mt: '15px' }}
                        required
                        fullWidth
                        onChange={formik.handleChange}
                        value={formik.values.phoneNumber}
                        id="phoneNumber"
                        label="Phone number"
                    />
                    <Grid
                        mt="10px"
                        container
                        rowSpacing="15px"
                        columnSpacing="10px"
                        justifyContent="space-between">
                        <Grid item lg={6}>
                            <TextField
                                required
                                fullWidth
                                select
                                onChange={formik.handleChange}
                                value={formik.values.provinceOrCity}
                                id="provinceOrCity"
                                label="Province or City"
                            >

                            </TextField>
                        </Grid>
                        <Grid item lg={6}>
                            <TextField
                                required
                                select
                                fullWidth
                                onChange={formik.handleChange}
                                value={formik.values.district}
                                id="district"
                                label="District"
                            />
                        </Grid>
                        <Grid item lg={12}>
                            <TextField
                                required
                                fullWidth
                                select
                                onChange={formik.handleChange}
                                value={formik.values.wardOrCommune}
                                id="wardOrCommune"
                                label="Ward Or Commune"
                            />
                        </Grid>
                    </Grid>
                    <TextField
                        required
                        fullWidth
                        sx={{ mt: '15px' }}
                        onChange={formik.handleChange}
                        value={formik.values.detailAddress}
                        id="detailAddress"
                        label="Detail Address"
                    />
                </DialogContent>
                <DialogActions>
                    <Button
                        onClick={() => {
                            //onLeftClick()
                            handleClose()
                        }}>
                        Cancel
                    </Button>
                    <Button
                        onClick={() => {
                            onCreated()
                            handleClose()
                        }}
                        autoFocus>
                        Add
                    </Button>
                </DialogActions>
            </form>
        </Dialog >
    );
}
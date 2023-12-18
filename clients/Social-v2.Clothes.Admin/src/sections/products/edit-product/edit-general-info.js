import { Box, Button, Stack, TextField, Typography } from "@mui/material";
import { useFormik } from "formik";
import { useState } from "react";
import { Scrollbar } from "src/components/scrollbar";

const EditGeneralInfo = ({ product, }) => {
    const [handle, setHandle] = useState('');
    const formik = useFormik({
        initialValues: {
            title: product.title,
            subtitle: product.subtitle,
            description: product.description,
            handle: product.handle,
        },
        onSubmit: values => {
            console.log(JSON.stringify(values, null));
        },
    });

    return (
        <Stack spacing={3}
            sx={{ width: '500px', padding: '30px' }}>
            <form onSubmit={formik.handleSubmit}>
                <Scrollbar sx={{ flexGrow: 1 }}>
                    <TextField
                        required
                        fullWidth
                        onChange={(e) => {
                            formik.handleChange(e);
                            formik.setFieldValue('handle', generateDashByText(e.target.value));
                            setHandle(generateDashByText(e.target.value));
                        }}
                        value={formik.values.title}
                        id="title"
                        label="Title"
                    />
                    <TextField
                        required
                        sx={{ marginTop: "20px" }}
                        fullWidth
                        id="subtitle"
                        helperText="Give your product a short and clear title. 50-60 characters is the recommended length for search engines."
                        label="Subtitle"
                        onChange={formik.handleChange}
                        value={formik.values.subtitle}
                    />
                    <TextField
                        sx={{ marginTop: "20px" }}
                        required
                        fullWidth
                        disabled
                        value={handle}
                        label="Handle"
                    />
                    <TextField
                        sx={{ marginTop: "20px" }}
                        required
                        fullWidth
                        multiline
                        minRows={4}
                        helperText="Give your product a short and clear description. 120-160 characters is the recommended length for search engines."
                        id="description"
                        label="Description"
                        onChange={formik.handleChange}
                        value={formik.values.description}
                    />
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
                    disabled={
                        (formik.errors.title || formik.errors.subtitle || formik.errors.description)
                        || (formik.initialValues === formik.values)
                    }
                    type="submit">Add</Button>
            </form>
        </Stack>
    )
}

export default EditGeneralInfo;
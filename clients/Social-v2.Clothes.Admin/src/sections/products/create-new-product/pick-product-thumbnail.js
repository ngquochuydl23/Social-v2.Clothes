import { useState } from "react";
import { uploadFile } from "src/services/api/upload-api";

const { Stack, Box, Typography, Button } = require("@mui/material")

const PickProductThumbnail = ({ onReceiveThumbnail }) => {
    const [hasUploaded, setHasUploaded] = useState(false);
    const [thumbnail, setThumbnail] = useState(null);
    return (
        <Stack
            direction="row"
            sx={{ display: 'flex', alignItems: 'center' }}>
            <input
                onChange={(event) => {
                    var file = event.target.files[0];
                    setThumbnail(file);

                    uploadFile(file)
                        .then(({ medias }) => {
                            setHasUploaded(true);
                            setThumbnail(medias[0].url);
                            onReceiveThumbnail(medias[0].url);
                        })
                        .catch((err) => console.log(err))
                    
                }}
                style={{ display: 'none' }}
                type="file"
                accept="image/*"
                id="pick-image" />
            {thumbnail
                ? (<img
                    style={{
                        height: '150px',
                        width: '150px',
                        borderRadius: '10px'
                    }}
                    src={hasUploaded ? `https://clothes-dev.social-v2.com${thumbnail}` : URL.createObjectURL(thumbnail)} />)
                : (<div
                    onClick={() => document.getElementById('pick-image').click()}
                    style={{
                        height: '150px',
                        width: '150px',
                        borderRadius: '10px',
                        backgroundColor: '#f5f5f5'
                    }}>
                </div>
                )}
            <Box marginLeft={"20px"}>
                <Typography variant='subtitle1'>Choose product thumbnail</Typography>
                <Typography variant='caption'>When unchecked discounts will not be applied to this product.</Typography>
                {thumbnail &&
                    <Stack direction="row">
                        <Button
                            fullWidth={false}
                            onClick={() => {
                                setThumbnail(null)
                                onReceiveThumbnail(null)
                            }}
                            sx={{
                                color: 'red',
                                borderColor: 'red',
                                height: '30px',
                                marginTop: '10px',
                                borderRadius: '4px'
                            }}
                            variant="outlined">Remove</Button>
                    </Stack>
                }
            </Box>
        </Stack>
    )
}

export default PickProductThumbnail;
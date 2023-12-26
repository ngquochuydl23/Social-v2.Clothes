import { useCallback } from 'react';
import {
    Button,
    Card,
    CardActions,
    CardContent,
    CardHeader,
    Checkbox,
    Divider,
    FormControlLabel,
    Stack,
    Typography,
    Unstable_Grid2 as Grid
} from '@mui/material';
import Link from 'next/link';

export const SettingSectionItem = ({
    title,
    subtitle,
    path
}) => {
    return (
        <Card
            component={Link}
            href={"/personal-information"}
            sx={{
                textDecoration: 'none',
                borderRadius: '10px',
                boxShadow: 'rgba(0, 0, 0, 0.16) 0px 10px 36px 0px, rgba(0, 0, 0, 0.06) 0px 0px 0px 1px'
            }}>
            <CardHeader
                subheader={subtitle}
                title={title}
            />
            <Divider />
        </Card>
    );
};

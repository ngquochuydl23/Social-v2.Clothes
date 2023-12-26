import * as React from 'react';
import { styled } from '@mui/material/styles';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Box from '@mui/material/Box';

export const StyledTabs = styled((props) => (
    <Tabs
        {...props}
        TabIndicatorProps={{ children: <span className="MuiTabs-indicatorSpan" /> }}
    />
))({
    '& .MuiTabs-indicator': {
        display: 'flex',
        justifyContent: 'center',
        backgroundColor: '#696969',
    },
    '& .MuiTabs-indicatorSpan': {
        width: '100%',
        backgroundColor: '#8a00c2',
    },
});

export const StyledTab = styled((props) => (
    <Tab disableRipple {...props} />
))(({ theme }) => ({
    textTransform: 'none',
    fontWeight: 500,
    fontSize: theme.typography.pxToRem(15),
    marginRight: theme.spacing(1),
    color: '#696969 ',
    '&.Mui-selected': {
        color: '#8a00c2',
        fontWeight: 600,
    },
    '&.Mui-focusVisible': {
        backgroundColor: 'rgba(100, 95, 228, 0.32)',
    },
}));

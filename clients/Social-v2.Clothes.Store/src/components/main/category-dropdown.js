import * as React from 'react';
import Popover from '@mui/material/Popover';
import Typography from '@mui/material/Typography';

export default function CategoryDropdown() {
    const [anchorEl, setAnchorEl] = React.useState(null);

    const handlePopoverOpen = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handlePopoverClose = () => {
        setAnchorEl(null);
    };

    const open = Boolean(anchorEl);

    return (
        <div className="w-full bg-white">
            <Typography
                aria-owns={open ? 'mouse-over-popover' : undefined}
                aria-haspopup="true"
                onMouseEnter={handlePopoverOpen}
                onMouseLeave={handlePopoverClose}>
                Hover with a Popover.
            </Typography>
            <Popover
                PaperProps={{ style: { width: '100%', paddingRight: 0 } }}
                elevation={1}
                id="mouse-over-popover"
                sx={{
                    pointerEvents: 'none',
                    width: '100%'
                }}
                open={open}
                anchorEl={anchorEl}
                anchorOrigin={{
                    vertical: 'bottom',
                    horizontal: 'center',
                }}
                transformOrigin={{
                    vertical: 'top',
                    horizontal: 'center',
                }}
                onClose={handlePopoverClose}
                //disableRestoreFocus
            >
                <Typography sx={{ p: 1, height: 400 }}>I use Popover.</Typography>
            </Popover>
        </div>
    );
}
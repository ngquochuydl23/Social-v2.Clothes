import * as React from 'react';
import { Button, Popover } from 'antd';
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';
const options = [
    'one', 'two', 'three'
];
const defaultOption = options[0];

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

            
        </div>
    );
}
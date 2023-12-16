import * as React from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';

export default function AlertDialog({
    open, handleClose, onLeftClick, onRightClick, title, content, leftTxt, rightTxt
}) {
    return (
        <Dialog
            open={open}
            onClose={handleClose}
            aria-labelledby="alert-dialog-title"
            aria-describedby="alert-dialog-description">
            <DialogTitle id="alert-dialog-title">
                {title}
            </DialogTitle>
            <DialogContent>
                <DialogContentText id="alert-dialog-description">
                    {content}
                </DialogContentText>
            </DialogContent>
            <DialogActions>
                <Button onClick={() => {
                    onLeftClick()
                    handleClose()
                }}>{leftTxt}</Button>
                <Button onClick={() => {
                    onRightClick()
                    handleClose()
                }} autoFocus>
                    {rightTxt}
                </Button>
            </DialogActions>
        </Dialog>
    );
}
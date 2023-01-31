import React, { useState } from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import { Checkbox, FormControlLabel, FormGroup } from '@mui/material';
interface TestDescriptionModalProps {
    open: boolean;
    handleClose: () => void;
    name: string;
    description: string;
    id: string;
    onProceed: () => void;
}
const TestDescriptionModal: React.FC<TestDescriptionModalProps> = (props) => {
    const style = {
        position: 'absolute' as 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: 400,
        bgcolor: 'background.paper',
        border: '2px solid #000',
        boxShadow: 24,
        p: 4,
    };
    const [checked, setChecked] = useState(false);
    return (
        <div>
            <Modal
                open={props.open}
                onClose={props.handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box sx={style}>
                    <Typography id="modal-modal-title" variant="h6" component="h2">
                        {props.name}
                    </Typography>
                    <Typography id="modal-modal-description" sx={{ mt: 2 }}>
                        {props.name}
                    </Typography>
                    <Box sx={{ display: "flex", flexDirection: "row", justifyContent: "space-around" }}>
                        <FormGroup>
                            <FormControlLabel control={<Checkbox onChange={(e) => setChecked(e.target.checked)} />} label="I agree to start" />
                        </FormGroup>
                        <Button onClick={props.onProceed} disabled={!checked}>
                            Proceed
                        </Button>
                    </Box>
                </Box>
            </Modal>
        </div>
    )
}
export default TestDescriptionModal
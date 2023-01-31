import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import { observer } from 'mobx-react-lite';
import RootStore from '../store/RootStore';
const Header = () => {
    let context = React.useContext(RootStore)
    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static">
                <Toolbar>
                    <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                        Tests
                    </Typography>
                    <Button onClick={() => { context.userStore.Logout() }} color="inherit">Logout</Button>
                </Toolbar>
            </AppBar>
        </Box>
    );
}
export default observer(Header)
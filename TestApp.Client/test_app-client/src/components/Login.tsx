import { Box, Button, Container, Input, TextField, Avatar } from "@mui/material"
import React, { useContext } from "react"
import RootStore from '../store/RootStore';
import { observer } from 'mobx-react-lite';
const Login = () => {
    const [login, setLogin] = React.useState("");
    const [password, setPassword] = React.useState("");


    const keyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
        if (event.key == "Enter" /* Enter Key */) {
            if (login && password) {
                context.userStore.Login({ email: login, password })
            }
        }
    }
    let context = useContext(RootStore)
    return (
        <Container component="main" maxWidth="xs">
            <Box
                sx={{
                    marginTop: 8,
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                }}
            >
                <Box sx={{ mt: 1 }}>
                    <TextField
                        margin="normal"
                        required
                        fullWidth
                        name="login"
                        label="Login"
                        autoComplete="login"
                        autoFocus
                        onKeyPress={keyPress}
                        onChange={e => setLogin(e.target["value"])}
                    />
                    <TextField
                        margin="normal"
                        required
                        fullWidth
                        name="password"
                        label="Password"
                        type="password"
                        id="password"
                        autoComplete="current-password"
                        onKeyPress={keyPress}
                        onChange={e => setPassword(e.target["value"])}
                    />
                    <Button
                        fullWidth
                        variant="contained"
                        sx={{ mt: 3, mb: 2 }}
                        onClick={() => { context.userStore.Login({ email: login, password }) }}
                    >
                        Login
                    </Button>

                </Box>
            </Box>
        </Container>
    )
}
export default observer(Login)
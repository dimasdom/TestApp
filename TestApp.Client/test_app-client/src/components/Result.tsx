import { Box, Button, Container, Typography } from '@mui/material'
import { observer } from 'mobx-react-lite'
import React, { useContext } from 'react'
import RootStore from '../store/RootStore'
import { useNavigate } from 'react-router'

const Result = () => {
    let context = useContext(RootStore)
    let navigate = useNavigate();
    return (
        <Container maxWidth="sm">
            <Typography align='center' variant="h4" gutterBottom>
                {context.testStore.CurrentTest?.name}
            </Typography>
            <Typography align='center' variant="h3" gutterBottom>
                Result: {context.testStore.CurrentTest!.result}
            </Typography>
            <Box sx={{ display: "flex", justifyContent: "center" }}>
                <Button onClick={() => { navigate("/") }}>
                    Back
                </Button>
            </Box>
        </Container>
    )
}

export default observer(Result)
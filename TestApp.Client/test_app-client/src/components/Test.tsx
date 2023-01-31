import React, { useContext, useEffect, useState } from 'react'
import RootStore from '../store/RootStore'
import { observer } from 'mobx-react-lite'
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Checkbox from '@mui/material/Checkbox';
import { Box, Button, Container } from '@mui/material';
import { useNavigate } from 'react-router-dom';

const Test = () => {
    let context = useContext(RootStore)
    const [checked, setChecked] = useState("");
    const nagivate = useNavigate();
    useEffect(() => {
        if (!context.testStore.CurrentTestQuestion) {
            nagivate("/")
        }
    }, [])
    return (
        <Container maxWidth="sm">
            {context.testStore.CurrentTestQuestion?.description}
            <List sx={{ width: '100%', maxWidth: 360, bgcolor: 'background.paper' }}>
                {
                    context.testStore.CurrentTestQuestion?.options.map((o, i) =>
                        <ListItem
                            key={i}
                            disablePadding
                        >
                            <ListItemButton role={undefined} onClick={() => setChecked(checked === o.id ? "" : o.id)} dense>
                                <ListItemIcon>
                                    <Checkbox
                                        edge="start"
                                        checked={checked === o.id}
                                        tabIndex={-1}
                                        disableRipple
                                    />
                                </ListItemIcon>
                                <ListItemText id={o.id} primary={o.description} />
                            </ListItemButton>
                        </ListItem>
                    )
                }

            </List>
            <Box sx={{ display: "flex", justifyContent: "end" }}>
                <Button onClick={() => {
                    context.testStore.AnswerQuestion(checked)
                }}>{
                        context.testStore.CTQIndex === context.testStore.CurrentTestQuestions.length - 1 ? "Complete" :
                            "Next"}</Button>
            </Box>
        </Container>
    )
}

export default observer(Test)
import { Container, Typography } from "@mui/material"
import React, { useContext, useState, useEffect } from "react"
import TestDescriptionModal from "./TestDescriptionModal";
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Checkbox from '@mui/material/Checkbox';
import RootStore from '../store/RootStore';
import { observer } from 'mobx-react-lite';
import { useNavigate } from "react-router-dom";
const Main = () => {
    const [open, setOpen] = useState(false);
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [id, setId] = useState("");
    const openModal = (name: string, description: string, id: string) => {
        setName(name);
        setDescription(description);
        setOpen(true);
        setId(id);
    }
    let context = useContext(RootStore)
    const navigate = useNavigate();
    useEffect(() => {
        if (!context.userStore.isAuthorized) {
            navigate("/login")
        } else {
            context.testStore.GetTests();
        }
    }, [])
    return (
        <Container maxWidth="sm">
            <TestDescriptionModal open={open} handleClose={() => setOpen(false)} name={name} description={description} id={id} onProceed={() => { context.testStore.GetTestQuestions(id) }} />

            <List sx={{ width: '100%', maxWidth: 360, bgcolor: 'background.paper' }}>
                {
                    context.testStore.Tests.map((t, i) => <ListItem
                        key={i}
                        secondaryAction={
                            <Typography variant="subtitle1" gutterBottom>
                                {t.isCompleted ? `Result: ${t.result}` : "Not Completed"}
                            </Typography>
                        }
                    >
                        <ListItemButton disabled={t.isCompleted} role={undefined} onClick={() => { openModal(t.name, t.description, t.id) }} dense>
                            <ListItemText id={t.id} primary={t.name} />
                            <ListItemIcon>
                                <Checkbox
                                    edge="start"
                                    checked={t.isCompleted}
                                    tabIndex={-1}
                                    disableRipple
                                />
                            </ListItemIcon>
                        </ListItemButton>
                    </ListItem>)
                }
            </List>
        </Container>
    )
}
export default observer(Main)
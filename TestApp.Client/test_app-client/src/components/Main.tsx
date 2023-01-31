import { Button, Container, Typography } from "@mui/material"
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
        <Container sx={{ marginTop: "10px" }} maxWidth="sm">
            <TestDescriptionModal open={open} handleClose={() => setOpen(false)} name={name} description={description} id={id} onProceed={() => { context.testStore.GetTestQuestions(id) }} />

            <List sx={{ width: '100%', maxWidth: 500, bgcolor: 'background.paper' }}>
                {
                    context.testStore.Tests.map((t, i) => <ListItem
                        key={i}
                    // secondaryAction={


                    // }
                    >
                        <ListItemButton onClick={() => !t.isCompleted ? openModal(t.name, t.description, t.id) : context.testStore.selectTest(t.id)} dense>
                            <ListItemText id={t.id} primary={t.name} />
                            {
                                t.isCompleted ? <Typography variant="subtitle1" gutterBottom>
                                    Result: {t.result}
                                </Typography> : <Button>
                                    Start
                                </Button>
                            }
                        </ListItemButton>

                    </ListItem>)
                }
            </List>
        </Container>
    )
}
export default observer(Main)
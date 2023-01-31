import { createContext } from 'react';
import TestStore from './TestStore';
import UserStore from './UserStore';


export class RootStore {
    constructor(){
        this.testStore = new TestStore(this);
        this.userStore = new UserStore(this);
    }
    testStore:TestStore;
    userStore:UserStore;
}

export default createContext(new RootStore())
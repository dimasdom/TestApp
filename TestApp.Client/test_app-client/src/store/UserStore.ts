import { makeObservable, observable, action, runInAction } from "mobx";
import { testQuestionDTO } from "./models/testQuestionDTO";
import {test} from "./models/test"
import {loginDTO} from "./models/loginDTO"
import Agend from "./agend";
import { RootStore } from "./RootStore";
import history from "./history";
class UserStore {
    constructor(rootStore: RootStore){
        makeObservable(this)
        this.agend = new Agend();
    this.rootStore = rootStore;
    }
    rootStore:RootStore;
    @observable isAuthorized:boolean=false;
    agend:Agend;
    @action Login = async(login:loginDTO)=>{
        let result = await this.agend.Login(login);
        if(result.isSuccessfull){
            Agend.token=result.data;
            this.isAuthorized=true;
            history.push("/")
        }
    }
    @action Logout = ()=>{
        Agend.token="";
        this.isAuthorized=false;
        history.push("/login")
    }
}
export default UserStore
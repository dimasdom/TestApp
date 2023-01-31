import { makeObservable, observable, action, runInAction } from "mobx";
import { testQuestionDTO } from "./models/testQuestionDTO";
import {test} from "./models/test"
import {loginDTO} from "./models/loginDTO"
import Agend from "./agend";
import { RootStore } from "./RootStore";
import history from "./history";
class TestStore {
    constructor(rootStore: RootStore){
        makeObservable(this)
        this.agend = new Agend();
    this.rootStore = rootStore;
    }
    @observable CTQIndex:number=0;
    rootStore:RootStore;
    @observable Tests:test[]=[];
    @observable CurrentTestId:string="";
    @observable CurrentTestQuestion:testQuestionDTO|null=null;
    @observable CurrentAnswers:string[]=[];
    @observable CurrentTestQuestions:testQuestionDTO[]=[];
    agend:Agend;
    @action GetTests=async()=>{
        this.CurrentTestQuestions=[];
        this.CurrentTestQuestion=null;
        this.CurrentTestId="";
        let result=await this.agend.GetTests();
        this.Tests=result.data;
    }
    @action GetTestQuestions=async(testId:string)=>{
        let result=await this.agend.GetTestQuestions(testId);
        this.CurrentTestQuestions=result.data;
        this.CurrentTestQuestion=this.CurrentTestQuestions[0];
        this.CurrentTestId=testId;
        this.CTQIndex=0;
        history.push("/test");
    }
    @action AnswerQuestion=(optionId:string|void)=>{
        if(optionId){
            this.CurrentAnswers.push(optionId);
        }
        if(this.CTQIndex===this.CurrentTestQuestions.length-1){
            this.CompleteTest()
        }else{
            this.CTQIndex=++this.CTQIndex;
            this.CurrentTestQuestion=this.CurrentTestQuestions[this.CTQIndex];
        }   
    }
    @action CompleteTest=async()=>{
        let result = await this.agend.CompleteTest({
            id: this.CurrentTestId,
            answers: this.CurrentAnswers
        });
        if(result.isSuccessfull){
            
            this.GetTests();
            history.push("/");
        }
    }
}
export default TestStore
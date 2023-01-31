import { Result } from "./models/Result";
import { testResultDTO } from "./models/testResultDTO";
import { loginDTO } from "./models/loginDTO";
import {test} from "./models/test"
import { testCompleteDto } from "./models/testCompleteDTO";
import { testQuestionDTO } from "./models/testQuestionDTO";
class Agend{
    public static token:string="";
    public Login=async(login:loginDTO):Promise<Result<string>>=>{
        return fetch("https://localhost:7120/api/User/Login",
        this.FetchBody("POST",{},login))
        .then((response)=>response.json())
    }
    public GetTests=async():Promise<Result<test[]>>=>{
        return fetch("https://localhost:7120/api/Test",{
            headers:{Authorization:`Bearer ${Agend.token}` }
        })
        .then((response)=>response.json())
    }
    public GetTestQuestions=async(testId:string):Promise<Result<testQuestionDTO[]>>=>{
        return fetch(`https://localhost:7120/api/Test/TestQuestions?TestId=${testId}`,{
            headers:{Authorization:`Bearer ${Agend.token}` }
        })
        .then((response)=>response.json())
    }
    public CompleteTest=async(testComplete:testCompleteDto):Promise<Result<testResultDTO>>=>{
        return fetch("https://localhost:7120/api/Test/Complete",this.FetchBody("POST",{Authorization:`Bearer ${Agend.token}`},testComplete))
        .then((response)=>response.json())
    }
    private FetchBody=(method:string,headers: HeadersInit|undefined,data?:any):RequestInit=>{
        return{
            method: method,
            mode: 'cors', 
            cache: 'no-cache', 
            credentials: 'same-origin', 
            headers: {
              'Content-Type': 'application/json',
              ...headers
            },
            redirect: 'follow', 
            referrerPolicy: 'no-referrer', 
            body: JSON.stringify(data) 
          }
    }
}
export default Agend
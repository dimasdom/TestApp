export interface Result<T=undefined>{
isSuccessfull:boolean;
data:T;
errors:string[];
statusCode:number;
}
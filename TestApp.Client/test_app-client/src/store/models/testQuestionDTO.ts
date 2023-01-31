import { testQuestionOptionDTO } from "./testQuestionOptionDTO";

export interface testQuestionDTO{
    id:string;
    description:string;
    options:testQuestionOptionDTO[];
}
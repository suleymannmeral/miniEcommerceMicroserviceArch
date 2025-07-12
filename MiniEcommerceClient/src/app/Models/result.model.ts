export class ResultModel<T>{
     data?: T |  null;
     errorMessage?: string[] | null;
     isSuccessfull: boolean=false;
}
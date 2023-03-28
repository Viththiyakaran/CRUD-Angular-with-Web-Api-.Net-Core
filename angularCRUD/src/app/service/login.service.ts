import { Injectable } from '@angular/core';
import { HttpClient,} from "@angular/common/http";
import { Login } from '../model/login';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient : HttpClient) { }

  baseUrl = "http://localhost:5201/api/Login";


  // LoginEmployee(Log :Login) : Observable<Login[]>{
  //   //console.log(this.httpClient.post<Login[]>(this.baseUrl,Log))
  //   console.log(this.baseUrl,JSON.stringify(Log) + "RRRR");
  //   return this.httpClient.post<Login[]>(this.baseUrl,Log);


  // }


  LoginEmployee(Login : Array<string>){
     return this.httpClient.post(this.baseUrl,{
      Email : Login[0],
      Password : Login[1]
     },{
      responseType : 'text'
     })
  }


}

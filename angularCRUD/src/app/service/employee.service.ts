import { Injectable } from '@angular/core';
import { HttpClient} from "@angular/common/http";
import { Employee } from '../model/employee';
import { Observable } from 'rxjs';
import { Login } from '../model/login';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpClient : HttpClient) { }

  baseUrl = "http://localhost:5201/api/Employee";



  GetEmployee() : Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.baseUrl);
  }

  CreateEmployee( emp :Employee): Observable<Employee>{

    emp.id ="00000000-0000-0000-0000-000000000000";
    return this.httpClient.post<Employee>(this.baseUrl,emp);
  }


  UpdateEmployee( emp :Employee): Observable<Employee>{

    return this.httpClient.put<Employee>(this.baseUrl + '/' + emp.id,emp);
  }

  DeleteEmployee( id :string): Observable<Employee>{

    return this.httpClient.delete<Employee>(this.baseUrl + '/' + id);
  }


}

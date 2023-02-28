import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './service/employee.service';
import { Employee } from './model/employee';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  EmplyoeeArray: Employee[] = [];

  EmplyoeeFromGroup: FormGroup;

  constructor(private empService: EmployeeService, private fb: FormBuilder) {

    this.EmplyoeeFromGroup = this.fb.group({
      id: [""],
      name: [""],
      phone: [""],
      email: [""]
    })

  }



  ngOnInit(): void {

    this.getEmployee();
  }

  getEmployee() {
    this.empService.GetEmployee().subscribe(res => {
      console.log(res);
      this.EmplyoeeArray = res;
    });
  }

  OnSubmit() {

    console.log(this.EmplyoeeFromGroup.value);

    if (this.EmplyoeeFromGroup.value.id != null && this.EmplyoeeFromGroup.value.id != "")
    {
      this.empService.UpdateEmployee(this.EmplyoeeFromGroup.value).subscribe(res => {
        console.log(res);
        this.getEmployee();
        this.EmplyoeeFromGroup.setValue({
          id: "",
          name: "",
          phone: "",
          email: ""
        })
      })
    }
    else {
      this.empService.CreateEmployee(this.EmplyoeeFromGroup.value).subscribe(res => {
        console.log(res);
        this.getEmployee();
        this.EmplyoeeFromGroup.setValue({
          id: "",
          name: "",
          phone: "",
          email: ""
        })
      })
    }
  }

  FillForm(emp: Employee) {
    this.EmplyoeeFromGroup.setValue({
      id: emp.id,
      name: emp.name,
      phone: emp.phone,
      email: emp.email
    })
  }

  DeleteEmp(id : string){
    this.empService.DeleteEmployee(id).subscribe(
        res =>{ console.log(res); }
    )

    this.getEmployee();
  }

  title = 'angularCRUD';
}

import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/model/login';
import { LoginService } from 'src/app/service/login.service';
import { FormBuilder, FormGroup,FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {



  //LoginArray: Login[] = [];
  //LoginFromGroup: FormGroup ;

  constructor(private logService: LoginService, private fb: FormBuilder) {
    // this.LoginFromGroup = this.fb.group({
    //   empId: [""],
    //   id: [""],
    //   fullName: [""],
    //   email: [""],
    //   password: [""],
    //   designation:[""],
    //   accessToken:[""],
    //   createdDate: [""]
    // })





  }
  ngOnInit(): void {}


  LoginForm = new FormGroup({
    Email : new  FormControl(),
    Password : new   FormControl(),
 })


 LoginSubmit(){
   //console.log(this.LoginForm);
   this.logService.LoginEmployee([this.LoginForm.value.Email,this.LoginForm.value.Password]).subscribe(
    res => {
            console.log(res);
            // const token = (<any>res).token;
            // localStorage.setItem("jwt", token);

          })
 }



 get Email() : FormControl{
 return this.LoginForm.get('Email') as FormControl;
 }

 get PWD() : FormControl{
  return this.LoginForm.get('Password') as FormControl;
  }


  // OnSubmit() {

  //   console.log(this.LoginFromGroup.value);


  //     this.logService.LoginEmployee(this.LoginFromGroup.value).subscribe(res => {
  //       console.log(res);
  //       // const token = (<any>res).token;
  //       // localStorage.setItem("jwt", token);

  //     })
  //   }



}


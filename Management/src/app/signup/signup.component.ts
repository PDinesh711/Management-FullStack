import { Component } from '@angular/core';
import { User } from '../models/User';
import { Router } from '@angular/router';
import { FullstackService } from '../service/fullstack.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  loginArray:Array<any>=[];

  constructor(private route:Router,private apiService:FullstackService){
    this.getLogin();
  }
  // models   
  loginUser:User={
  userName:"",
  UserEmail:"",
  UserPhone:0,
  UserPassword:"",
  UserRepeatPassword:""
  }

  //login
  getLogin(){
    this.apiService.getLoginService().subscribe((data)=>{
this.loginArray=data;
console.log(data);
    })
  }

  createLogin(){
    this.apiService.createLoginService(this.loginUser).subscribe((data)=>{
      console.log(data);
      this.getLogin();
      this.route.navigate(['/login']);
    })
  }

 register(){

 }

}

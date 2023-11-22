import { Component } from '@angular/core';
import { User } from '../models/User';
import { FullstackService } from '../service/fullstack.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginArray: Array<any> = [];
  constructor(private apiServer: FullstackService, private router: Router) {
    this.getlogin();
  }
  getlogin() {
    this.apiServer.getLoginService().subscribe((data) => {
      console.log(data);
      this.loginArray = data;
    })
  }
  userName!: string;
  userPassword!: string;
  loginBtn() {
    for (let user = 0; user <= this.loginArray.length - 1; user++) {
      if (this.userName == this.loginArray[user].userEmail && this.userPassword == this.loginArray[user].userPassword) {
        console.log(this.userName);
        console.log(this.userPassword);
        this.router.navigate(['/home']);
        break;
      }
      else {
        console.log("invalid");
      }
    }
  }
}

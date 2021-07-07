import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Login } from '../Models/login';
import { Token } from '../Models/token';
import { LoginService } from '../Services/login.service';

@Component({
  selector: 'app-login-admin',
  templateUrl: './login-admin.component.html',
  styleUrls: ['./login-admin.component.css']
})
export class LoginAdminComponent implements OnInit {

  token!: Token;
  loginUser!: Login;
  constructor(private loginService: LoginService, private formBuilder: FormBuilder) { }
  loginForm: FormGroup = this.formBuilder.group({
    email: ["", Validators.required],
    password: ["", Validators.required]});

  ngOnInit() {

  }
  login() {
    this.loginUser = Object.assign({},this.loginForm.value)
    this.loginService.login(this.loginUser);
  }
  get isAuth(){
    console.log(this.loginService.loggedIn());
    return this.loginService.loggedIn();
  }

  logOut(){
    this.loginService.logOut();
  }
}

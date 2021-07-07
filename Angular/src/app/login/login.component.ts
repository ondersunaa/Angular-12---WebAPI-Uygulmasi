import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Login } from '../Models/login';
import { Token } from '../Models/token';
import { LoginService } from '../Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  token!: Token;
  loginUser!: Login;
  constructor(private loginService: LoginService, private formBuilder: FormBuilder) { }
  loginForm: FormGroup = this.formBuilder.group({
    email: ["", Validators.required],
    password: ["", Validators.required]
  });
  createLoginForm() {
    this.loginForm = this.formBuilder.group(
      {
        email: ["", Validators.required],
        password: ["", Validators.required]
      });

  }
  ngOnInit() {
    this.loginForm;
  }
  login() {
    console.log("geldi0");
    this.loginUser = Object.assign({},this.loginForm.value)
    this.loginService.login(this.loginUser);
  }
}

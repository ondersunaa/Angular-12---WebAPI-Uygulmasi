import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import { Login } from '../Models/login';
import { Token } from '../Models/token';
import { JwtHelperService } from "@auth0/angular-jwt";
import { AlertfyService } from './alertfy.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  jwtHelper = new JwtHelperService();
  decodedToke: any;
  constructor(private http: HttpClient, private router: Router,private alertifyService : AlertfyService) { }
  url = "https://localhost:44363/api/auth/createtoken";
  TOKEN_KEY ="token";
  tokenKey! : string;
  login(login: Login) {
    this.http.post<Token>(this.url, login).subscribe(data => {
      this.tokenKey = data.token;
      this.saveToken(data.token);
      this.decodedToke = this.jwtHelper.decodeToken(data.token);
      var a = this.loggedIn();
      console.log(a);
      if(this.loggedIn()){
        this.router.navigateByUrl('admin/home');
      }

    },err=>{
        this.alertifyService.error('Giriş Başarısız');
    });
  }
 loggedIn(){
   const token = localStorage.getItem(this.TOKEN_KEY);
   return !this.jwtHelper.isTokenExpired(token?.toString());
 }
  saveToken(token: string) {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  logOut(){
    localStorage.removeItem(this.TOKEN_KEY);
  }
}

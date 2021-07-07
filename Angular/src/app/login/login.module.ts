import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import {  FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormGroup,
    FormBuilder,
    Validators,
    FormControl
  ],
  declarations: [
    LoginComponent
  ]
})
export class LoginModule { }

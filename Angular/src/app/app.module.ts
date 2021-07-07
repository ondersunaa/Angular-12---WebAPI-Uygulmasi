import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormGroup, FormControl, FormBuilder, Validators,FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainpageComponent } from './mainpage/mainpage.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CargoInfoComponent } from './cargo-info/cargo-info.component';
import { Router, NavigationEnd } from '@angular/router';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatInputModule} from '@angular/material/input';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { CommonModule } from "@angular/common";
import {MatExpansionModule} from '@angular/material/expansion';
import {MatTabsModule} from '@angular/material/tabs';
import { NotFoundComponent } from './not-found/not-found.component';
import { LoginAdminComponent } from './login-admin/login-admin.component';
import { AlertfyService } from './Services/alertfy.service';
import { AdminComponent } from './admin/admin.component';
import { AdminMainComponent } from './admin/admin-main/admin-main.component';
import {Chart }from 'chart.js'
@NgModule({
  declarations: [
    AppComponent,
      MainpageComponent,
      CargoInfoComponent,
      NotFoundComponent,
      LoginAdminComponent,
      AdminComponent,
      AdminMainComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatFormFieldModule,
    MatButtonModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatAutocompleteModule,
    CommonModule,
    MatExpansionModule,
    MatTabsModule


  ],
  providers: [
    AlertfyService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

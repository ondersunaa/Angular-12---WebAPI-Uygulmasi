import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminMainComponent } from './admin/admin-main/admin-main.component';
import { AdminComponent } from './admin/admin.component';
import { CargoInfoComponent } from './cargo-info/cargo-info.component';
import { LoginAdminComponent } from './login-admin/login-admin.component';
import { LoginComponent } from './login/login.component';
import { MainpageComponent } from './mainpage/mainpage.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  {path: "",  component: MainpageComponent, pathMatch: "full"},
  {path:"cargoInfo/:cargoNumber" , component:CargoInfoComponent},
  {path:"notFound" , component:NotFoundComponent},
  {path:"home" , component:MainpageComponent},
  {path:"loginAdminForm" , component:LoginAdminComponent},
  {path:"admin" , component:AdminComponent,children:[
    {path:"home",component:AdminMainComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }

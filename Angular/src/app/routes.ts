import {Routes} from "@angular/router"
import { CargoInfoComponent } from "./cargo-info/cargo-info.component";
import { MainpageComponent } from "./mainpage/mainpage.component";
export const appRoutes : Routes = [
  {path:"" , component:MainpageComponent},
  {path:"**" , redirectTo:"/mainpage",pathMatch:"full"},
  { path: "", redirectTo: '/mainpage', pathMatch: 'full' },
  {path:"cargoInfo/cargoNumber" , component:CargoInfoComponent},
];

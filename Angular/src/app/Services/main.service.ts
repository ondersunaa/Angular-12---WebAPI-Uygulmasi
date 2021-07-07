import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CargoInfo } from '../Models/CargoInfo';
@Injectable({
  providedIn: 'root'
})
export class MainService {
path = "https://localhost:44363/api/cargoinfos/";
constructor(private http:HttpClient,private router:Router) { }
get(cargoNumber:string):Observable<CargoInfo>{
  console.log(cargoNumber);

  var res = this.http.get<CargoInfo>(this.path+cargoNumber)
  res.subscribe(err=>{
    if(err.cargoNumber == null){
      this.router.navigateByUrl('notFound');
    }
    else{
      this.router.navigateByUrl('/cargoInfo/'+cargoNumber);
    }
  })

  return this.http.get<CargoInfo>(this.path+cargoNumber);


}
}

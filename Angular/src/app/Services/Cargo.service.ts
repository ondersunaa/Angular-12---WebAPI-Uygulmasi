import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CargoInfo } from '../Models/CargoInfo';

@Injectable({
  providedIn: 'root'
})
export class CargoService {

constructor(private http:HttpClient) { }
cargos! : CargoInfo[];
path = "https://localhost:44363/api/cargoinfos/";
get():Observable<CargoInfo[]>{
  return this.http.get<CargoInfo[]>(this.path);
}
}

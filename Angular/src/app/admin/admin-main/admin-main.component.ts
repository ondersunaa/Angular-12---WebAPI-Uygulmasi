import { Component, OnInit } from '@angular/core';
import { CargoInfo } from 'src/app/Models/CargoInfo';
import { CargoService } from 'src/app/Services/Cargo.service';


@Component({
  selector: 'app-admin-main',
  templateUrl: './admin-main.component.html',
  styleUrls: ['./admin-main.component.css']
})
export class AdminMainComponent implements OnInit {

  constructor(private cargoService : CargoService) { }
  cargos! : CargoInfo[];
  ngOnInit() {
    this.cargoService.get().subscribe(data =>{
      this.cargos = data;});
  }
get(){


}
}

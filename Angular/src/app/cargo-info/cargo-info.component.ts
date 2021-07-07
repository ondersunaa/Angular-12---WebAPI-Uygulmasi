import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CargoInfo } from '../Models/CargoInfo';
import { AlertfyService } from '../Services/alertfy.service';
import { MainService } from '../Services/main.service';
import { Location } from '@angular/common'
@Component({
  selector: 'app-cargo-info',
  templateUrl: './cargo-info.component.html',
  styleUrls: ['./cargo-info.component.css']
})
export class CargoInfoComponent implements OnInit {
  cargoNumber!:string;
  constructor(private activetedRoute : ActivatedRoute, private mainService : MainService,private router : Router,private alertify : AlertfyService, private loc : Location) { }
  cargoInfo! : CargoInfo;
  ngOnInit() {
    this.activetedRoute.params.subscribe(params=>{
     return this.get(params['cargoNumber'])
    },
    err=>{
      console.log(err);
    }
    )
  }

  get(cargoNumber : string){
    this.mainService.get(cargoNumber).subscribe(res=>{
     console.log(res);
     this.alertify.success("Başarılı");
     return this.cargoInfo = res;
    },
    err=>{
      console.log(err);
      if(err['status']==400){
        this.alertify.error("Hatalı Kargo Numarası");
        this.loc.back();
      }

    }
    )

  }

}

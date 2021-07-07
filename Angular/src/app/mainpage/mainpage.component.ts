import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MainService } from '../Services/main.service';
import {MatFormFieldModule} from '@angular/material/form-field';
import { CargoInfo } from '../Models/CargoInfo';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-mainpage',
  templateUrl: './mainpage.component.html',
  styleUrls: ['./mainpage.component.css']
})
export class MainpageComponent implements OnInit {
  cargoInfo! : CargoInfo;
  floatLabelControl = new FormControl('auto');
  constructor(private formBuilder: FormBuilder,private cargoService:MainService, private router:Router) { }
  cargo!:any
  getCargo: FormGroup = this.formBuilder.group({cargoNumber: ["", Validators.required]},{floatLabel: this.floatLabelControl});
  ngOnInit() {


  }
get(){
  console.log(this.getCargo.value);
  this.cargo = Object.assign({}, this.getCargo.value)
this.cargoService.get(this.cargo['cargoNumber']).subscribe(data=>{
  this.cargoInfo =data;
  console.log(this.cargoInfo);

})
}
scroll(el: HTMLElement) {
  el.scrollIntoView();
}
}

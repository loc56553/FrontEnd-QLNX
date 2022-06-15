import { VeXeView } from './../../../models/VeXeView';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { VeXe } from './../../../models/VeXe';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { DataService } from 'src/app/Services/data.service';
import { Router } from '@angular/router';
import { ChuyenXe } from 'src/models/ChuyenXe';
import { GheNgoi } from 'src/models/GheNgoi';

@Component({
  selector: 'app-FormDatVe',
  templateUrl: './FormDatVe.component.html',
  styleUrls: ['./FormDatVe.component.scss']
})
export class FormDatVeComponent implements OnInit,OnChanges{
  @Input() msCX:string;
  @Input() Ghe:GheNgoi;
  private url='http://localhost:13730/api/VeXe';
  private urlCx='http://localhost:13730/api/ChuyenXe';
  private urlGhe='http://localhost:13730/api/ChuyenXe/OneGhe';
  veXe: VeXe;
  vexeView: VeXeView;
  chuyenXe: ChuyenXe;
  constructor(private rest : ServerHttpService ,private data : DataService , private route : Router) {
    this.veXe=new VeXe();
    this.chuyenXe=new ChuyenXe();
   }
  ngOnChanges(changes: SimpleChanges): void {
    if(this.Ghe.trangThai===1)
    {
      this.getVeXe();
    }
  }

  ngOnInit() {
    this.getChuyenXe();
  }
  getChuyenXe(){
    this.rest.getOne(this.urlCx,this.msCX).then(data => {
      this.chuyenXe = data as ChuyenXe;
    }).catch(error=>{
      if(error!=null)
      {
        console.log(error);
      }
    });
  }
  getVeXe(){
    this.rest.getVeXe(this.url,this.msCX,this.Ghe.tenGhe).then(data=>{
      this.vexeView=data as VeXeView;
      console.log(this.vexeView);
    }).catch(error=>{
      if(error!=null)
      {
        console.log(error);
      }
    });
  }
  addVe(){
    this.veXe.ngayDi=this.chuyenXe.ngayDi;
    this.veXe.soGhe=this.Ghe.tenGhe;
    this.veXe.maCX=this.msCX;
    console.log(this.veXe);
    this.rest.post(this.url,this.veXe).then(data=>{
      console.log(data);
    }).catch(error=>{
      if(error!=null){
        console.log(error);
      }
    })
    this.Ghe.trangThai = 1;
    this.rest.putGhe(this.urlGhe,this.Ghe).then(data=>{
      console.log(data);
    }).catch(error=>{
      if(error!=null){
        console.log(error);
      }
    })
    location.reload();
  }
  DeleteVe(){
    this.Ghe.trangThai = 0;
    this.rest.putGhe(this.urlGhe,this.Ghe).then(data=>{
      console.log(data);
    }).catch(error=>{
      if(error!=null){
        console.log(error);
      }
    })
    this.rest.delete(this.url,this.vexeView.msVe).then(data=>{
      console.log(data);
      location.reload();
    }).catch(error=>{
      if(error!=null){
        console.log(error);
      }
    })
  }
}

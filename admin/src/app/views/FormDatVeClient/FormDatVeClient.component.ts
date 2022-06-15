import { ChuyenXe } from './../../../models/ChuyenXe';
import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { GheNgoi } from 'src/models/GheNgoi';
import { VeXe } from 'src/models/VeXe';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { DataService } from 'src/app/Services/data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-FormDatVeClient',
  templateUrl: './FormDatVeClient.component.html',
  styleUrls: ['./FormDatVeClient.component.scss']
})
export class FormDatVeClientComponent implements OnInit {

  @Input() msCX:string;
  @Input() soGhe:string;
  private url='http://localhost:13730/api/VeXe';
  private urlCx='http://localhost:13730/api/ChuyenXe';
  private urlGhe='http://localhost:13730/api/ChuyenXe/OneGhe';
  veXe: VeXe;
  gheNgoi:GheNgoi;
  chuyenXe: ChuyenXe;
  constructor(private rest : ServerHttpService ,private data : DataService , private route : Router) {
    this.veXe=new VeXe();
    this.chuyenXe=new ChuyenXe();
   }
  ngOnChanges(changes: SimpleChanges): void {
    console.log('ngOnchanges:FormDatVeComponent');
  }

  ngOnInit() {
    this.getChuyenXe();
    this.getGheXe();
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
  getGheXe(){
    this.rest.getGheXe(this.urlCx,this.msCX,this.soGhe).then(data=>{
      this.gheNgoi= data as GheNgoi;
      console.log(this.gheNgoi);
    }).catch(error=>{
      if(error!=null){
        console.log(error);
      }
    })
  }
  addVe(){
    this.veXe.ngayDi=this.chuyenXe.ngayDi;
    this.veXe.soGhe=this.gheNgoi.tenGhe;
    this.veXe.maCX=this.msCX;
    console.log(this.veXe);
    this.rest.post(this.url,this.veXe).then(data=>{
      console.log(data);
    }).catch(error=>{
      if(error!=null){
        console.log(error);
      }
    })
    this.gheNgoi.trangThai = 1;
    this.rest.putGhe(this.urlGhe,this.gheNgoi).then(data=>{
      console.log(data);
    }).catch(error=>{
      if(error!=null){
        console.log(error);
      }
    })
    location.reload();
  }
  DeleteVe(){
    this.gheNgoi.trangThai = 0;
    this.rest.putGhe(this.urlGhe,this.gheNgoi).then(data=>{
      console.log(data);
    }).catch(error=>{
      if(error!=null){
        console.log(error);
      }
    })
    //this.rest.delete(this.url,)
  }
}


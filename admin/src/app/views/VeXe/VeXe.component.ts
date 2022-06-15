import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { ChuyenXe } from 'src/models/ChuyenXe';
import { LoaiXe } from 'src/models/LoaiXe';
import { TuyenDuong } from 'src/models/TuyenDuong';

@Component({
  selector: 'app-VeXe',
  templateUrl: './VeXe.component.html',
  styleUrls: ['./VeXe.component.scss']
})
export class VeXeComponent implements OnInit {
  tuyenDuongs!:TuyenDuong[];
  loaiXes!:LoaiXe[];
  chuyenXes!: ChuyenXe[];
  maTD:string;
  time:string;
  tenLX:string;
  private urlTD='http://localhost:13730/api/TuyenDuong';
  private urlLX='http://localhost:13730/api/LoaiXe';
  private urlCX='http://localhost:13730/api/ChuyenXe';
  constructor(private rest : ServerHttpService ,private data : DataService,private route : Router ,private router:ActivatedRoute) { }

  ngOnInit() {
  this.getListTD();
  this.getListLX();
  }
  
  getListTD(){
    this.rest.get(this.urlTD).then(data =>{
      this.tuyenDuongs= data as TuyenDuong[];
    }).catch(error=>{
      if(error!==null)
      {
        console.log(error);
      }
    })
  }
  getListLX()
  {
    this.rest.get(this.urlLX).then(data =>{
      this.loaiXes= data as LoaiXe[];
    }).catch(error=>{
      if(error!==null)
      {
        console.log(error);
      }
    })
  }
  getListChuyenXe(){
    this.rest.getListChuyenXe(this.urlCX,this.maTD,this.time,this.tenLX).then(data =>{
      this.chuyenXes = data as ChuyenXe[];
      console.log(this.chuyenXes);
    }).catch(error=>{
      if(error!==null)
      console.log(error);
    })
  }
  FormVe(mscx:string){
    this.route.navigate(['Add-VeXe'+'/'+ mscx]);
  }
}

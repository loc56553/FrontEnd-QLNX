import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { ChuyenXe } from 'src/models/ChuyenXe';
import { LoaiXe } from 'src/models/LoaiXe';
import { TuyenDuong } from 'src/models/TuyenDuong';

@Component({
  selector: 'app-Add-ChuyenXe',
  templateUrl: './Add-ChuyenXe.component.html',
  styleUrls: ['./Add-ChuyenXe.component.scss']
})
export class AddChuyenXeComponent implements OnInit {
private url='http://localhost:13730/api/ChuyenXe';
private urlTD='http://localhost:13730/api/TuyenDuong';
private urlLX='http://localhost:13730/api/LoaiXe';
tuyenDuongs!:TuyenDuong[];
chuyenXe:ChuyenXe;
loaiXes!:LoaiXe[];
msCX:string;
  constructor(private rest : ServerHttpService ,private data : DataService,private route : Router ,private router:ActivatedRoute)
   {
     this.chuyenXe=new ChuyenXe();
     this.msCX= this.router.snapshot.params['id'];
   }

  ngOnInit() 
  {
    if(this.msCX!=null)
    {
      this.getOneCX();
    }
    this.getListLX();
    this.getListTD();
  }

  addNV()
  {
    if(this.msCX!=null)
    {
      this.rest.put(this.url,this.msCX,this.chuyenXe).then(data => {
        data as string;
        console.log(data);
        this.route.navigate(['ChuyenXe']);
      }).catch(error=>{
        if(error!=null)
        console.log(error);
      })
    }
    else
    {
      this.rest.post(this.url,this.chuyenXe).then(data =>{
        data as string;
        console.log(data);
        this.route.navigate(['ChuyenXe']);
      }).catch(error=>{
        if(error!=null)
        console.log(error);
      })
    }
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
getOneCX(){
  this.rest.getOne(this.url,this.msCX).then(data =>{
    this.chuyenXe=data as ChuyenXe;
    console.log(this.chuyenXe)
  }).catch(error=>{
    if(error!=null)
    console.log(error);
  })
}
}

import { ChucVu } from './../../../models/ChucVu';
import { NhanVien } from './../../../models/NhanVien';
import { Component, OnInit } from '@angular/core';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { DataService } from 'src/app/Services/data.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-Add-NhanVien',
  templateUrl: './Add-NhanVien.component.html',
  styleUrls: ['./Add-NhanVien.component.scss']
})
export class AddNhanVienComponent implements OnInit {
  public chucVu !: ChucVu[];
  public nhanVien : NhanVien;
  public MSNV : string;
  private urlNv = 'http://localhost:13730/api/NhanVien';
  private url ='http://localhost:13730/api/NhanVien/Dky';
  private urlCv='http://localhost:13730/api/ChucVu';
  private msNV:string;
  constructor(private rest : ServerHttpService ,private data : DataService,private route:Router,private router:ActivatedRoute) {  
    this.nhanVien = new NhanVien();
    this.msNV = this.router.snapshot.params['id']
  }
  ngOnInit() { 
    {
      this.rest.get(this.urlCv).then(data=>{
        this.chucVu = (data as ChucVu[]);
      }).catch(error=>{
        if(error!=null)
        {
          alert(this.data.error(error['message']));
        }    
      })
    }
    if(this.msNV!=null)
    {
      this.rest.getOne(this.urlNv,this.msNV).then(data=>{
        this.nhanVien.hoTen=(data as NhanVien).hoTen;
        this.nhanVien.chucVu=(data as NhanVien).chucVu;
        this.nhanVien.soDienThoai=(data as NhanVien).soDienThoai;
      }).catch(error=>{
        if(error!=null)
        {
          console.log(error['message']);
        }
      })
    }
}
addNV(){
  if(this.msNV!=null)
  {
    this.rest.put(this.urlNv,this.msNV,this.nhanVien).then(data=>{
      let value = (data as string);
      this.route.navigate(['NhanVien']); 
      console.log(value);
    }).catch(error=>{
      if(error!=null)
      {
        console.log(this.data.error(error));
      }
    })   
  }
  else
  {
    this.rest.post(this.url,this.nhanVien).then(data=>{
      let value = (data as NhanVien);
      console.log(value);
      this.route.navigate(['NhanVien']);
    }).catch(error=>{
      if(error!=null)
      {
        console.log(error['message']);
      }    
    })
  }
}
}

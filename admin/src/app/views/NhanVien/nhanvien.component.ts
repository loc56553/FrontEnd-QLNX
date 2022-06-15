import { NhanVien } from './../../../models/NhanVien';
import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { Router } from '@angular/router';



@Component({
  selector:'app-nv',
  templateUrl:'nhanvien.component.html',
  styleUrls: ['nhanvien.component.scss']
})
export class NhanVienComponent implements OnInit {
  public nhanviens! : NhanVien[];
  public nhanvien: NhanVien;
  private url ='http://localhost:13730/api/NhanVien';
  constructor(private rest : ServerHttpService ,private data : DataService , private route : Router ) {  
  }
  ngOnInit() {
    this.rest.get(this.url).then(data=>{
      this.nhanviens = (data as NhanVien[])
      console.log(this.nhanviens);
    }).catch(error=>{
      if(error!=null)
      {
        console.log(error);
      }    
    })
}
getOneNV(userName:string){  
    this.route.navigate(['Add-NhanVien'+'/'+ userName]);
}
FormAddNV()
{
  this.route.navigate(['Add-NhanVien']);
}
Delete(userName:string)
{
  this.rest.delete(this.url,userName).then(data=>{
    let message = data ;
    console.log(message);
    location.reload()
  })
}
}

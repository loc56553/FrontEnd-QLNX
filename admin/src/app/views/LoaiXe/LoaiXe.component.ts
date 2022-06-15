import { LoaiXe } from './../../../models/LoaiXe';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';

@Component({
  selector: 'app-LoaiXe',
  templateUrl: './LoaiXe.component.html',
  styleUrls: ['./LoaiXe.component.scss']
})
export class LoaiXeComponent implements OnInit {
  private url='http://localhost:13730/api/LoaiXe';
  loaiXes!: LoaiXe[];
  constructor(private rest : ServerHttpService ,private data : DataService , private route : Router) {
   }

  ngOnInit() {
    this.rest.get(this.url).then(data=>{
      this.loaiXes = data as LoaiXe[];
      console.log(this.loaiXes);
    }).catch(error=>{
      console.log(error.message);
    })
  }
  getOneLX(msLX:string){
    this.route.navigate(['Add-LoaiXe'+'/'+msLX]);
  }
  Delete(msLX:string){
    this.rest.delete(this.url,msLX).then(data=>{
      let message = data as {messsage:string};
      console.log(message);
      location.reload();
    }).catch(error=>{
      if(error!=null)
      console.log(error.message);
    })
  }
  FormAddLX(){
    this.route.navigate(['Add-LoaiXe']);
}
}

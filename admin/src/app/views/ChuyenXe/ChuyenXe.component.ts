import { ChuyenXe } from './../../../models/ChuyenXe';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';

@Component({
  selector: 'app-ChuyenXe',
  templateUrl: './ChuyenXe.component.html',
  styleUrls: ['./ChuyenXe.component.scss']
})
export class ChuyenXeComponent implements OnInit {
private url='http://localhost:13730/api/ChuyenXe';
chuyenXeS!: ChuyenXe[];
  constructor(private rest : ServerHttpService ,private data : DataService , private route : Router)
   {

   }

  ngOnInit() {
    this.getListChuyenXe();
  }
  getListChuyenXe(){
    this.rest.get(this.url).then(data=>{
      this.chuyenXeS = data as ChuyenXe[];
      console.log(this.chuyenXeS);
    }).catch(error=>{
      if(error!=null)
      console.log(error);
    })
  }
  getOneCV(msCX: string){
    this.route.navigate(['Add-ChuyenXe'+'/'+msCX]);
  }
  Delete(msCX: string){
    this.rest.delete(this.url,msCX).then(data=>{
      data as string;
      console.log(data);
      location.reload();
    }).catch(error=>{
      if(error!=null)
      console.log(error);
    })
  }
  FormAddCV(){
    this.route.navigate(['Add-ChuyenXe']);
  }
}

import { TuyenDuong } from './../../../models/TuyenDuong';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';

@Component({
  selector: 'app-TuyenDuong',
  templateUrl: './TuyenDuong.component.html',
  styleUrls: ['./TuyenDuong.component.scss']
})
export class TuyenDuongComponent implements OnInit {
  private url='http://localhost:13730/api/TuyenDuong';
  tuyenDuongs!: TuyenDuong[];
  constructor(private rest : ServerHttpService ,private data : DataService , private route : Router )
  {

  }
  ngOnInit() {
    this.getListTD();
  }
  getListTD()
  {
    this.rest.get(this.url).then(data=>{
      this.tuyenDuongs = data as TuyenDuong[];
      console.log(this.tuyenDuongs);
    }).catch(error=>{
      if(error!=null)
      {
        console.log(error);
      }
    })
  }
  getOneTD(msTD:string){
    this.route.navigate(['Add-TuyenDuong'+'/'+ msTD]);
  }
  Delete(msTD:string){
    this.rest.delete(this.url,msTD).then(data=>{
      data as {message:string};
      console.log(data);
      location.reload();
    }).catch(error=>{
      if(error!=null)
      console.log(error);
    })
  }
  FormAddXe()
  {
    this.route.navigate(['Add-TuyenDuong']);
  }

}

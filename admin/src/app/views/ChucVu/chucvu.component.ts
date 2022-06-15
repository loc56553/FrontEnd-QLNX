import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { ChucVu } from 'src/models/ChucVu';

@Component({
  selector: 'app-ChucVu',
  templateUrl: './chucVu.component.html',
  styleUrls: ['./chucVu.component.scss']
})
export class ChucVuComponent implements OnInit {
  private url='http://localhost:13730/api/ChucVu';
  chucVus!: ChucVu[];
  
  constructor(private rest : ServerHttpService ,private data : DataService , private route : Router) { }

  ngOnInit(){
    this.rest.get(this.url).then(data=>{
      this.chucVus = (data as ChucVu[]);
      console.log(data);    
    }).catch(error=>{
      if(error!=null)
      console.log(error);
    })
  }
public FormAddCV(){
  this.route.navigate(['Add-ChucVu']);
  }
public Delete(msCV:string){
  this.rest.delete(this.url,msCV).then(data=>{

    location.reload()
}).catch(error=>{
  if(error!=null)
  alert(this.data.error(error.message));
})
}
public getOneCV(msCV:string){
  this.route.navigate(['Add-ChucVu'+'/'+ msCV]);
}
}

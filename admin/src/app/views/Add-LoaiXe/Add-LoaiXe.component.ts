import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { LoaiXe } from 'src/models/LoaiXe';

@Component({
  selector: 'app-Add-LoaiXe',
  templateUrl: './Add-LoaiXe.component.html',
  styleUrls: ['./Add-LoaiXe.component.scss']
})
export class AddLoaiXeComponent implements OnInit {
  private url='http://localhost:13730/api/LoaiXe';
  loaiXe : LoaiXe;
  msLX:string;
  constructor(private rest : ServerHttpService ,private data : DataService,private route:Router,private Router:ActivatedRoute) { 
    this.loaiXe=new LoaiXe();
    this.msLX=Router.snapshot.params['id'];
  }

  ngOnInit() {
    if(this.msLX!=null)
    {
      this.rest.getOne(this.url,this.msLX).then(data => {
        this.loaiXe = data as LoaiXe;
        console.log(data);
      }).catch(error=>{
        if(error!=null)
        console.log(error);
      })
    }
  }
  addLX(){
    if(this.msLX!=null)
    {
      this.rest.put(this.url,this.msLX,this.loaiXe).then(data => {
        data as {message:string};
        console.log(data);
        this.route.navigate(['LoaiXe']);
      }).catch(error=>{
        if(error!=null)
        {
          console.log(error);
        }
      })
    }
    else
    {
      this.rest.post(this.url,this.loaiXe).then(data =>{
        data as {message:string}
        console.log(data);
        this.route.navigate(['LoaiXe']);
      }).catch(error=>{
        if(error!=null)
        {
          console.log(error);
        }
      })
    }
  }
}

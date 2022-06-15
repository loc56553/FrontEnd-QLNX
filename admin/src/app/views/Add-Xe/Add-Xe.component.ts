import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { LoaiXe } from 'src/models/LoaiXe';
import { Xe } from 'src/models/Xe';

@Component({
  selector: 'app-Add-Xe',
  templateUrl: './Add-Xe.component.html',
  styleUrls: ['./Add-Xe.component.scss']
})
export class AddXeComponent implements OnInit {
private url ='http://localhost:13730/api/Xe';
private urlLX ='http://localhost:13730/api/LoaiXe';
 xE:Xe;
 listLoaiXe!: LoaiXe[];
  bsXE:string;
  constructor(private rest:ServerHttpService , private data : DataService,private router:ActivatedRoute ,private route: Router)
   { 
     this.xE= new Xe();
     this.bsXE= this.router.snapshot.params['id'];
   }
  ngOnInit() {   
    if(this.bsXE!=null) {
      this.getOneXe();
    }
    this.getListLoaiXe();
  }
  getListLoaiXe(){
    this.rest.get(this.urlLX).then(data=>{
      this.listLoaiXe = data as LoaiXe[];
      console.log(this.listLoaiXe);
    }).catch(error=>{
      console.log(error.message);
    })
  }
  addXE(){
    if(this.bsXE!=null)
    {
      this.rest.put(this.url,this.bsXE,this.xE).then(data => {
        data as {message:string};
        console.log(data);
        this.route.navigate(['Xe']);
      }).catch(error=>{
        if(error!=null)
        {
          console.log(error);
        }
      })
    }
    else
    {
      this.rest.post(this.url,this.xE).then(data =>{
        data as {message:string}
        console.log(data);
        this.route.navigate(['Xe']);
      }).catch(error=>{
        if(error!=null)
        {
          console.log(error);
        }
      })
    }
  }
  getOneXe()
  {  
  this.rest.getOne(this.url,this.bsXE).then(data =>{
        this.xE=data as Xe;
        console.log(this.xE);
      }).catch(error=>{
        if(error!=null)
        {
          console.log(error);
        }
      })
    }
  }


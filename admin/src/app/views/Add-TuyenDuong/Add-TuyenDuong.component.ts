import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { TuyenDuong } from 'src/models/TuyenDuong';

@Component({
  selector: 'app-Add-TuyenDuong',
  templateUrl: './Add-TuyenDuong.component.html',
  styleUrls: ['./Add-TuyenDuong.component.scss']
})
export class AddTuyenDuongComponent implements OnInit {
private url = 'http://localhost:13730/api/TuyenDuong';
tuyenDuong:TuyenDuong;
msTD:string;
  constructor(private rest : ServerHttpService ,private data : DataService,private route:Router,private router:ActivatedRoute)
   { 
     this.tuyenDuong=new TuyenDuong();
     this.msTD= this.router.snapshot.params['id'];
   }

  ngOnInit() {
    if(this.msTD!=null)
    {
      this.getOneTD();
    }
  }
  addTD(){
    if(this.msTD!=null)
    {
      
      this.rest.put(this.url,this.msTD,this.tuyenDuong).then(data => {
        let value=data as {message:Message};
        console.log(value.message);
        this.route.navigate(['TuyenDuong']);
    }).catch(error=>{
      if(error!=null)
      {
        console.log(error);
      }
    })
  }
    else
    {
      
      this.rest.post(this.url,this.tuyenDuong).then(data => {
        let value =data as {message:Message};
        console.log(value.message);
        this.route.navigate(['TuyenDuong']);
      }).catch(error=>{
        if(error!=null)
        console.log(error.message);
    })
  }
  }
   getOneTD(){
    this.rest.getOne(this.url,this.msTD).then(data =>{
      this.tuyenDuong= data as TuyenDuong;
      console.log(this.tuyenDuong);
    }).catch(error=>{
      if(error!=null)
      console.log(error);
    })
  }
}

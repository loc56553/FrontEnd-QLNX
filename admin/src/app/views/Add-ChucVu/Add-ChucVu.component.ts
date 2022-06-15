import { ChucVu } from 'src/models/ChucVu';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';

@Component({
  selector: 'app-Add-ChucVu',
  templateUrl: './Add-ChucVu.component.html',
  styleUrls: ['./Add-ChucVu.component.scss']
})
export class AddChucVuComponent implements OnInit {
  private url ='http://localhost:13730/api/ChucVu';
  public chucVu: ChucVu;
  public msCV : string;
  constructor(private rest : ServerHttpService ,private data : DataService,private route:Router,private router:ActivatedRoute) { 
    this.chucVu=new ChucVu();
    this.msCV = this.router.snapshot.params['id']
  }

  ngOnInit() {
    if(this.msCV !=null)
    {
      this.rest.getOne(this.url,this.msCV).then(data=>{
        this.chucVu= data as ChucVu;
      }).catch(error=>{
        if(error!=null)
        {
          console.log(error['message']);
        }
      })
    }
  }
  addCV(){
    if(this.msCV != null)
    {
      this.rest.put(this.url,this.msCV,this.chucVu).then(data=>{
        let message = data as {message:string};
        console.log(message.message);
        this.route.navigate(['ChucVu']);
      }).catch(error=>{
        if(error!=null)
        {
          console.log(error);
        }
      })
    }
    else
    {
      this.rest.post(this.url,this.chucVu).then(data =>{
        this.route.navigate(['ChucVu']);
      }).catch(err =>{
        if(err!=null)
        {
          console.log(err);
        }
      }
     )
    }
  }
}

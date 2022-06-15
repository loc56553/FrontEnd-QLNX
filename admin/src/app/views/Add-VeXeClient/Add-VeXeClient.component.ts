import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { GheNgoi } from 'src/models/GheNgoi';

@Component({
  selector: 'app-Add-VeXeClient',
  templateUrl: './Add-VeXeClient.component.html',
  styleUrls: ['./Add-VeXeClient.component.scss']
})
export class AddVeXeClientComponent implements OnInit {

  mscx:string;
  soGhe:string;
  formVe:boolean=false;
  listGhe!:GheNgoi[];
  listGheTren!:GheNgoi[];
  listGheTrai:GheNgoi[]=[];
  listGhePhai:GheNgoi[]=[];
  listGheTrenTrai:GheNgoi[]=[];
  listGheTrenPhai:GheNgoi[]=[];
  status:boolean=false;
  private urlduoi='http://localhost:13730/api/ChuyenXe/GheDuoi';
  private urltren='http://localhost:13730/api/ChuyenXe/GheTren';
    constructor(private rest:ServerHttpService , private data : DataService,private router:ActivatedRoute ,private route: Router) 
    {
      this.mscx=this.router.snapshot.params['id'];
    }
  
    ngOnInit() {
      if(this.mscx!=null)
      {
        this.getListGheDuoi();
        this.getListGheTren();
      }
    }
  
    getListGheDuoi(){
      this.rest.getOne(this.urlduoi,this.mscx).then(data =>{
        this.listGhe = data as GheNgoi[];
        this.listGhe.reverse();
        
        this.listGhe.forEach((data,index) =>{
        
          if(index%2===0)
          {
            this.listGheTrai.push(data);
          }
          else
          {
            this.listGhePhai.push(data)
          }
        })
        console.log(this.listGhePhai);
      }).catch(error=>{
        if(error!=null)
        console.log(error);
      })
    }
    getListGheTren(){
      this.rest.getOne(this.urltren,this.mscx).then(data =>{
        this.listGheTren = data as GheNgoi[];
        this.listGheTren.reverse();
        
        this.listGheTren.forEach((data,index) =>{
        
          if(index%2===0)
          {
            this.listGheTrenTrai.push(data);
          }
          else
          {
            this.listGheTrenPhai.push(data)
          }
        })
      }).catch(error=>{
        if(error!=null)
        console.log(error);
      })
    }
    FormVe(){
  
    }
  
  
  getvalue(tenGhe:string,index:any,type:number){
    console.log(index);
    if(type==1){
      this.listGheTrai.forEach((item, i) => {
        if (item.tenGhe == index) {
          this.listGheTrai[i].class = 'btn-warning';
        }
        if(item.tenGhe != index){
          this.listGheTrai[i].class = '';
        }
      })
      this.listGhePhai.forEach((item, i) => {
        this.listGhePhai[i].class = '';
        this.listGheTrenTrai[i].class = '';
        this.listGheTrenPhai[i].class = '';
        
      })
  
    }else if(type==0){
    this.listGhePhai.forEach((item, i) => {
      if (item.tenGhe == index) {
        this.listGhePhai[i].class = 'btn-warning';
      }
      if(item.tenGhe != index){
        this.listGhePhai[i].class = ''
      }
    })
    this.listGheTrai.forEach((item, i) => {
      this.listGheTrai[i].class = '';
        this.listGheTrenTrai[i].class = '';
        this.listGheTrenPhai[i].class = '';
    })
    }
    else if(type==2){
      this.listGheTrenTrai.forEach((item, i) => {
        if (item.tenGhe == index) {
          this.listGheTrenTrai[i].class = 'btn-warning';
        }
        if(item.tenGhe != index){
          this.listGheTrenTrai[i].class = ''
        }
      })
      this.listGheTrai.forEach((item, i) => {
        this.listGheTrai[i].class = '';
        this.listGhePhai[i].class = '';
        this.listGheTrenPhai[i].class = '';
      })
      }
      else if(type==3){
        this.listGheTrenPhai.forEach((item, i) => {
          if (item.tenGhe == index) {
            this.listGheTrenPhai[i].class = 'btn-warning';
          }
          if(item.tenGhe != index){
            this.listGheTrenPhai[i].class = ''
          }
        })
        this.listGheTrai.forEach((item, i) => {
          this.listGheTrai[i].class = '';
          this.listGhePhai[i].class = '';
          this.listGheTrenTrai[i].class = '';
        })
        }
  
    this.formVe=true;
    this.soGhe=tenGhe;
  }}

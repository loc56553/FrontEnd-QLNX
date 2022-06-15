import { Xe } from './../../../models/Xe';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { collapseTextChangeRangesAcrossMultipleVersions } from 'typescript/lib/tsserverlibrary';

@Component({
  selector: 'app-Xe',
  templateUrl: './Xe.component.html',
  styleUrls: ['./Xe.component.scss']
})
export class XeComponent implements OnInit {
  private url ='http://localhost:13730/api/Xe';
  Xes!: Xe[];
  constructor(private rest : ServerHttpService ,private data : DataService , private route : Router ) { }

  ngOnInit() {
    this.getListXe();
  }
  getListXe(){
    this.rest.get(this.url).then(data=>{
      this.Xes = data as Xe[];
      console.log(this.Xes);
    }).catch(error=>{
      if(error!==null){
        console.log(error);
      }
    })
  }
  FormAddXe()
  {
    this.route.navigate(['Add-Xe']);
  }
  getOneXe(bSXE:string)
  {
    this.route.navigate(['Add-Xe'+'/'+bSXE]);
  }
  Delete(bSXE:string)
  {
    this.rest.delete(this.url,bSXE).then(data=>{
      data as {message:string};
      console.log(data);
      location.reload();
    }).catch(error=>{
      if(error!==null){
        console.log(error);
      }
    })
  }
}

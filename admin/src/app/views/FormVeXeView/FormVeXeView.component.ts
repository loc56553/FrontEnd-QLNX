import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/Services/data.service';
import { ServerHttpService } from 'src/app/Services/server-http.service';

@Component({
  selector: 'app-FormVeXeView',
  templateUrl: './FormVeXeView.component.html',
  styleUrls: ['./FormVeXeView.component.scss']
})
export class FormVeXeViewComponent implements OnInit {

  SDT:string;
  private url='http://localhost:13730/api/VeXe'
  constructor(private rest : ServerHttpService ,private data : DataService , private route : Router) { }

  ngOnInit() {
  }
  getListVeXe(){
    this.rest.getListVeXE(this.url,this.SDT).then(data=>{})
  }
}

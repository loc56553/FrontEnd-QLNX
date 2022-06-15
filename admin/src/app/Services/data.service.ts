import { ServerHttpService } from './server-http.service';
import { Injectable } from '@angular/core';
import { Login } from 'src/models/Login';
import { NavigationStart, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class DataService {
message='';
messageType='danger';
login!:Login;
constructor(private router : Router , private rest : ServerHttpService) { 
  this.router.events.subscribe(event => {
    if(event instanceof NavigationStart){
      this.message='';
    }
  })
}
error(message:string)
{
  this.messageType='danger';
  this.message=message;
}
success(message:string)
{
  this.messageType='success';
  this.message=message;
}
warning(message:string)
{
  this.messageType='warning';
  this.message=message;
}
}

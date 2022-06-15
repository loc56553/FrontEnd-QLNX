import { Login } from './../../models/Login';
import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable , throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})

export class ServerHttpService {

constructor(private http: HttpClient) {}
/*========================================
  CRUD Methods for consuming RESTful API
=========================================*/
// Http Options
public get(link:string){
  return this.http.get(link).toPromise();
}
public getOne(link:string,id:string){
  return this.http.get(link+'/'+id).toPromise();
}
public post(link:string,body:any){
  return this.http.post(link,body).toPromise();
}
public put(link:string,id:string,body:any){
  return this.http.put(link+'/'+id,body).toPromise();
}
public delete(link:string,id:string){
  return this.http.delete(link+'/'+id).toPromise();
}
public getListChuyenXe(link:string,mstD:string,ngaydi:string,tenLx:string){
  return this.http.get(link+'/SearchChuyenXe1'+'/'+mstD+'/'+ngaydi+'/'+tenLx).toPromise();
}
public getGheXe(link: string,msCX: string,tenGhe: string){
  return this.http.get(link+'/OneGhe'+'/'+msCX+'/'+tenGhe).toPromise();
}
public putGhe(link: string,body:any){
  return this.http.put(link,body).toPromise();
}
public getVeXe(link: string,msCX:string,tenGhe:string){
  return this.http.get(link+'/'+msCX+'/'+tenGhe).toPromise();
}
public getListVeXE(link: string,SDT:string){
  return this.http.get(link+'/'+SDT).toPromise();
}
}
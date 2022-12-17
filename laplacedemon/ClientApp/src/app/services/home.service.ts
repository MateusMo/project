import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  baseUrl = `https://localhost:7148/`
  constructor(private http:HttpClient) { }
  
  getPosts(){
    return this.http.get(this.baseUrl + `v1/post/1`);
  }
}

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OrbsService {

  readonly baseURI = "https://localhost:7205";

  constructor( private http: HttpClient) { }

  getOrbs(){
    var tokenHeader = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get(this.baseURI + '/Orbs',
      { headers: tokenHeader });
  }

}

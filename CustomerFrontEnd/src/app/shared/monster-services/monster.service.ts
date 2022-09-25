import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MonsterService {
  readonly baseURI = "https://localhost:7205";

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  getMonsters(){
    var tokenHeader = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get(this.baseURI + '/UserProfile/GetCreatures',
      { headers: tokenHeader });
  }

}

import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Router } from '@angular/router';
import { Observable, observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly baseURI = "https://localhost:7205";
  
  constructor(private fb: FormBuilder, private http: HttpClient, private router:Router) {   }

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', [Validators.email, Validators.required]],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required],
    }, { validator: this.comparePasswords }
    )
  }); //is accessible by everything


  makeTokenHeader():HttpHeaders{
    return new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token'),'Content-Type': 'application/json'
    });
  }
  
  comparePasswords(fb: FormGroup) {
    let confirmPasswordCtrl = fb.get('ConfirmPassword');
    //password mismatch
    //is null when no errors are up or has one if some is
    if (confirmPasswordCtrl?.errors == null
      || 'passMismatch' in confirmPasswordCtrl?.errors) {
      if (fb.get('Password')?.value != fb.get('ConfirmPassword')?.value) {
        confirmPasswordCtrl?.setErrors({ passMismatch: true });
      }
      else {
        confirmPasswordCtrl?.setErrors(null);
      }
    }

  }

  register() {
    let body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      //FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    };
    //return observable
    return this.http.post(this.baseURI + '/AppUser/Register', body);
  }

  login(formData: any) {
    return this.http.post(this.baseURI + '/AppUser/Login', formData);
  }

  getUserProfiles() {
    let tokenHeader = this.makeTokenHeader();
    return this.http.get(this.baseURI + '/UserProfile/GetUsers',
      { headers: tokenHeader });
  }

  roleMatch(allowedRoles: Array<string>): boolean {
    var isMatch=false;
    var payLoad = JSON.parse(window.atob(localStorage.getItem('token')?.split('.')[1]!));
    var usedRole = payLoad.role;  //comes from the claim role 
    console.log(usedRole);
    allowedRoles.forEach(element => {
      if (usedRole == element) {
        isMatch=true;
        return false;
      }
    });
    return isMatch;
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }

  editUser(form:any){
    let tokenHeader = this.makeTokenHeader();
    return this.http.put(this.baseURI + '/UserProfile/EditUser',form,
     { headers: tokenHeader});
  }


  removeUser(id:string){
    let tokenHeader =  this.makeTokenHeader();
    id="\""+id+"\"";
    return this.http.delete(this.baseURI + '/UserProfile/RemoveUser',
      { headers: tokenHeader,body:id});
  }

}




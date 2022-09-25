import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../shared/user-services/user.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router:Router,private service: UserService){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if (localStorage.getItem('token') != null) {
      let roles = route.data['permittedRoles'] as Array<string>;
      if(roles){
        if(this.service.roleMatch(roles)){
          //has the roles required
          return true;
        }
        else{
          this.router.navigate(['/forbidden']);
          return false;
        }
      }
      
      return true;
    }
    this.router.navigate(['/user/login']);
    return false;//not accessible
  }

}

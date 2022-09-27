import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../shared/user-services/user.service';

@Component({
  selector: 'app-frontpage',
  templateUrl: './frontpage.component.html',
  styles: [
  ]
})
export class FrontpageComponent implements OnInit {

  userDetails:any = null;
  userRole:string="";

  constructor(private router: Router, private service: UserService,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.userRole = JSON.parse(window.atob(localStorage.getItem('token')?.split('.')[1]!)).role;
    this.router.navigate(['page/home']);
    // this.service.getUserProfile().subscribe(
    //   (res: any) => {
    //     this.userDetails=res;
    //   },
    //   (err: any) => {
    //     console.log(err);
    //     this.toastr.error("Error occured",'Authentication failed!');
    //     this.onLogout();
    //   }
    // );
  }

  onLogout() {
    this.service.logout();
  }

  goHome(){
    this.router.navigate(['page/home']);
  }

  goToArmy(){
    this.router.navigate(['/page/army']);
  }

  goToUsers(){
    this.router.navigate(['/page/users']);
  }

  goToStore(){
    this.router.navigate(['/page/store']);
  }

}

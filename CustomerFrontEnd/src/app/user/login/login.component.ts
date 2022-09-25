import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/user-services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {
formModel={
  UserName:'',
  Password:''
}
  constructor(private service: UserService,private router:Router
    ,private toastr:ToastrService) { }

  ngOnInit(): void {
    //check if is loged so from home we cant go to login
   if(localStorage.getItem('token')!=null){
    this.router.navigateByUrl('/page');
   }

  }

  onSubmit(form:NgForm){
    this.service.login(form.value).subscribe(
      (res:any)=>{
        //save in browser local storage
        localStorage.setItem('token',res.token);
        this.router.navigateByUrl('/page');
      },
      (err:any)=>{
        if(err.status == 400){
          this.toastr.error(err.message,'Authentication failed!');
        }
        else {
          console.log(err);
          this.toastr.error("Error occured",'Authentication failed!');
        }
      }
    );
  }
}

import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserInfoModel } from 'src/app/shared/interfaces';
import { UserService } from 'src/app/shared/user-services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent implements OnInit {

  users: UserInfoModel[] = [];
  userFormModel = {
    UserName: '',
    Email: '',
    ID: ''
  }

  userIdMap = new Map();

  constructor(private toastr: ToastrService, private service: UserService) { }

  ngOnInit(): void {
    this.service.getUserProfiles().subscribe(
      (res: any) => {
        this.users = res;
        //console.log("Result:" + this.monsters[0]);
      },
      (err: any) => {
        console.log(err);
        this.toastr.error("Error occured", 'Please, sign in again!');
        this.service.logout();
      }
    );
  }

  onEdit(id: string) {
    this.userIdMap.set(id, true);
  }

  onSubmit(form: NgForm,id:string) {
    form.value.ID = id;
    console.log(form.value);
    if (confirm("Are you sure you want to change user with id " + form.value.ID + " ?")) {
      this.service.editUser(form.value).subscribe(
        (res: any) => { 
          this.toastr.success("User changed!", "User was editted succesfully");
          this.onEditModeExit(form.value.id);
        },
        (err: any) => {
          console.log(err);
          if(err.error.errors.Email)
            this.toastr.error("Error occured changing user", err.error.errors.Email[0]);
          else{
            this.toastr.error("Error occured changing user", err.error.title);
          }
        }
      );
     
    }
  }

  onEditModeExit(id: string) {
    this.userIdMap.delete(id);
  }

  onDelete(id: string) {
    if (confirm("Are you sure you want to delete user with id " + id + " ?")) {
      this.service.removeUser(id).subscribe(
        (res: any) => {
          this.toastr.success("User deleted!", "User was removed");
          var toRemoveInd = this.users.findIndex(x => x.id == id);
          this.users.splice(toRemoveInd, 1);
        },
        (err: any) => {
          console.log(err);
          this.toastr.error("Error occured deleting user", err.message);
        }
      );
    }
  }

  isInEditMode(id: string): boolean {
    return this.userIdMap.has(id);
  }

}

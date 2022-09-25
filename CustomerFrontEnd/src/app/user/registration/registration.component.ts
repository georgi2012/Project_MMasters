import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user-services/user.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: [
  ]
})
export class RegistrationComponent implements OnInit {
  public service: UserService;
  constructor(public service2: UserService,
    private toastr:ToastrService) { this.service = service2; }

  ngOnInit(): void {
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          this.toastr.success('New user created!','Registration successful!');
        }
        else {
          res.errors.forEach((element:any) => {
            switch (element.code) {
              case 'DublicateUserName':
                this.toastr.error('Username is already taken!','Registration failed!');
                break;
                default:
                  this.toastr.error(element.description,'Registration failed!');
                break;
            }
          });

        }
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

}

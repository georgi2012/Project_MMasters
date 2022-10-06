import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Orbs } from 'src/app/shared/interfaces';
import { OrbsService } from 'src/app/shared/orbs-service/orbs.service';
import { UserService } from 'src/app/shared/user-services/user.service';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styles: [
  ]
})
export class StoreComponent implements OnInit {

  orbsArr:Orbs[]=[];

  constructor(private toastr: ToastrService, private service: UserService,private orbsService:OrbsService) { }

  ngOnInit(): void {
    this.orbsService.getOrbs().subscribe(
      (res: any) => {
        this.orbsArr = res;
      },
      (err: any) => {
        console.log(err);
        this.toastr.error("Error occured", 'Please, sign in again!');
        this.service.logout();
      }
    );
  }

  getOrbImg(name:string){
    switch (name) {
      case "Basic Orb":
        return "cosmic-orb.png";
      case "Rare Orb":
        return "red-orb.png";
      case "Lucky Orb":
        return "legendary-orb.png";
      default: ;
    }
  }

}

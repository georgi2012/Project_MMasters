import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Orbs } from 'src/app/shared/interfaces';
import { OrbsService } from 'src/app/shared/orbs-service/orbs.service';
import { UserService } from 'src/app/shared/user-services/user.service';
import { MatDialog } from  '@angular/material/dialog';//popup
import { DescriptionPopupComponent } from './orb/description-popup/description-popup.component';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styles: [
  ]
})
export class StoreComponent implements OnInit {

  orbsArr:Orbs[]=[];
  descriptionPopShow:boolean = false;
  

  constructor(private toastr: ToastrService, private service: UserService,private orbsService:OrbsService,
    private  dialogRef : MatDialog) { }

  ngOnInit(): void {
    this.orbsService.getOrbs().subscribe(
      (res: any) => {
        this.orbsArr = res;
        this.editResDescr();
      },
      (err: any) => {
        console.log(err);
        this.toastr.error("Error occured", 'Please, sign in again!');
        this.service.logout();
      }
    );
  }

  editResDescr(){
    this.orbsArr.forEach(orb => {
      orb.description= orb.description.replace("%","%\n");
    });
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

  descriptionPopOn(){
    this.descriptionPopShow = !this.descriptionPopShow;
    if(!this.descriptionPopShow){
      //this.dialogRef.open(DescriptionPopupComponent);
    }
  }

}

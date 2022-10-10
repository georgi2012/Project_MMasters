import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { MonsterReceiveModel, Orbs } from 'src/app/shared/interfaces';
import { OrbsService } from 'src/app/shared/orbs-service/orbs.service';
import { UserService } from 'src/app/shared/user-services/user.service';
import { MatDialog } from  '@angular/material/dialog';//popup
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styles: [
  ]
})
export class StoreComponent implements OnInit {

  orbsArr:Orbs[]=[];
  descriptionPopShow:boolean = false;
  closeResult:string ="";
 
  orbMonster:MonsterReceiveModel = <MonsterReceiveModel>{};

  constructor(private toastr: ToastrService, private service: UserService,private orbsService:OrbsService,
    private modalService:NgbModal) { }

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

  purchaseOrb(name:string,content:any){
    let purchasedOrb:Orbs = {
      name:name,
      price:0,
      description:""
    };
    this.orbsService.buyOrb(purchasedOrb).subscribe(
      (res: any) => {
        this.orbMonster = res;
        this.open(content);
        //pop result
        console.log(this.orbMonster);
      },
      (err: any) => {
        console.log(err);
        if(err.message){
          this.toastr.error("Error occured", err.message);
        }
        else {
          this.toastr.error("Error occured", 'Please, sign in again!');
        }
      }
    );
  }

  open(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }


}

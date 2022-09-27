import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MonsterService } from 'src/app/shared/monster-services/monster.service';
import { MonsterReceiveModel } from 'src/app/shared/interfaces';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user-services/user.service';

@Component({
  selector: 'app-army',
  templateUrl: './army.component.html',
  styles: [
  ]
})
export class ArmyComponent implements OnInit {

  monsters: MonsterReceiveModel[] = [];

  constructor(private monstService: MonsterService, private toastr: ToastrService, private service: UserService) { }

  ngOnInit(): void {
    let temp: MonsterReceiveModel[] = [];
    this.monstService.getMonsters().subscribe(
      (res: any) => {
        temp = res;
        temp = temp.sort(this.sortMonster);
        this.monsters = res;
      },
      (err: any) => {
        console.log(err);
        this.toastr.error("Error occured", 'Please, sign in again!');
        this.service.logout();
      }
    );
  }


  sortMonster(x: MonsterReceiveModel, y: MonsterReceiveModel) {
    let getValueByRarity = function (x:string){
      switch (x) {
        case "Common":
          return 0;
        case "Uncommon":
          return 1;
        case "Rare":
          return 2;
        case "Legendary":
          return 3;
        default: return -1;
      };
    };
    const valX = getValueByRarity(x.rarity);
    const valY = getValueByRarity(y.rarity);
    if (valX > valY) {
      return -1;
    }
    if (valX < valY) {
      return 1;
    }
    return 0;
  }

  getAttackTypePic(type: string) {
    switch (type) {
      case "Melee":
        return "sword.png";
      case "Ranged":
        return "bow.png";
      case "Mage":
        return "wand.png";
      default: ;
    }
  }

  getColor(rarity: string) {
    switch (rarity) {
      case "Common":
        return "rgb(102, 153, 153)";
      case "Uncommon":
        return "rgb(153, 204, 255)";
      case "Rare":
        return "rgb(255, 255, 0)";
      case "Legendary":
        return "rgb(255, 102, 0)";
    }
  }

}

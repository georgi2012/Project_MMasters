using MonsterMasters.Data.Contracts.Monsters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonsterMasters.Data.Monsters.Orcs
{
    public class SelMahr : Creature
    {
        public SelMahr(string ownerId)
          : this()
        {
            userId = ownerId;
        }
        public SelMahr()
        {
            Name = "Sel'Mahr, the Helmsmasher";
            Description = "Sel'Mahr is a legendary warrior that brings fear to every enemy that dares to face him.";
            AttackType = AttackType.Melee;
            Rarity = DropRate.Legendary;
            Health = 50;
            Defense = 10;
            Attack = 35;
            Range = 1;
            Speed = 2;
        }


    }
}

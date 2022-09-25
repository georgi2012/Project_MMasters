using MonsterMasters.Data.Contracts.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Monsters.Orcs
{
    public class OrcSlasher : Creature
    {
        public OrcSlasher(string ownerId)
          : this()
        {
            userId = ownerId;
        }
        public OrcSlasher()
        {
            Name = "Orc Slasher";
            Description = "The Orc Slasher is fierce warrior that will deal solid damage to any threat on his way.";
            AttackType = AttackType.Melee;
            Rarity = DropRate.Common;
            Health = 35;
            Defense = 5;
            Attack = 25;
            Range = 1;
            Speed = 2;
        }

    }
}

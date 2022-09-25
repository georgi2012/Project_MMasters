using MonsterMasters.Data.Contracts.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Monsters.Orcs
{
    public class OrcWolfRider : Creature
    {
        public OrcWolfRider(string ownerId)
          : this()
        {
            userId = ownerId;
        }

        public OrcWolfRider()
        {
            Name = "Orc wolf rider";
            Description = "Orc wolf rider is a fast, strong and bloodthirsty killing machine.";
            AttackType = AttackType.Melee;
            Rarity = DropRate.Rare;
            Health = 35;
            Defense = 4;
            Attack = 35;
            Range = 1;
            Speed = 4;
        }

    }
}

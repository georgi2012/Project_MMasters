using MonsterMasters.Data.Contracts.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Monsters.Orcs
{
    public class OrcSpellcaster : Creature
    {

        public OrcSpellcaster(string ownerId)
          : this()
        {
            userId = ownerId;
        }
        public OrcSpellcaster()
        {
            Name = "Orc Spellcaster";
            Description = "The Orc Spellcaster is a middle-ranged mage that controls the mystic arts or nature's energy.";
            AttackType = AttackType.Mage;
            Rarity = DropRate.Uncommon;
            Health = 25;
            Defense = 2;
            Attack = 20;
            Range = 3;
            Speed = 1;
        }

    }
}

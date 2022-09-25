using MonsterMasters.Data.Contracts.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Monsters.Orcs
{
    public class OrcArcher : Creature
    {
        public OrcArcher(string ownerId) 
            :this()
        {
           userId = ownerId;
        }

        public OrcArcher()
        {
            Name = "Orc Archer";
            Description = "The Orc archer is one of the greater threats in any encounter because it has a long range.";
            AttackType = AttackType.Ranged;
            Rarity = DropRate.Common;
            Health = 25;
            Defense = 2;
            Attack = 15;
            Range = 5;
            Speed = 1;
        }

        public override string ToString()
        {
            return $"{Name}: {Description}\n" +
                $"Drop rate: {Rarity.ToString()}\n" +
                $"AttackType: {AttackType.ToString()}\n" +
                $"Health: {Health}\n" +
                $"Defense: {Defense}\n" +
                $"Attack: {Attack}\n" +
                $"Range: {Range}\n" +
                $"Speed: {Speed}\n";
        }
    }
}

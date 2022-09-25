using RegisterAndLoginApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Contracts.Monsters
{
    public class Creature: ICreature
    {

        //database mapping
        public AppUser appUser { get; set; }
        public string userId { get; set; } ="null";
        //
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public AttackType AttackType { get; protected set; }
        public DropRate Rarity { get; protected set; }
        public int Health { get; protected set; }
        public int Defense { get; protected set; }
        public int Attack { get; protected set; }
        public int Range { get; protected set; }
        public int Speed { get; protected set; }

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

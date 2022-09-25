using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Contracts.Monsters
{
    public interface ICreature
    {
        string Name { get; }
        string Description { get; }
        AttackType AttackType { get; }
        DropRate Rarity { get; }
        int Health { get; }
        int Defense { get; }
        int Attack { get; }
        int Range { get; }
        int Speed { get; }
    }
}

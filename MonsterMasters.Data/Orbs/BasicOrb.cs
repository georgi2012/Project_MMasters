using MonsterMasters.Data.Contracts.Monsters;
using MonsterMasters.Data.Contracts.Orbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Orbs
{
    public class BasicOrb : Orb
    {

        public BasicOrb()
        {
            Price = 100;
            Name = "Basic Orb";
            Rates = new List<RateValue> { //(Enum.GetNames(typeof(DropRate)).Length);
               new RateValue(60),
               new RateValue(35),
               new RateValue(5),
               new RateValue(0)
            };

            MakeDescription($"Fair drops for just {Price}, aren't they?");
        }

    }
}

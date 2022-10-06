using MonsterMasters.Data.Contracts.Monsters;
using MonsterMasters.Data.Contracts.Orbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Orbs
{
    public class LuckyOrb : Orb
    {
        public LuckyOrb()
        {
            Price = 500;
            Name = "Lucky Orb";
            Rates = new List<RateValue> { //(Enum.GetNames(typeof(DropRate)).Length);
               new RateValue(40),
               new RateValue(30),
               new RateValue(20),
               new RateValue(10)
            };
            MakeDescription($"Do you feel lucky today? Just {Price} for a legendary drop!");
        }
    }
}

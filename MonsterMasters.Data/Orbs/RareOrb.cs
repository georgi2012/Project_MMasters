using MonsterMasters.Data.Contracts.Monsters;
using MonsterMasters.Data.Contracts.Orbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Orbs
{
    public class RareOrb : Orb
    {
        public RareOrb()
        {
            Price = 600;
            Name = "Rare Orb";
            Rates = new List<RateValue> { //(Enum.GetNames(typeof(DropRate)).Length);
               new RateValue(20),
               new RateValue(20),
               new RateValue(50),
               new RateValue(0)
            };
            //Rates[(int)DropRate.Common] = new RateValue(20);
            //Rates[(int)DropRate.Uncommon] = new RateValue(20);
            //Rates[(int)DropRate.Rare] = new RateValue(50);
            //Rates[(int)DropRate.Legendary] = new RateValue(0);

            MakeDescription($"High Rare chances for {Price}.");
        }

    }
}

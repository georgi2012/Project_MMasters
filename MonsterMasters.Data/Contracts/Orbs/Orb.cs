using MonsterMasters.Data.Contracts.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Contracts.Orbs
{
    public class Orb : IOrb
    {
        //db mapping
        public string Name { get; set; }
        public int Price { get; set; }
        public List<RateValue> Rates { get; set; }
        public string Description { get; set; }

        public void MakeDescription(string addition)
        {
            double total = 0;
            foreach (var val in Rates)
            {
                total += val == null ? 0 : val.Rate;
            }

            bool hasCommon = Rates[(int)DropRate.Common] != null;
            bool hasUnommon = Rates[(int)DropRate.Uncommon] != null;
            bool hasRare = Rates[(int)DropRate.Rare] != null;
            bool hasLegendary = Rates[(int)DropRate.Legendary] != null;

            Description = $"{Name} rates :\n" +
                (hasCommon ? $"- Common: {(Rates[(int)DropRate.Common].Rate / total).ToString("F2")}%\n" : "") +
                (hasUnommon ? $"- Uncommon: {(Rates[(int)DropRate.Uncommon].Rate / total).ToString("F2")}%\n" : "") +
                (hasRare ? $"- Rare: {(Rates[(int)DropRate.Rare].Rate / total).ToString("F2")}%\n" : "") +
                (hasLegendary ? $"- Legendary: {(Rates[(int)DropRate.Legendary].Rate / total).ToString("F2")}%\n" : "") +
                addition;
        }
    }
}

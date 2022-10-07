using MonsterMasters.Data.Contracts;
using MonsterMasters.Data.Contracts.Monsters;
using MonsterMasters.Data.Contracts.Orbs;
using MonsterMasters.Data.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Core.Orbs
{
    public class OrbOpener : IOrbOpener
    {

        private readonly IMonsterFactory _monsterFactory;

        public OrbOpener(IMonsterFactory monsterFactory)
        {
            _monsterFactory = monsterFactory;
        }

        public async Task<Creature> GetCreatureFromOrb(Orb orb)
        {
            return await _monsterFactory.GetCreatureByRarity(await GetRarityFromDrop(orb));
        }

        protected async Task<DropRate> GetRarityFromDrop(Orb orb)
        {
            int maxNum = 0;
            foreach (var num in orb.Rates)
            {
                maxNum += num.Rate;
            }
            int draw = (new Random()).Next(maxNum);
            int val = 0;
            foreach (var num in orb.Rates)
            {
                if (draw <= num.Rate)
                {
                    return (DropRate)val;
                }
                val++;
                draw -= num.Rate;
            }
            return (DropRate)val;
        }
    }
}

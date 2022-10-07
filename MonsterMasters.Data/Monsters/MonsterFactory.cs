using MonsterMasters.Data.Contracts;
using MonsterMasters.Data.Contracts.Monsters;
using MonsterMasters.Data.Monsters.Orcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Monsters
{
    public class MonsterFactory : IMonsterFactory
    {
        public const int CommonCount = 2;
        public const int UncommonCount = 1;
        public const int RareCount = 1;
        public const int LegendaryCount = 1;
        public readonly Random rng;

        public MonsterFactory()
        {
            rng = new Random();
        }

        public async Task<Creature> GetCreatureByRarity(DropRate rate)
        {
            int value = rng.Next();
            switch (rate)
            {
                case DropRate.Rare:
                    return await GetRare(value);
                case DropRate.Legendary:
                    return await GetLegendary(value);
                case DropRate.Uncommon:
                    return await GetUncommon(value);
                case DropRate.Common:
                    return await GetCommon(value);
                default: throw new Exception("GetCreatureByRarity unsupported rarity");
            }
        }


        public async Task<Creature> GetCommon(int num)
        {
            num = num % CommonCount;
            switch (num)
            {
                case 0:
                    return MakeOrcArcher();
                case 1:
                    return MakeOrcSlasher();
                default: throw new Exception("Invalid common number index in MonsterFactory");
            }

        }

        public async Task<Creature> GetUncommon(int num)
        {
            num = num % UncommonCount;
            switch (num)
            {
                case 0:
                    return MakeOrcSpellcaster();
                default: throw new Exception("Invalid uncommon number index in MonsterFactory");
            }
        }

        public async Task<Creature> GetRare(int num)
        {
            num = num % RareCount;
            switch (num)
            {
                case 0:
                    return MakeOrcWolfRider();
                default: throw new Exception("Invalid rare number index in MonsterFactory");
            }
        }
        public async Task<Creature> GetLegendary(int num)
        {
            num = num % LegendaryCount;
            switch (num)
            {
                case 0:
                    return MakeSelMahr();
                default: throw new Exception("Invalid legendary number index in MonsterFactory");
            }
        }


        public Creature MakeOrcArcher()
        {
            return new OrcArcher();
        }

        public Creature MakeOrcSlasher()
        {
            return new OrcSlasher();
        }
        public Creature MakeOrcSpellcaster()
        {
            return new OrcSpellcaster();

        }
        public Creature MakeOrcWolfRider()
        {
            return new OrcWolfRider();
        }
        public Creature MakeSelMahr()
        {
            return new SelMahr();
        }

    }
}

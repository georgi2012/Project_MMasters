using MonsterMasters.Data.Contracts.Monsters;
using MonsterMasters.Data.Contracts.Orbs;

namespace MonsterMasters.Core.Orbs
{
    public interface IOrbOpener
    {
        Task<Creature> GetCreatureFromOrb(Orb orb);
    }
}
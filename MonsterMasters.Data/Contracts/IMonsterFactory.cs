using MonsterMasters.Data.Contracts.Monsters;

namespace MonsterMasters.Data.Contracts
{
    public interface IMonsterFactory
    {
        Task<Creature> GetCommon(int num);
        Task<Creature> GetCreatureByRarity(DropRate rate);
        Task<Creature> GetLegendary(int num);
        Task<Creature> GetRare(int num);
        Task<Creature> GetUncommon(int num);
        Creature MakeOrcArcher();
        Creature MakeOrcSlasher();
        Creature MakeOrcSpellcaster();
        Creature MakeOrcWolfRider();
        Creature MakeSelMahr();
    }
}
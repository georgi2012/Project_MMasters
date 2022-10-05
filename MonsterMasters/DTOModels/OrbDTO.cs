using MonsterMasters.Data.Contracts.Monsters;

namespace MonsterMasters.Api.DTOModels
{
    public class OrbDTO
    {

        public static OrbDTO MakeDTO( creature)
        {
            return new CreatureDTO
            {
                Name = creature.Name,
                Description = creature.Description,
                AttackType = creature.AttackType.ToString(),
                Rarity = creature.Rarity.ToString(),
                Health = creature.Health,
                Defense = creature.Defense,
                Attack = creature.Attack,
                Range = creature.Range,
                Speed = creature.Speed
            };
        }
        public static List<OrbDTO> MakeFromList(List<Creature> creatures)
        {
            List<CreatureDTO> dtos = new();
            foreach (var item in creatures)
            {
                dtos.Add(MakeDTO(item));
            }
            return dtos;
        }
    }
}

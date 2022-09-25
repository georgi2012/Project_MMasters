using MonsterMasters.Data.Contracts.Monsters;

namespace MonsterMasters.Api.DTOModels
{
    public class CreatureDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AttackType { get; set; }
        public string Rarity { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int Range { get; set; }
        public int Speed { get; set; }

        public static CreatureDTO MakeDTO(Creature creature)
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
        public static List<CreatureDTO> MakeFromList(List<Creature> creatures)
        {
            List<CreatureDTO> dtos= new();
            foreach(var item in creatures)
            {
                dtos.Add(MakeDTO(item));
            }
            return dtos;
        }
    }
}

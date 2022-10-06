using MonsterMasters.Data.Contracts.Monsters;
using MonsterMasters.Data.Contracts.Orbs;

namespace MonsterMasters.Api.DTOModels
{
    public class OrbDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public static OrbDTO MakeDTO(Orb orb)
        {
            return new OrbDTO
            {
                Name = orb.Name,
                Description = orb.Description,
                Price = orb.Price
            };
        }
        public static List<OrbDTO> MakeFromList(List<Orb> orbs)
        {
            List<OrbDTO> dtos = new();
            foreach (var item in orbs)
            {
                dtos.Add(MakeDTO(item));
            }
            return dtos;
        }
    }
}

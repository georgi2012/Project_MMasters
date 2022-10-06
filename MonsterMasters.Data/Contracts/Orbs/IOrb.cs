using MonsterMasters.Data.Contracts.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Contracts.Orbs
{
    public interface IOrb
    {
        string Name { get; set; }
        int Price { get; set; }
        List<RateValue> Rates { get; set; }
        string Description { get; set; }

    }
}

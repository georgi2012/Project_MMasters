using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Contracts.Orbs
{
    internal interface IOrb
    {
        string Name { get; }
        int Price { get; }
        // Dictionary<string, double> Rates { get; }
        double[] Rates { get; }
    }
}

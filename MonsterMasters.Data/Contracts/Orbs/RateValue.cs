using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMasters.Data.Contracts.Orbs
{
    public class RateValue
    {
        //db
        public Orb Orb { get; set; }
        //
        public int Rate { get; set; }
        public RateValue(int val)
        {
            Rate = val;
        }
        public RateValue()
        {

        }
    }
}

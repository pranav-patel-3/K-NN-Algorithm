using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_nearest_demo
{
    public class MobileDistance
    {
        public Mobile Instance { get; set; }
        public double Distance { get; set; }

        public MobileDistance(Mobile instance, double distance)
        {
            Instance = instance;
            Distance = distance;
        }
    }
}

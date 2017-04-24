using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    public class Creature
    {
        protected bool canManageBoat;
        public bool state;

        protected Creature(bool canManageBoat)
        {
            this.canManageBoat = canManageBoat;
        }

        public bool isManager
        {
            get
            {
                return canManageBoat;
            }
        }
    }
}

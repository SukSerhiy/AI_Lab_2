using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    public class Creature
    {
        /// <summary>
        /// Whether it can manage the boat
        /// </summary>
        protected bool canManageBoat;
        /// <summary>
        /// On which bank it is now (false - left, true - right)
        /// </summary>
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

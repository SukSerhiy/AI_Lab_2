using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    /// <summary>
    /// Creature that can manage the boat
    /// </summary>
    public class Manager : Creature
    {
        public Manager(bool state) : base(true) {
            this.state = state;
        }

    }
}

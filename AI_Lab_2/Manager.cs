using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    public class Manager : Creature
    {
        public Manager(bool state) : base(true) {
            this.state = state;
        }

    }
}

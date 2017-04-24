using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    public class Pasenger : Creature
    {
        public Pasenger(bool state) : base(false) {
            this.state = state;
        }
    }
}

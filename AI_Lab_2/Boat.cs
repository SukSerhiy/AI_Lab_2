using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    class Boat
    {
        private const int PLACES_NUMBER = 2;
        private static Boat boat;
        List<Creature> passengers = new List<Creature>();
        private bool state;

        public bool State
        {
            get
            {
                return state;
            }
        }

        public void ClearPlaces()
        {
            passengers.Clear();
        }
        public bool TryAddPassenger(Creature creature)
        {
            int count = passengers.Count;
            if (passengers.Count < PLACES_NUMBER)
            {
                passengers.Add(creature);
                return true;
            }
            return false;
        }
        
        public bool isManagable()
        {
            bool result = false;
            foreach(Creature pass in passengers)
            {
                if (pass.isManager)
                {
                    result = true;
                }
            }
            if (!result)
            {
                passengers.Clear();
            }
            return result;
        }

        public void ChangeState()
        {
            state = !state;
            passengers.Clear();
        }

        public void ResetState()
        {
            state = false;
            passengers.Clear();
        }

        private Boat()
        {
            state = false;
        }

        public static Boat GetBoat
        {
            get
            {
                if (boat == null)
                {
                    boat = new Boat();
                }
                return boat;
            }
            
        }
        
    }
}

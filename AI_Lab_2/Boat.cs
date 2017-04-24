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
        /// <summary>
        /// List of passangers in the boat
        /// </summary>
        List<Creature> passengers = new List<Creature>();
        /// <summary>
        /// On which bank is the boat now (false - left, true - right)
        /// </summary>
        private bool state;

        public bool State
        {
            get
            {
                return state;
            }
        }

        /// <summary>
        /// Clears all places in boat
        /// </summary>
        public void ClearPlaces()
        {
            passengers.Clear();
        }

        /// <summary>
        /// Tries to add passanger to the boat
        /// </summary>
        /// <param name="creature">Passenger we have to add</param>
        /// <returns>True, if passenger was added. False if not</returns>
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

        /// <summary>
        /// Whether the boat is managable
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Move the boat to another coast
        /// </summary>
        public void ChangeState()
        {
            state = !state;
            passengers.Clear();
        }

        /// <summary>
        /// Set boat to the initial state (left coast, no passengers)
        /// </summary>
        public void ResetState()
        {
            state = false;
            passengers.Clear();
        }

        private Boat()
        {
            state = false;
        }

        /// <summary>
        /// Get singleton object of boat
        /// </summary>
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

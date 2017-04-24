using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    /// <summary>
    /// State of a vertex (in what banks are the creatures. true - right bank, false - left)
    /// </summary>
    public class State
    {
        private Manager man_1;
        private Manager man_2;
        private Manager man_3;
        private Manager big_monkey;
        private Pasenger small_monkey_1;
        private Pasenger small_monkey_2;
        private Boat boat;
        
        public State() {
            man_1 = new Manager(false);
            man_2 = new Manager(false);
            man_3 = new Manager(false);
            big_monkey = new Manager(false);
            small_monkey_1 = new Pasenger(false);
            small_monkey_2 = new Pasenger(false);
            boat = Boat.GetBoat;
        }

        public State(bool man_1, bool man_2, bool man_3, bool big_monkey, bool small_monkey_1, bool small_monkey_2)
        {
            this.man_1 = new Manager(man_1);
            this.man_2 = new Manager(man_2);
            this.man_3 = new Manager(man_3);
            this.big_monkey = new Manager(big_monkey);
            this.small_monkey_1 = new Pasenger(small_monkey_1);
            this.small_monkey_2 = new Pasenger(small_monkey_2);
            boat = Boat.GetBoat;
        }

        public State(bool[] array)
        {
            man_1 = new Manager(array[0]);
            man_2 = new Manager(array[1]);
            man_3 = new Manager(array[2]);
            big_monkey = new Manager(array[3]);
            small_monkey_1 = new Pasenger(array[4]);
            small_monkey_2 = new Pasenger(array[5]);

        }

        public State(State state)
        {
            man_1 = state.man_1;
            man_2 = state.man_2;
            man_3 = state.man_3;
            big_monkey = state.big_monkey;
            small_monkey_1 = state.small_monkey_1;
            small_monkey_2 = state.small_monkey_2;
            boat = Boat.GetBoat;
        }

        /// <summary>
        /// Get creature by it's index
        /// </summary>
        /// <param name="index">Index of the creature</param>
        /// <returns></returns>
        /// <exception>IndexOutOfRangeException</exception>
        public Creature getCreatureByIndex(int index)
        {
            switch(index)
            {
                case 0:
                    return man_1;
                case 1:
                    return man_2;
                case 2:
                    return man_3;
                case 3:
                    return big_monkey;
                case 4:
                    return small_monkey_1;
                case 5:
                    return small_monkey_2;
                default:
                    throw new IndexOutOfRangeException();
            }
            
        }

        /// <summary>
        /// Checks whether the boat are manageable in current state
        /// </summary>
        /// <returns>True if manageable. False if not</returns>
        public bool BoatIsManageable()
        {
            return (man_1.state || man_2.state || man_3.state || big_monkey.state) ? true : false;
        }

        /// <summary>
        /// Checks whether people are alive in current state
        /// </summary>
        /// <returns>True if alive. False if not</returns>
        public bool PeopleAreAlive()
        {
            int monkeyCounterOnLeft = 0;
            int peopleCounterOnLeft = 0;
            int monkeyCounterOnRight = 0;
            int peopleCounterOnRight = 0;

            if (man_1.state)
            {
                peopleCounterOnRight++;
            }

            if (man_2.state)
            {
                peopleCounterOnRight++;
            }

            if (man_3.state)
            {
                peopleCounterOnRight++;
            }

            if (big_monkey.state)
            {
                monkeyCounterOnRight++;
            }

            if (small_monkey_1.state)
            {
                monkeyCounterOnRight++;
            }

            if (small_monkey_2.state)
            {
                monkeyCounterOnRight++;
            }

            if (!man_1.state)
            {
                peopleCounterOnLeft++;
            }

            if (!man_2.state)
            {
                peopleCounterOnLeft++;
            }

            if (!man_3.state)
            {
                peopleCounterOnLeft++;
            }

            if (!big_monkey.state)
            {
                monkeyCounterOnLeft++;
            }

            if (!small_monkey_1.state)
            {
                monkeyCounterOnLeft++;
            }

            if (!small_monkey_2.state)
            {
                monkeyCounterOnLeft++;
            }

            if (((monkeyCounterOnLeft > peopleCounterOnLeft) && peopleCounterOnLeft != 0) || ((monkeyCounterOnRight > peopleCounterOnRight) && peopleCounterOnRight != 0))
                return false;
            
            return true;
        }


        public bool[] toArray()
        {
            bool[] array = new bool[6];

            array[0] = man_1.state;
            array[1] = man_2.state;
            array[2] = man_3.state;
            array[3] = big_monkey.state;
            array[4] = small_monkey_1.state;
            array[5] = small_monkey_2.state;
            return array;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            State state = obj as State;

            if (state == null)
            {
                return false;
            }

            return state.man_1.state == this.man_1.state && state.man_2.state == this.man_2.state && state.man_3.state == this.man_3.state && state.big_monkey.state == this.big_monkey.state && state.small_monkey_1.state == this.small_monkey_1.state && state.small_monkey_2.state == this.small_monkey_2.state;
        }

        public bool Equals(State state)
        {

            if (state == null)
            {
                return false;
            }

            return state.man_1.state == this.man_1.state && state.man_2.state == this.man_2.state && state.man_3.state == this.man_3.state && state.big_monkey.state == this.big_monkey.state && state.small_monkey_1.state == this.small_monkey_1.state && state.small_monkey_2.state == this.small_monkey_2.state;
        }

        public static bool operator ==(State state_1, State state_2)
        {
            return state_1.man_1.state == state_2.man_1.state && state_1.man_2.state == state_2.man_2.state && state_1.man_3.state == state_2.man_3.state && state_1.big_monkey.state == state_2.big_monkey.state && state_1.small_monkey_1.state == state_2.small_monkey_1.state && state_1.small_monkey_2.state == state_2.small_monkey_2.state;
        }

        public static bool operator !=(State state_1, State state_2)
        {
            return !(state_1.man_1.state == state_2.man_1.state && state_1.man_2.state == state_2.man_2.state && state_1.man_3.state == state_2.man_3.state && state_1.big_monkey.state == state_2.big_monkey.state && state_1.small_monkey_1.state == state_2.small_monkey_1.state && state_1.small_monkey_2.state == state_2.small_monkey_2.state);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    abstract class Graph
    {
        protected StreamWriter sw = new StreamWriter(@"results.txt");
        protected Vertex root;
        protected Boat boat;
        protected bool resultFound;

        public Graph()
        {
            root = new Vertex(new State(ParseStrInBool("000000")));
            boat = Boat.GetBoat;
            resultFound = false;
        }

        public abstract void Search();

        protected void PrintState(IEnumerable<bool> arr)
        {
            foreach (bool b in arr)
            {
                Console.Write(b ? "1" : "0");
            }
            Console.WriteLine();
        }

        protected void PrintStateToFile(IEnumerable<bool> arr)
        {
            foreach (bool b in arr)
            {
                sw.Write(b ? "1" : "0");
            }
            sw.WriteLine();
        }

        protected bool TryToAddChild(Vertex parent, Vertex child)
        {
            boat.ClearPlaces();
            State childState = child.state;
            bool[] childArr = child.state.toArray();
            bool sizeIsNormal = true;
            for (int i = 0; i < childArr.Length; i++)
            {
                if (childArr[i] != parent.state.toArray()[i])
                {
                    sizeIsNormal = boat.TryAddPassenger(childState.getCreatureByIndex(i));
                    if (!sizeIsNormal)
                        return false;
                }
            }
            if (!boat.isManagable())
                return false;

            if (childState.PeopleAreAlive())
            {
                return true;
            }
            return false;

        }

        protected bool isResult(bool[] arr)
        {
            if (arr.Where(b => b == false).Count() > 0)
            {
                return false;
            }
            return true;
        }

        protected bool[] ParseStrInBool(string str)
        {
            List<bool> lst = new List<bool>();
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                    lst.Add(false);
                else if (str[i] == '1')
                    lst.Add(true);
            }
            return lst.ToArray();
        }
        
    }
}

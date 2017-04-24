using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    class Program
    {
        //Main method
        static void Main(string[] args)
        {
            Graph g;

            //g = new DFSGraph();
            g = new BFSGraph();
            //g = new DFSWithIterativeDeepingGraph(14);

            g.Search();
            
            Console.ReadLine();
        }
    }
}

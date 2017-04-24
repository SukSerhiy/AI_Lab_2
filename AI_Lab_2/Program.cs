using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    class Program
    {
        /*
         * Условие:
         * Три человека, большая обезьяна и две маленьких обезьянки хотят переправиться через реку.
         * 1. Только люди и большая обезьяна управлять лодкой.
         * 2. В любое время количество людей на берегу реки должно быть больше или равно количеству обезьян на том же берегу. (Иначе обезьяны убьют людей!)
         * 3. Лодка рассчитана на двух пассажиров. (Обезьян или людей.)
         * DFSGraph - поиск в глубину
         * BFSGraph - поиск в ширину
         * DFSWithIterativeDeepingGraph - поиск в ширину с итеративным углублением
         */
        static void Main(string[] args)
        {
            Graph g;

            g = new DFSGraph();
            //g = new BFSGraph();
            //g = new DFSWithIterativeDeepingGraph(14);

            g.Search();
            
            Console.ReadLine();
        }
    }
}

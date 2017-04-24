using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    class BFSGraph : Graph
    {
        private Vertex result = null;
        public override void Search()
        {
            Console.WriteLine("Поиск в ширину\n");
            Queue<Vertex> elements = new Queue<Vertex>();
            elements.Enqueue(root);
            DateTime before = DateTime.Now;
            Queue<Vertex> adges = BFS(elements);
            while (!resultFound)
            {
                adges = BFS(adges);
            }
            DateTime after = DateTime.Now;
            TimeSpan time = after - before;

            Console.WriteLine("Время = {0} миллисекунд\n", time.Milliseconds);
            List<Vertex> path = new List<Vertex>();
            if (result != null)
            {
                Vertex ancestor = result;
                while (ancestor != null)
                {
                    path.Add(ancestor);
                    ancestor = ancestor.Ancestor;
                }
            }
            int step = 0;
            foreach (Vertex v in path.Reverse<Vertex>())
            {
                PrintState(v.state.toArray());
                Console.WriteLine();
                PrintStateToFile(v.state.toArray());
                step++;
            }
            sw.Close();
            Console.WriteLine(step + " шагов");
        }
        /// <summary>
        /// BFS-search
        /// </summary>
        /// <param name="elements">Last layer of vertexes</param>
        /// <returns>Next layer of vertexes</returns>
        private Queue<Vertex> BFS(Queue<Vertex> elements)
        {
            Queue<Vertex> adges = new Queue<Vertex>();
            while (elements.Count > 0)
            {
                Vertex currEl = elements.Dequeue();
                bool[] stateArr = currEl.state.toArray();
                bool boatState = boat.State;
                if (boatState)
                {
                    for (int i = 0; i < stateArr.Count(); i++)
                    {
                        if (resultFound)
                        {
                            break;
                        }
                        bool[] newArr = new bool[6];
                        Array.Copy(stateArr, newArr, 6);
                        if (newArr[i] == true)
                        {
                            newArr[i] = false;
                            Vertex child = new Vertex(new State(newArr));
                            TryAddChildForBFS(currEl, child, adges);

                            if (isResult(newArr))
                            {
                                //найден результат
                                resultFound = true;
                                break;
                            }


                            for (int j = i + 1; j < stateArr.Count(); j++)
                            {
                                bool[] newArr2 = new bool[6];
                                Array.Copy(newArr, newArr2, 6);
                                if (newArr2[j] == true)
                                {
                                    newArr2[j] = false;

                                    child = new Vertex(new State(newArr2));
                                    TryAddChildForBFS(currEl, child, adges);

                                    if (isResult(newArr2))
                                    {
                                        //найден результат
                                        resultFound = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < stateArr.Count(); i++)
                    {
                        if (resultFound)
                        {
                            break;
                        }
                        bool[] newArr = new bool[6];
                        Array.Copy(stateArr, newArr, 6);
                        if (newArr[i] == false)
                        {
                            newArr[i] = true;

                            Vertex child = new Vertex(new State(newArr));
                            TryAddChildForBFS(currEl, child, adges);

                            if (isResult(newArr))
                            {
                                //найден результат
                                resultFound = true;
                                break;
                            }

                            for (int j = i + 1; j < stateArr.Count(); j++)
                            {
                                bool[] newArr2 = new bool[6];
                                Array.Copy(newArr, newArr2, 6);
                                if (newArr2[j] == false)
                                {
                                    newArr2[j] = true;

                                    child = new Vertex(new State(newArr2));
                                    TryAddChildForBFS(currEl, child, adges);

                                    if (isResult(newArr2))
                                    {
                                        //найден результат
                                        resultFound = true;
                                        break;
                                    }

                                }
                            }
                        }
                    }
                }
            }
            boat.ChangeState();
            return adges;
        }

        /// <summary>
        /// Tries to add child node to current parent node
        /// </summary>
        /// <param name="parent">Parent node</param>
        /// <param name="child">Child node which is trying to add</param>
        /// <param name="adges">Layer of vartexes</param>
        /// <returns>True, if child node wass added. False, if not</returns>
        private bool TryAddChildForBFS(Vertex parent, Vertex child, Queue<Vertex> adges)
        {
            State childSt = child.state;
            if (TryToAddChild(parent, child))
            {
                if (parent.edges.Where(v => v.state == childSt).FirstOrDefault() != null)
                {
                    return false;
                }

                Vertex ancestor = parent;
                while (ancestor != null)
                {
                    if (ancestor.state == child.state)
                    {
                        return false;
                    }
                    ancestor = ancestor.Ancestor;
                }
                parent.AddAdge(child);
                child.setAncestor(parent);
                adges.Enqueue(child);

                if (isResult(child.state.toArray()))
                {
                    result = child;
                }
                return true;
            }
            return false;
        }
    }
}

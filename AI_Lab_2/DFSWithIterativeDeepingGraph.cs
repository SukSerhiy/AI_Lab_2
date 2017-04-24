using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    class DFSWithIterativeDeepingGraph : Graph
    {
        private Stack<Vertex> stack;
        private int maxDepth;

        public DFSWithIterativeDeepingGraph()
        {
            stack = new Stack<Vertex>();
            maxDepth = 10;
        }

        public DFSWithIterativeDeepingGraph(int maxDepth)
        {
            stack = new Stack<Vertex>();
            this.maxDepth = maxDepth;
        }

        public override void Search()
        {
            Console.WriteLine("Поиск в глубину с итеративным углублением\n");
            DateTime before = DateTime.Now;
            int stepOfDepth = maxDepth;
            while (!currentRun())
                maxDepth += stepOfDepth;
            
            DateTime after = DateTime.Now;
            TimeSpan time = after - before;

            Console.WriteLine("Время = {0} миллисекунд", time.Milliseconds);
            Vertex[] path = stack.Reverse().ToArray();
            Console.WriteLine();
            int step = 0;
            foreach (Vertex v in path)
            {
                PrintState(v.state.toArray());
                Console.WriteLine();
                PrintStateToFile(v.state.toArray());
                step++;
            }
            sw.Close();
            Console.WriteLine(step + " шагов");

        }

        private bool currentRun()
        {
            root.Clear();
            stack.Clear();
            Vertex child = DFS(root);
            while (!resultFound && !(stack.Count == 0 && child == null))
            {
                if (child != null)
                    child = DFS(child);
            }
            if (resultFound)
            {
                return true;
            }
            return false;
        }

        private Vertex DFS(Vertex vertex)
        {
            bool[] stateArr = vertex.state.toArray();
            bool boatState = boat.State;
            bool newAdgeAdded = false;
            if (boatState)
            {
                for (int i = 0; i < stateArr.Count(); i++)
                {
                    bool firstSircleStepCompleted = false;
                    if (newAdgeAdded)
                    {
                        break;
                    }
                    if (resultFound)
                    {
                        break;
                    }

                    bool[] newArr = new bool[6];
                    Array.Copy(stateArr, newArr, 6);
                    if (newArr[i] == true)
                    {

                        newArr[i] = false;

                        firstSircleStepCompleted = true;


                        Vertex child = new Vertex(new State(newArr));
                        newAdgeAdded = TryAddChildForDFS(vertex, child);

                        if (isResult(newArr))
                        {
                            resultFound = true;
                            return child;
                        }

                        if (newAdgeAdded)
                        {
                            return child;
                        }

                    }
                    if (newAdgeAdded)
                    {
                        break;
                    }
                    else
                    {
                        if (stack.Count > 0 && (i == stateArr.Count() - 1 || stack.Count >= maxDepth))
                        {
                            boat.ChangeState();
                            return stack.Pop();
                        }
                    }

                    if (firstSircleStepCompleted)
                    {
                        for (int j = i + 1; j < stateArr.Count(); j++)
                        {
                            bool[] newArr2 = new bool[6];
                            Array.Copy(newArr, newArr2, 6);
                            if (newArr2[j] == true)
                            {

                                newArr2[j] = false;

                                Vertex child = new Vertex(new State(newArr2));
                                newAdgeAdded = TryAddChildForDFS(vertex, child);

                                if (isResult(newArr2))
                                {
                                    //найден результат
                                    resultFound = true;
                                    return child;
                                }

                                if (newAdgeAdded)
                                {
                                    return child;
                                }

                            }
                            if (newAdgeAdded)
                            {
                                break;
                            }
                            else
                            {
                                if (stack.Count > 0 && ((i == stateArr.Count() - 1 && j == stateArr.Count() - 1) || stack.Count >= maxDepth))
                                {
                                    boat.ChangeState();
                                    return stack.Pop();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                //Первый круг - левый берег
                for (int i = 0; i < stateArr.Count(); i++)
                {
                    bool firstSircleStepCompleted = false;
                    if (newAdgeAdded)
                    {
                        break;
                    }
                    if (resultFound)
                    {
                        break;
                    }

                    bool[] newArr = new bool[6];
                    Array.Copy(stateArr, newArr, 6);
                    if (newArr[i] == false)
                    {
                        newArr[i] = true;
                        firstSircleStepCompleted = true;

                        Vertex child = new Vertex(new State(newArr));
                        newAdgeAdded = TryAddChildForDFS(vertex, child);

                        if (isResult(newArr))
                        {
                            //найден результат
                            resultFound = true;
                            return child;
                        }

                        if (newAdgeAdded)
                        {
                            return child;
                        }
                    }
                    if (newAdgeAdded)
                    {
                        break;
                    }
                    else
                    {
                        if (stack.Count > 0 && (i == stateArr.Count() - 1 || stack.Count >= maxDepth))
                        {
                            boat.ChangeState();
                            return stack.Pop();
                        }
                    }

                    if (firstSircleStepCompleted)
                    {
                        for (int j = i + 1; j < stateArr.Count(); j++)
                        {
                            bool[] newArr2 = new bool[6];
                            Array.Copy(newArr, newArr2, 6);
                            if (newArr2[j] == false)
                            {

                                newArr2[j] = true;


                                Vertex child = new Vertex(new State(newArr2));
                                newAdgeAdded = TryAddChildForDFS(vertex, child);

                                if (isResult(newArr2))
                                {
                                    //найден результат
                                    resultFound = true;
                                    return child;
                                }

                                if (newAdgeAdded)
                                {
                                    return child;
                                }

                            }
                            if (newAdgeAdded)
                            {
                                break;
                            }
                            else
                            {
                                if (stack.Count > 0 && ((i == stateArr.Count() - 1 && j == stateArr.Count() - 1) || stack.Count >= maxDepth))
                                {
                                    //Console.WriteLine("POPPED : ");
                                    //PrintState(stack.Peek().state.toArray());
                                    boat.ChangeState();
                                    return stack.Pop();
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Tries to add child node to current parent node
        /// </summary>
        /// <param name="parent">Parent node</param>
        /// <param name="child">Child node which is trying to add</param>
        /// <returns>True, if child node wass added. False, if not</returns>
        private bool TryAddChildForDFS(Vertex parent, Vertex child)
        {
            State childState = child.state;
            if (TryToAddChild(parent, child))
            {
                if (parent.edges.Where(v => v.state == childState).FirstOrDefault() != null)
                {
                    return false;
                }
                if (stack.ToArray().Where(v => v.state == childState).FirstOrDefault() != null)
                {
                    return false;
                }
                boat.ChangeState();
                parent.AddAdge(child);
                stack.Push(parent);
                if (isResult(child.state.toArray()))
                    stack.Push(child);
                return true;
            }
            return false;
        }
    }
}

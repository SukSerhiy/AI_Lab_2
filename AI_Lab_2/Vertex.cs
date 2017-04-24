using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab_2
{
    class Vertex
    {
        public State state;
        private Vertex ancestor;
        public List<Vertex> edges;

        public Vertex()
        {
            state = new State();
            edges = new List<Vertex>();
        }

        public Vertex(State state)
        {
            this.state = new State(state);
            edges = new List<Vertex>();
        }
        public void setAncestor(Vertex ancestor)
        {
            this.ancestor = ancestor;
        }
        public Vertex Ancestor
        {
            get
            {
                return ancestor;
            }
        }
        public Vertex AddAdge(Vertex vertex)
        {
            edges.Add(vertex);
            vertex.setAncestor(this);
            return this;
        }

        public void Clear()
        {
            if (ancestor != null)
            {
                ancestor.Clear();
            }
            edges.Clear();
        }

    }
}

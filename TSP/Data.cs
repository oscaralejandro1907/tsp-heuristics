using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    internal class Data
    {
        public List<Node> ListNodes { get; set; }
        public List<Edge> ListEdges { get; set; }
        
        public Data()
        {
            ListNodes = new List<Node>();
            ListEdges = new List<Edge>();
              
            makeGraph();
        }

        public void makeGraph()
        {
            Node a = new Node("a");
            Node b = new Node("b");
            Node c = new Node("c");
            Node d = new Node("d");

            Edge e0 = new("a", "b", 2);
            Edge e1 = new("a", "c", 5);
            Edge e2 = new("a", "d", 7);
            Edge e3 = new("b", "c", 8);
            Edge e4 = new("b", "d", 3);
            Edge e5 = new("c", "d", 1);

            ListEdges.Add(e0);
            ListEdges.Add(e1);
            ListEdges.Add(e2);
            ListEdges.Add(e3);
            ListEdges.Add(e4);
            ListEdges.Add(e5);

            ListNodes.Add(a);
            ListNodes.Add(b);
            ListNodes.Add(c);
            ListNodes.Add(d);

            foreach (Node n in ListNodes)
            {
                foreach (Edge e in ListEdges)
                {
                    if(e.origin ==n.Name || e.destiny == n.Name )
                    {
                        n.ListEdges.Add(e);
                    }
                }
            } 
            
        }
        
    }

}

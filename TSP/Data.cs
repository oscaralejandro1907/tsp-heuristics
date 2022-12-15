using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Edge e1 = new("b", "a", 2);
            Edge e2 = new("a", "c", 5);
            Edge e3 = new("c", "a", 5);
            Edge e4 = new("a", "d", 7);
            Edge e5 = new("d", "a", 7);
            Edge e6 = new("b", "c", 8);
            Edge e7 = new("c", "b", 8);
            Edge e8 = new("b", "d", 3);
            Edge e9 = new("d", "b", 3);
            Edge e10 = new("c", "d", 1);
            Edge e11 = new("d", "c", 1);

            ListEdges.Add(e0);
            ListEdges.Add(e1);
            ListEdges.Add(e2);
            ListEdges.Add(e3);
            ListEdges.Add(e4);
            ListEdges.Add(e5);
            ListEdges.Add(e6);
            ListEdges.Add(e7);               
            ListEdges.Add(e8);
            ListEdges.Add(e9);
            ListEdges.Add(e10);
            ListEdges.Add(e11);

            ListNodes.Add(a);
            ListNodes.Add(b);
            ListNodes.Add(c);
            ListNodes.Add(d);

            foreach (Node n in ListNodes)
            {
                foreach (Edge e in ListEdges)
                {
                    if(e.origin == n.Name)
                    {
                        n.ListEdges.Add(e);
                        n.ListAdjacentNodes.Add(ListNodes.Find(n => n.Name == e.destiny)!);
                    }                   
                }              
                          
            } 
            
        }
        
    }

}

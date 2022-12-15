using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    internal class Node
    {
        public string Name { get; set; }
        public List<Node> ListAdjacentNodes { get; set; }
        public List<Edge> ListEdges { get; set; }
        
        public Node(string name)
        {
            Name = name;
            ListAdjacentNodes = new List<Node>();
            ListEdges = new List<Edge>();   
            
        }

    }
}

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

        public Dictionary<string, int> DictDistances { get; set; }
        
        public Node(string name)
        {
            Name = name;
            DictDistances = new Dictionary<string, int>();
                  
        }

        public Node()
        {
            Name = "";
            DictDistances = new Dictionary<string, int>();
        }        

    }
}

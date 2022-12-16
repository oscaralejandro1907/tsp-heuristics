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
        
        public Data()
        {
            ListNodes = new List<Node>();
              
            makeGraph();
        }

        public void makeGraph()
        {
            Node a = new Node("a");
            Node b = new Node("b");
            Node c = new Node("c");
            Node d = new Node("d");

            ListNodes.Add(a);
            ListNodes.Add(b);
            ListNodes.Add(c);
            ListNodes.Add(d);

            //a.DictDistances["b"] = 2; //Access
            a.DictDistances.Add("b", 2);            
            a.DictDistances.Add("c", 5);
            a.DictDistances.Add("d", 7);
            
            b.DictDistances.Add("a", 2);
            b.DictDistances.Add("c", 8);
            b.DictDistances.Add("d", 3);

            c.DictDistances.Add("a", 5);
            c.DictDistances.Add("b", 8);
            c.DictDistances.Add("d", 8);

            d.DictDistances.Add("a", 7);
            d.DictDistances.Add("b", 3);
            d.DictDistances.Add("c", 1);
                
        }
        
    }

}

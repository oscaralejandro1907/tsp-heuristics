using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    internal class NearestNeighbor
    {
        public Data Instance { get; set; }
        public List<Node> ListNodes { get; set; } 
        public List<Node> ListTour { get; set; }    //List to save the route (solution)
        
        public NearestNeighbor(Data instance)
        {
            this.Instance = instance;
            this.ListTour = new();
            
            this.ListNodes = Instance.ListNodes;

        }

        public List<Node> Solve()
        {            
            List<Node> ListUnvisitedNodes = new(ListNodes);          

            //Start tour with just one city randomly chosen
            var random = new Random(0);
            int selectedNodeIndex = random.Next(ListNodes.Count);
            Node selectedNode = ListNodes[selectedNodeIndex];

            ListTour.Add(selectedNode);           
            
            ListUnvisitedNodes.Remove(selectedNode);
            
            while (ListUnvisitedNodes.Count!=0)
            {
                Node N = ListTour.Last();
                //Find the closest unvisited city from the last visited node
                 Node nextNodeToVisit = NextNodeToVisit(N, ListUnvisitedNodes);

                ListTour.Add(nextNodeToVisit);
                ListUnvisitedNodes.Remove(nextNodeToVisit);
            }

            return ListTour;
        }

        public Node NextNodeToVisit(Node lastVisitedNode, List<Node> listUnvisitedNodes)
        {
            var nextNode = new Node();
            int minD = Int16.MaxValue;
            foreach(Node n in listUnvisitedNodes)
            {
                int distvalue = lastVisitedNode.DistanceTo(n);
                if ( distvalue < minD)
                {
                    minD = distvalue;
                    nextNode = n;
                }              
            }

            return nextNode;

        }


    }
}

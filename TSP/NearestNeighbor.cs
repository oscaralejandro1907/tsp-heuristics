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
            List<Node> listUnvisitedNodes = new(ListNodes);          

            //Start tour with just one city randomly chosen
            var random = new Random(0);
            int selectedNodeIndex = random.Next(ListNodes.Count);
            Node selectedNode = ListNodes[selectedNodeIndex];

            ListTour.Add(selectedNode);           
            
            listUnvisitedNodes.Remove(selectedNode);
            
            while (listUnvisitedNodes.Count!=0)
            {
                Node N = ListTour.Last();
                //Find the closest unvisited city from the last visited node
                 Node nextNodeToVisit = NextNodeToVisit(N, listUnvisitedNodes);

                ListTour.Add(nextNodeToVisit);
                listUnvisitedNodes.Remove(nextNodeToVisit);
            }
            
            //Add the return trip to the route
            ListTour.Add(ListTour[0]);

            int tourLength = CalculateDistanceOfTour(ListTour);
            
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

        public int CalculateDistanceOfTour(List<Node> listRoute)
        {
            int totalDistance = 0;
            for (int i = 0; i < listRoute.Count - 1 ; i++)
            {
                Node org = listRoute[i];
                Node dest = listRoute[i + 1];

                totalDistance += org.DistanceTo(dest);
            }

            return totalDistance;
        }
    }
}

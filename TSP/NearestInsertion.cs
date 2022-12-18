using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    internal class NearestInsertion
    {
        public Data Instance { get; set; }
        public List<Node> ListNodes { get; set; } 
        public List<Node> ListTour { get; set; }    //List to save the route (solution)
        
        public NearestInsertion(Data instance)
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
            
            //Add the city with minimum cost/distance from first city
            Node nextNodeToVisit = minDistanceNode(ListTour.Last(),listUnvisitedNodes);
            ListTour.Add(nextNodeToVisit);
            listUnvisitedNodes.Remove(nextNodeToVisit);
            
            while (listUnvisitedNodes.Count != 0)
            {
                //Find node with minimum distance to insert in the partial tour
                Node K = FindNodeToInsert(listUnvisitedNodes);

            }

            return ListTour;
        }

        public Node minDistanceNode(Node firstNodeTour, List<Node> listUnvisitedNodes)
        {
            var nextNode = new Node();
            int minD = Int16.MaxValue;
            foreach(Node n in listUnvisitedNodes)
            {
                int distvalue = firstNodeTour.DistanceTo(n);
                if ( distvalue < minD)
                {
                    minD = distvalue;
                    nextNode = n;
                }              
            }
            return nextNode;
        }

        public Node FindNodeToInsert(List<Node> listUnvisitedNodes)
        {
            Node chosenNode = new();
            int minD = Int16.MaxValue;
            foreach (var n in ListTour)
            {
                if (n!=ListTour[0])
                {
                    foreach (var u in listUnvisitedNodes)
                    {
                        int distanceValue = n.DistanceTo(u);
                        if (distanceValue < minD)
                        {
                            minD = distanceValue;
                            chosenNode = u;
                        }
                    }
                }
            }
            return chosenNode;
        }

        public void FindNearestPosition(Node k)
        {
            
        }
    }
}

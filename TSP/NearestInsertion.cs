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
                //Select node with minimum distance to insert in the partial tour
                Node K = SelectNodeToInsert(listUnvisitedNodes);
                //Insert node 
                InsertNodeAtNearestPosition(K, ListTour);
                listUnvisitedNodes.Remove(K);   //Remove node from unvisited nodes
            }

            //Add the return trip to the route
            ListTour.Add(ListTour[0]);

            int tourLength = CalculateDistanceOfTour(ListTour);

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

        public Node SelectNodeToInsert(List<Node> listUnvisitedNodes)
        {
            Node chosenNode = new();
            int minD = Int16.MaxValue;
            foreach (Node j in ListTour)
            {
                if (j!=ListTour[0])
                {
                    foreach (Node k in listUnvisitedNodes)
                    {
                        int distanceValue = j.DistanceTo(k);
                        if (distanceValue < minD)
                        {
                            minD = distanceValue;
                            chosenNode = k;
                        }
                    }
                }
            }
            return chosenNode;
        }

        public void InsertNodeAtNearestPosition(Node k, List<Node> routeList)
        {
            int minEdgeD = Int16.MaxValue;
            int positionToInsert = -1;
            for (int n = 0; n < routeList.Count - 1; n++)
            {
                Node i = routeList[n];
                Node j = routeList[n + 1];

                int edgeDistance = i.DistanceTo(k) + k.DistanceTo(j) - i.DistanceTo(j);

                if (edgeDistance < minEdgeD)
                 {
                    minEdgeD=edgeDistance;
                    positionToInsert = n + 1; 
                }
            }
            routeList.Insert(positionToInsert, k);
        }

        public int CalculateDistanceOfTour(List<Node> listRoute)
        {
            int totalDistance = 0;
            for (int i = 0; i < listRoute.Count - 1; i++)
            {
                Node org = listRoute[i];
                Node dest = listRoute[i + 1];

                totalDistance += org.DistanceTo(dest);
            }

            return totalDistance;
        }

    }
}

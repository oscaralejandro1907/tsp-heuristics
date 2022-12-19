using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    internal class CheapestInsertion
    {
        public Data Data { get; set; }
        public List<Node> ListNodes { get; set; }
        public List<Node> ListTour { get; set; }    //List to save the route (solution)

        public CheapestInsertion(Data data)
        {
            this.Data = data;
            this.ListTour = new();

            this.ListNodes = data.ListNodes;
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
            Node nextNodeToVisit = minDistanceNode(ListTour.Last(), listUnvisitedNodes);
            ListTour.Add(nextNodeToVisit);
            listUnvisitedNodes.Remove(nextNodeToVisit);

            while (listUnvisitedNodes.Count != 0)
            {
                //Insert Cheapest Nodes
                int minEdgeD = Int16.MaxValue;
                int insertAtPosition = -1;
                Node nodeToInsert = new();
                for (int n = 0; n < ListTour.Count - 1; n++)
                {
                    Node i = ListTour[n];
                    Node j = ListTour[n + 1];

                    foreach (Node k in listUnvisitedNodes)
                    {
                        int edgeDistance = i.DistanceTo(k) + k.DistanceTo(j) - i.DistanceTo(j);
                        if (edgeDistance < minEdgeD)
                        {
                            minEdgeD = edgeDistance;
                            insertAtPosition = n + 1;
                            nodeToInsert = k;
                        }
                    }
                }
                ListTour.Insert(insertAtPosition, nodeToInsert);
                listUnvisitedNodes.Remove(nodeToInsert);

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
            foreach (Node n in listUnvisitedNodes)
            {
                int distvalue = firstNodeTour.DistanceTo(n);
                if (distvalue < minD)
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

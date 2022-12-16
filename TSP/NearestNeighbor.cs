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
        public List<Node> ListNodeTour { get; set; }    //List to save the route (solution)
        
        public NearestNeighbor(Data instance)
        {
            this.Instance = instance;
            this.ListNodeTour = new();
            
            this.ListNodes = Instance.ListNodes;

        }

        public List<Node> Solve()
        {            
            List<Node> ListUnvisitedNodes = new(ListNodes);          

            //Start tour with just one city randomly chosen
            var random = new Random(0);
            int selectedNodeIndex = random.Next(ListNodes.Count);
            Node selectedNode = ListNodes[selectedNodeIndex];

            ListNodeTour.Add(selectedNode);           
            
            ListUnvisitedNodes.Remove(selectedNode);
            
            while (ListUnvisitedNodes.Count!=0)
            {
                //Find the closest unvisited city from the last visited node
                NextNodeToVisit(ListUnvisitedNodes);
            }

            return ListNodeTour;
        }

        public void NextNodeToVisit(List<Node> listUnvisitedNodes)
        {        
            Node N = ListNodeTour.Last();

            foreach(Node n in listUnvisitedNodes)
            {
                if (N.Name.Equals(n.Name))
                {
                    Edge e = 
                }
            }

            foreach(Edge e in N.ListEdges)
            {
                if(e.destiny == )
            }
            var chosenEdge = N.ListEdges.OrderBy(p => p.distance).FirstOrDefault();




                //return listUnvisitedNodes[0];


            //    Edge? chosenEdge = new Edge();  //? Sets Edge to nullable ref type
            //    chosenEdge = ListTour.Last().ListEdges.MinBy(e => e.distance);    //Chose The min edge from the last visited city

            //    bool isVisited;
            //    isVisited = ListTour.Exists(n => n.Name == chosenEdge.destiny);


            //    if (isVisited)
            //    {
            //        ListTour
            //    }                                                  


            //    if (!isVisited)
            //    {
            //        foreach (Node n in Instance.ListNodes)
            //        {
            //            if (n.Name == chosenEdge.destiny)
            //            {
            //                return n;
            //            }
            //        }
            //    }

            //    else
            //    {






        }


    }
}

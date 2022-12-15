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
        public List<Node> ListTour { get; set; }

        public NearestNeighbor(Data instance)
        {
            Instance = instance;
            ListTour = new List<Node>();
        }

        public void solve()
        {            
            List<Node> ListUnvisited = new List<Node>(Instance.ListNodes);

            //Start tour with just one city randomly chosen
            var random = new Random(0);
            int selectedNodeIndex = random.Next(ListUnvisited.Count);

            Node selectedNode = ListUnvisited[selectedNodeIndex];
            ListTour.Add(selectedNode);
            ListUnvisited.Remove(selectedNode);

            //Find the closest unvisited city from the last visited node

                //Check if the destiny is already visited
            foreach (Edge e in ListTour.Last().ListEdges)
            {               
                if(ListTour.Exists(n=>n.Name == e.destiny))
                {
                    ListTour.Last().ListEdges.Remove(e);
                }
            }

            var takeEdge = ListTour.Last().ListEdges.MinBy(e => e.distance);    //The min edge

            Node? N = ListUnvisited.Find(n => n.Equals(takeEdge.destiny));

            ListTour.Add()


            
            






        }

    }
}

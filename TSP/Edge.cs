using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    internal class Edge
    {
        public string origin;
        public string destiny;
        public int distance;

        public Edge(string origin, string destiny, int distance)
        {
            this.origin = origin;
            this.destiny = destiny;
            this.distance = distance;
        }

        public Edge()
        {
            origin = "";
            destiny = "";
            distance = -1;
        }
    }
}

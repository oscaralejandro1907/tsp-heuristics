namespace TSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            NearestNeighbor nearestNeighbor = new NearestNeighbor(data);
            nearestNeighbor.solve();
        }
    }
}
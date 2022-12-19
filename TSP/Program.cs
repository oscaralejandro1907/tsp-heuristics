namespace TSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            
            CheapestInsertion heuristic = new(data);
            heuristic.Solve();
        }
    }
}
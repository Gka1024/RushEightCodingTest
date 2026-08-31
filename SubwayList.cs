namespace Subway
{
    public static class SubwayList
    {
        public static void Initialize()
        {
            Console.WriteLine("Init");
        }
    }

    public class Station
    {
        public string name;
        public int line;

        public Station(string name, int line)
        {
            this.name = name;
            this.line = line;
        }
    }

}



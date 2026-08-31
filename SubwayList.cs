namespace Subway
{
    public static class SubwayList
    {
        public static void Initialize()
        {
            List<Station> stationsLine1 = new();
            List<Station> stationsLine2 = new();
            List<Station> stationsLine3 = new();
            List<Station> stationsLine4 = new();
            List<Station> stationsLine5 = new();
            List<Station> stationsLine6 = new();

            RegisterStation4();
        }

        private static void RegisterStation4()
        {
            Station ichon = new Station("이촌", 4);
            Station sinyongsan = new Station("신용산", 4);

            Connect(ichon, sinyongsan, 100);
        }

        private static void Connect(Station A, Station B, int time)
        {
            A.edges.Add(new Edge(B, time));
            B.edges.Add(new Edge(A, time));
        }
    }

    public class Station
    {
        public string name;
        public int line;
        public List<Edge> edges;

        public Station(string name, int line)
        {
            this.name = name;
            this.line = line;
        }
    }

    public class Edge
    {
        public Station destination;
        public int time;

        public Edge(Station destination, int time)
        {
            this.destination = destination;
            this.time = time;
        }
    }

}



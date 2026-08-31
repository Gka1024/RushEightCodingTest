namespace Subway
{
    public static class SubwayList
    {
        public static Dictionary<int, List<Station>> stationsByLine = new();
        
        public static void Initialize()
        {
            for(int i = 1; i <= 6; i++)
            {
                stationsByLine[i] = new();
            }

            RegisterStation4(stationsByLine[4]);
        }

        private static void RegisterStation4(List<Station> line)
        {
            // ==== 역 생성
            Station ichon = new Station("이촌", 4);
            Station sinyongsan = new Station("신용산", 4);


            // ==== 역 연결
            Connect(ichon, sinyongsan, 100);


            // ==== 역 추가
            line.Add(ichon);
            line.Add(sinyongsan);
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
        public List<Edge> edges = new();

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



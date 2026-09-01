namespace Subway
{
    public static class SubwayList
    {
        public static Dictionary<int, List<Station>> stationsByLine = new();
        public static Dictionary<string, List<Station>> stationsByName = new();


        public static void Initialize()
        {
            for (int i = 1; i <= 6; i++)
            {
                stationsByLine[i] = new();
            }

            RegisterStation4();
        }

        private static void Connect(Station A, Station B, int time)
        {
            A.edges.Add(new Edge(B, time));
            B.edges.Add(new Edge(A, time));
        }

        private static void Register(Station station)
        {
            stationsByLine[station.Line].Add(station);
            stationsByName[station.Name].Add(station);
        }

        public static List<Station> GetStation(string name)
        {
            stationsByName.TryGetValue(name, out var stations);
            return stations ?? new();
        }

        public static List<Station> GetAllStation()
        {
            List<Station> stations = new();
            for (int i = 1; i <= 6; i++)
            {
                stations.AddRange(stationsByLine[i]);
            }
            return stations;
        }

        public static Station SetVirtualStation(List<Station> stations)
        {
            Station start = new Station("시작", 1);
            foreach(Station station in stations)
            {
                start.edges.Add(new Edge(station, 0));
            }

            return start;
        }


        private static void RegisterStation4()
        {
            // ==== 역 생성
            Station ichon = new Station("이촌", 4);
            Station sinyongsan = new Station("신용산", 4);
            Station samgakji = new Station("삼각지", 4);
            Station sukdaeipgue = new Station("숙대입구", 4);
            Station seoulstation = new Station("서울역", 4);
            Station hoihyun = new Station("회현", 4);
            Station myeongdong = new Station("명동", 4);
            Station chungmuro = new Station("충무로", 4);
            Station DHCP = new Station("동대문역사문화공원", 4);
            Station dongdaemun = new Station("동대문", 4);
            Station hyehwa = new Station("혜화", 4);


            // ==== 역 연결
            Connect(ichon, sinyongsan, 100);
            Connect(sinyongsan, samgakji, 90);
            Connect(samgakji, sukdaeipgue, 100);
            Connect(sukdaeipgue, seoulstation, 100);
            Connect(seoulstation, hoihyun, 90);
            Connect(hoihyun, myeongdong, 90);
            Connect(myeongdong, chungmuro, 80);
            Connect(chungmuro, DHCP, 100);
            Connect(DHCP, dongdaemun, 90);
            Connect(dongdaemun, hyehwa, 90);


            // ==== 역 추가
            Register(ichon);
            Register(sinyongsan);
            Register(samgakji);
            Register(sukdaeipgue);
            Register(seoulstation);
            Register(hoihyun);
            Register(myeongdong);
            Register(chungmuro);
            Register(DHCP);
            Register(dongdaemun);
            Register(hyehwa);
        }


    }

    public class Station
    {
        public string Name { get; private set; }
        public int Line { get; private set; }
        public List<Edge> edges = new();

        public Station(string name, int line)
        {
            Name = name;
            Line = line;
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



namespace Subway
{
    public static class SubwayList
    {
        public static Dictionary<int, List<Station>> stationsByLine = new();
        public static Dictionary<string, List<Station>> stationsByName = new();


        public static void Initialize()
        {
            for (int i = 0; i <= 6; i++)
            {
                stationsByLine[i] = new();
            }

            RegisterStation1();
            RegisterStation2();
            RegisterStation3();
            RegisterStation4();
            RegisterStation5();
            RegisterStation6();

            RegisterTransfer();
        }

        private static void Connect(Station A, Station B, int time)
        {
            A.edges.Add(new Edge(B, time));
            B.edges.Add(new Edge(A, time));
        }

        private static void Register(Station station)
        {
            stationsByLine[station.Line].Add(station);

            if (!stationsByName.ContainsKey(station.Name))
            {
                stationsByName.Add(station.Name, new List<Station>());
            }
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
            for (int i = 0; i <= 6; i++)
            {
                stations.AddRange(stationsByLine[i]);
            }
            return stations;
        }

        public static Station SetVirtualStartStation(List<Station> stations)
        {
            Station start = new Station("시작", 0);
            foreach (Station station in stations)
            {
                start.edges.Add(new Edge(station, 0));
            }
            stationsByLine[0].Add(start);
            return start;
        }

        public static Station SetVirtualEndStation(List<Station> stations)
        {
            Station end = new Station("도착", 0);
            foreach (Station station in stations)
            {
                station.edges.Add(new Edge(end, 0));
            }
            stationsByLine[0].Add(end);
            return end;
        }

        private static void RegisterStation1()
        {
            Station yongsan = new Station("용산", 1);
            Station namyeong = new Station("남영", 1);
            Station seoulstation = new Station("서울역", 1);
            Station cityhall = new Station("시청", 1);
            Station jonggak = new Station("종각", 1);
            Station jongro3ga = new Station("종로3가", 1);
            Station jongro5ga = new Station("종로5가", 1);
            Station dongdaemun = new Station("동대문", 1);
            Station dongmyoap = new Station("동묘앞", 1);
            Station sinseoldong = new Station("신설동", 1);
            Station jegidong = new Station("제기동", 1);
            Station cheongryangri = new Station("청량리", 1);

            Connect(yongsan, namyeong, 110);
            Connect(namyeong, seoulstation, 120);
            Connect(seoulstation, cityhall, 120);
            Connect(cityhall, jonggak, 100);
            Connect(jonggak, jongro3ga, 90);
            Connect(jongro3ga, jongro5ga, 100);
            Connect(jongro5ga, dongdaemun, 100);
            Connect(dongdaemun, dongmyoap, 80);
            Connect(dongmyoap, sinseoldong, 80);
            Connect(sinseoldong, jegidong, 90);
            Connect(jegidong, cheongryangri, 100);

            Register(yongsan);
            Register(namyeong);
            Register(seoulstation);
            Register(cityhall);
            Register(jonggak);
            Register(jongro3ga);
            Register(jongro5ga);
            Register(dongdaemun);
            Register(dongmyoap);
            Register(sinseoldong);
            Register(jegidong);
            Register(cheongryangri);
        }

        private static void RegisterStation2()
        {
            Station dangsan = new Station("당산", 2);
            Station hapjeong = new Station("합정", 2);
            Station hongdaeipgu = new Station("홍대입구", 2);
            Station shinchon = new Station("신촌", 2);
            Station idae = new Station("이대", 2);
            Station ahyun = new Station("아현", 2);
            Station chungjungro = new Station("충정로", 2);
            Station cityhall = new Station("시청", 2);
            Station euljiroipgu = new Station("을지로입구", 2);
            Station euljiro3ga = new Station("을지로3가", 2);
            Station euljiro4ga = new Station("을지로4가", 2);
            Station DHCP = new Station("동대문역사문화공원", 2);
            Station shindang = new Station("신당", 2);
            Station sangwangsipri = new Station("상왕십리", 2);
            Station wangsipri = new Station("왕십리", 2);
            Station hanyangdae = new Station("한양대", 2);

            Connect(dangsan, hapjeong, 170);
            Connect(hapjeong, hongdaeipgu, 100);
            Connect(hongdaeipgu, shinchon, 110);
            Connect(shinchon, idae, 90);
            Connect(idae, ahyun, 90);
            Connect(ahyun, chungjungro, 90);
            Connect(chungjungro, cityhall, 110);
            Connect(cityhall, euljiroipgu, 90);
            Connect(euljiroipgu, euljiro3ga, 90);
            Connect(euljiro3ga, euljiro4ga, 80);
            Connect(euljiro4ga, DHCP, 100);
            Connect(DHCP, shindang, 100);
            Connect(shindang, sangwangsipri, 100);
            Connect(sangwangsipri, wangsipri, 90);
            Connect(wangsipri, hanyangdae, 100);

            Register(dangsan);
            Register(hapjeong);
            Register(hongdaeipgu);
            Register(shinchon);
            Register(idae);
            Register(ahyun);
            Register(chungjungro);
            Register(cityhall);
            Register(euljiroipgu);
            Register(euljiro3ga);
            Register(euljiro4ga);
            Register(DHCP);
            Register(shindang);
            Register(sangwangsipri);
            Register(wangsipri);
            Register(hanyangdae);

        }

        private static void RegisterStation3()
        {
            Station geongbokgung = new Station("경복궁", 3); // 제공해주신 자료에 경북궁 이라고 오타가 있습니다.
            Station anguk = new Station("안국", 3);
            Station jongro3ga = new Station("종로3가", 3);
            Station euljiro3ga = new Station("을지로3가", 3);
            Station chungmuro = new Station("충무로", 3);
            Station dongdaeipgu = new Station("동대입구", 3);
            Station yaksu = new Station("약수", 3);
            Station kumho = new Station("금호", 3);
            Station oksu = new Station("옥수", 3);

            Connect(geongbokgung, anguk, 100);
            Connect(anguk, jongro3ga, 90);
            Connect(jongro3ga, euljiro3ga, 70);
            Connect(euljiro3ga, chungmuro, 80);
            Connect(chungmuro, dongdaeipgu, 100);
            Connect(dongdaeipgu, yaksu, 90);
            Connect(yaksu, kumho, 90);
            Connect(kumho, oksu, 90);

            Register(geongbokgung);
            Register(anguk);
            Register(jongro3ga);
            Register(euljiro3ga);
            Register(chungmuro);
            Register(dongdaeipgu);
            Register(yaksu);
            Register(kumho);
            Register(oksu);

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

        private static void RegisterStation5()
        {
            Station mapo = new Station("마포", 5);
            Station gongduk = new Station("공덕", 5);
            Station aeogae = new Station("애오개", 5);
            Station chungjungro = new Station("충정로", 5);
            Station seodaemun = new Station("서대문", 5);
            Station gwanghwamun = new Station("광화문", 5);
            Station jongro3ga = new Station("종로3가", 5);
            Station euljiro4ga = new Station("을지로4가", 5);
            Station DHCP = new Station("동대문역사문화공원", 5);
            Station chunggu = new Station("청구", 5);
            Station shingumho = new Station("신금호", 5);
            Station hangdang = new Station("행당", 5);
            Station wangsipri = new Station("왕십리", 5);
            Station majang = new Station("마장", 5);

            Connect(mapo, gongduk, 100);
            Connect(gongduk, aeogae, 110);
            Connect(aeogae, chungjungro, 100);
            Connect(chungjungro, seodaemun, 90);
            Connect(seodaemun, gwanghwamun, 120);
            Connect(gwanghwamun, jongro3ga, 100);
            Connect(jongro3ga, euljiro4ga, 90);
            Connect(euljiro4ga, DHCP, 90);
            Connect(DHCP, chunggu, 100);
            Connect(chunggu, shingumho, 100);
            Connect(shingumho, hangdang, 100);
            Connect(hangdang, wangsipri, 100);
            Connect(wangsipri, majang, 100);

            Register(mapo);
            Register(gongduk);
            Register(aeogae);
            Register(chungjungro);
            Register(seodaemun);
            Register(gwanghwamun);
            Register(jongro3ga);
            Register(euljiro4ga);
            Register(DHCP);
            Register(chunggu);
            Register(shingumho);
            Register(hangdang);
            Register(wangsipri);
            Register(majang);
        }

        private static void RegisterStation6()
        {
            Station mangwon = new Station("망원", 6);
            Station hapjung = new Station("합정", 6);
            Station sangsu = new Station("상수", 6);
            Station gwangheungchang = new Station("광흥창", 6);
            Station daeheung = new Station("대흥", 6);
            Station gongduk = new Station("공덕", 6);
            Station hyochanggongwonap = new Station("효창공원앞", 6);
            Station samgakji = new Station("삼각지", 6);
            Station noksapeong = new Station("녹사평", 6);
            Station itaewon = new Station("이태원", 6);
            Station hangangjin = new Station("한강진", 6);
            Station beotigogae = new Station("버티고개", 6);
            Station yaksu = new Station("약수", 6);
            Station chunggu = new Station("청구", 6);
            Station shindang = new Station("신당", 6);
            Station dongmyoap = new Station("동묘앞", 6);
            Station changsin = new Station("창신", 6);

            Connect(mangwon, hapjung, 100);
            Connect(hapjung, sangsu, 100);
            Connect(sangsu, gwangheungchang, 100);
            Connect(gwangheungchang, daeheung, 100);
            Connect(daeheung, gongduk, 110);
            Connect(gongduk, hyochanggongwonap, 100);
            Connect(hyochanggongwonap, samgakji, 130);
            Connect(samgakji, noksapeong, 110);
            Connect(noksapeong, itaewon, 90);
            Connect(itaewon, hangangjin, 100);
            Connect(hangangjin, beotigogae, 110);
            Connect(beotigogae, yaksu, 90);
            Connect(yaksu, chunggu, 90);
            Connect(chunggu, shindang, 90);
            Connect(shindang, dongmyoap, 100);
            Connect(dongmyoap, changsin, 90);

            Register(mangwon);
            Register(hapjung);
            Register(sangsu);
            Register(gwangheungchang);
            Register(daeheung);
            Register(gongduk);
            Register(hyochanggongwonap);
            Register(samgakji);
            Register(noksapeong);
            Register(itaewon);
            Register(hangangjin);
            Register(beotigogae);
            Register(yaksu);
            Register(chunggu);
            Register(shindang);
            Register(dongmyoap);
            Register(changsin);
        }

        private static void RegisterTransfer()
        {
            foreach (var kvp in stationsByName)
            {
                if (kvp.Value.Count >= 2)
                {
                    SetTransfer(kvp.Value);
                }
            }
        }

        private static void SetTransfer(List<Station> stations)
        {
            for (int i = 0; i < stations.Count; i++)
            {
                for (int j = i + 1; j < stations.Count; j++)
                {
                    Connect(stations[i], stations[j], 180);
                }
            }
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



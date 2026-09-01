using System;
using System.Collections.Generic;
using System.ComponentModel;
using Subway;

class Program
{
    static void Main(string[] args)
    {
        Subway.SubwayList.Initialize();

        string start;
        string end;

        while (true)
        {
            Console.WriteLine("출발 역 : ");
            start = Console.ReadLine()!;
            Console.WriteLine("도착 역 : ");
            end = Console.ReadLine()!;

            if (CheckStationNameAvailable(start, end)) break;
        }

        Station startStation = SubwayList.SetVirtualStartStation(SubwayList.GetStation(start));
        Station endStation = SubwayList.SetVirtualEndStation(SubwayList.GetStation(end));

        List<Station> Path = Dijkstra(startStation, endStation);

        string pathString = MakePathString(Path);
        int spendTime = GetTimeByPath(Path);

        Console.WriteLine("이동경로 : " + pathString);
        Console.WriteLine($"총 소요 시간 : {spendTime / 60}분 {spendTime % 60}초");
    }

    private static bool CheckStationNameAvailable(string start, string end)
    {
        if (start == end)
        {
            Console.WriteLine("출발 역과 도착 역은 같을 수 없습니다.");
            return false;
        }

        if (SubwayList.GetStation(start).Count == 0 || SubwayList.GetStation(end).Count == 0)
        {
            Console.WriteLine("출발 역 또는 도착 역에 해당하는 역이 없습니다. 역 명을 확인해 주세요.");
            return false;
        }

        return true;
    }

    // 참고 : https://hsh12345.tistory.com/221
    public static List<Station> Dijkstra(Station start, Station dest)
    {
        List<Station> stations = SubwayList.GetAllStation();
        Dictionary<Station, bool> isVisited = new();
        Dictionary<Station, int> totalDistance = new();
        Dictionary<Station, Station?> parent = new();

        foreach (Station station in stations)
        {
            isVisited.Add(station, false);
            totalDistance.Add(station, int.MaxValue);
        }

        totalDistance[start] = 0;
        parent[start] = start;

        while (true)
        {
            Station? now = null;
            int closest = int.MaxValue;

            foreach (Station station in stations)
            {
                if (isVisited[station]) continue;

                if (totalDistance.TryGetValue(station, out int dist) && dist == int.MaxValue) continue;

                if (dist < closest)
                {
                    closest = dist;
                    now = station;
                }
            }

            if (now == null) break;

            isVisited[now] = true;

            foreach (Edge edge in now.edges)
            {
                Station next = edge.destination;
                if (isVisited[next]) continue;
                int nextDistance = totalDistance[now] + edge.time;

                if (nextDistance < totalDistance[next])
                {
                    totalDistance[next] = nextDistance;
                    parent[next] = now;
                }
            }
        }

        return CalcPathFromParent(parent, dest);
    }

    private static List<Station> CalcPathFromParent(Dictionary<Station, Station?> parent, Station dest)
    { // Parent (출발, 출발), (이촌, 출발), (신용산, 이촌), (삼각지, 신용산), (도착, 삼각지), dest : 도착
        Console.WriteLine($"{dest.Name}까지 최단 경로");
        List<Station> path = new();
        Station? temp = dest;

        while (temp != null)
        {
            if (!parent.ContainsKey(temp))
            {
                Console.WriteLine("경로를 찾을 수 없습니다.");
                return new List<Station>();
            }

            path.Add(temp);

            if (parent[temp] == temp) break;

            temp = parent[temp];
        }

        path.Reverse();
        return path;
    }

    private static string MakePathString(List<Station> Path)
    {
        string pathString = "";

        for (int i = 1; i < Path.Count - 1; i++) // 출발(0) -> 이촌 1 -> 신용산 2 -> 삼각지 3 -> 도착 ->
        {
            pathString += $"{Path[i].Name}({Path[i].Line})";

            if (i < Path.Count - 2)
            {
                pathString += " -> ";
            }
        }

        return pathString;
    }

    private static int GetTimeByPath(List<Station> Path)
    {
        int spendTime = 0;

        for (int i = 0; i < Path.Count - 1; i++)
        {
            foreach (Edge edge in Path[i].edges)
            {
                if (edge.destination == Path[i + 1])
                {
                    spendTime += edge.time;
                }
            }
        }

        return spendTime;
    }
}
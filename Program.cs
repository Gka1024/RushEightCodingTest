using System;
using System.Collections.Generic;
using System.ComponentModel;
using Subway;

class Program
{
    static void Main(string[] args)
    {
        Subway.SubwayList.Initialize();
        string start = Console.ReadLine()!;
        string end = Console.ReadLine()!;

        if (start == end)
        {
            Console.WriteLine("같은거 입력하지 마세요");
            return;
        }

        Console.WriteLine(start + end);
    }


    // 참고 : https://hsh12345.tistory.com/221
    public List<Station> Dijkstra(Station start, Station dest)
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

        parent.Add(start, null);

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
                if(isVisited[next]) continue;
                int nextDistance = totalDistance[now] + edge.time;

                if(nextDistance < totalDistance[next])
                {
                    totalDistance[next] = nextDistance;
                    parent[next] = now;
                }
            }
        }

        return CalcPathFromParent(parent, dest);
    }

    private List<Station> CalcPathFromParent(Dictionary<Station, Station?> parent, Station dest)
    {
        Console.WriteLine($"{dest}까지 최단 경로");
        List<Station> path = new();
        Station? temp = dest;

        while(temp != null)
        {
            path.Add(temp);

            if(parent[temp] == temp) break;

            temp = parent[temp];
        }

        path.Reverse();
        return path;
    }



}
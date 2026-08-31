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
        int nodesCount = Subway.SubwayList.GetAllStationCount();
        Dictionary<Station, bool> isVisited = new();
        Dictionary<Station, int> totalDistance = new();
        Dictionary<Station, Station?> parent = new();

        foreach(Station station in SubwayList.GetAllStation())
        {
            isVisited.Add(station, false);
            totalDistance.Add(station, int.MaxValue);
        }

        parent.Add(start, null);

        while(true)
        {
            Station? now = null;
            int closest = int.MaxValue;

            for(int i = 0; i < nodesCount; i++)
            {
                if(now == null) break;

                if(isVisited.TryGetValue(now, out bool value) && value) continue;
                
                if(totalDistance.TryGetValue(now, out int dist) && dist == int.MaxValue) continue;

                if(dist < closest)
                {
                    closest = dist;
                    // ???
                }

            }
        }

        
    }


}
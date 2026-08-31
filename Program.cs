using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Subway.SubwayList.Initialize();
        string start = Console.ReadLine()!;
        string end = Console.ReadLine()!;

        Console.WriteLine(start + end);
    }
}
using System.Diagnostics;

namespace AdventOfCode_202415;

public static class Executor
{
    
    
    public static void Execute_1(string pathToInput)
    {
        try
        {
            var sw = Stopwatch.StartNew();
            string inputFilePath =  Path.Combine(pathToInput, "advent2024-15-map.dat");
            var map = WarehouseMap.Create(File.ReadAllLines(inputFilePath));
                inputFilePath =  Path.Combine(pathToInput, "advent2024-15-moves.dat");
                var moves = File.ReadAllText(inputFilePath).AsSpan();
                foreach (var t in moves)
                {
                    if (t is '\r' or '\n')
                    {
                        continue;
                    }
                    
                    var updatedRobotAndMap = map.ApplyRobotMove(t);
                    map = WarehouseMap.FromRobotPositionAndMap(updatedRobotAndMap.newRobot,
                        updatedRobotAndMap.updatedMap);
                    //map.Print();
                    //Console.WriteLine();
                }

               // map.Print();
                Console.WriteLine($"Total GPS coordinates of all boxes is {map.GetBoxesCoordinatesSum()}");
                sw.Stop();
                Console.WriteLine(sw.Elapsed);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
    }
}
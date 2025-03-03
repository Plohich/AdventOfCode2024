namespace AdventOfCode_202414;

public static class Executor
{
    
    private static readonly (int dimX, int dimY)  Area = (101, 103);
    
    public static void Execute_1(string pathToInput)
    {
        try
        {
            string inputFilePath =  Path.Combine(pathToInput, "advent2024-14.dat");
            var safetyFactor = File.ReadAllLines(inputFilePath)
                .Select(item =>
                {
                    var data = item.Split(' ');
                    return Robot
                        .CreateRobotFromStrings(data[1], data[0])
                        .CalculateFutureRobotCoordinates(100, (robot, timeSpan) =>
                        {
                            int xCoord = (robot.Point.X + robot.Velocity.VelocityX * timeSpan) % Area.dimX;
                            if (xCoord < 0)
                            {
                                xCoord += Area.dimX;
                            }

                            int yCoord = (robot.Point.Y + robot.Velocity.VelocityY * timeSpan) % Area.dimY;
                            if (yCoord < 0)
                            {
                                yCoord += Area.dimY;
                            }

                            return new PointType(xCoord, yCoord);
                        })
                        .CalculateRobotQuadrant((pointType) => pointType switch
                            {
                                { X: >= 0 and < 50 } and { Y: >= 0 and < 51 } => 1,
                                { X: > 50 and < 101 } and { Y: >= 0 and < 51 } => 2,
                                { X: >= 0 and < 50 } and { Y: > 51 and < 103 } => 3,
                                { X: > 50 and < 101 } and { Y: > 51 and < 103 } => 4,
                                _ => -1
                            }
                        );
                })
                .CountBy(quadrant => quadrant)
                .Where(quadrant => quadrant.Key != - 1)
                .Select(robotCount => robotCount.Value)
                .Aggregate((x, y) => x * y);
              
          
            Console.WriteLine($"Safety factor after 100 seconds in {safetyFactor}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
    }
}
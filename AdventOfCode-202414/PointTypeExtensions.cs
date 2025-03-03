namespace AdventOfCode_202414;

public static class PointTypeExtensions
{
    public static int CalculateRobotQuadrant(this PointType pointType, Func<PointType, int> quadrantCalculator) => quadrantCalculator(pointType);
}
namespace AdventOfCode_202414;

public static class RobotExtensions
{
    public static PointType  CalculateFutureRobotCoordinates(this Robot robot, int timeSpan, Func<Robot, int, PointType> calculator) => calculator(robot, timeSpan);
}
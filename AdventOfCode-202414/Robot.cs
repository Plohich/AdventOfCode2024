namespace AdventOfCode_202414;

public class Robot
{
    public readonly VelocityType  Velocity;
    public  readonly PointType Point;

    private Robot(VelocityType velocityType, PointType pointType) => (Velocity, Point) = (velocityType, pointType);
    
    public static Robot CreateRobotFromStrings(string velocityStr, string pointStr) => new (VelocityType.Parse(velocityStr), PointType.Parse(pointStr));
}
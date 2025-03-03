namespace AdventOfCode_202415;

public static class RobotPositionTypeExtensions
{
    public static RobotPositionType Recalculate(this RobotPositionType position, char direction) =>
        new (CoordType.FromCoordType(position.Coordinates.Recalculate(direction)));
}
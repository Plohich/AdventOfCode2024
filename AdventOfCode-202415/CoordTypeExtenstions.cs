namespace AdventOfCode_202415;

public static class CoordTypeExtensions
{
    public static CoordType Recalculate(this CoordType coordinate, char direction) => direction switch
    {
        '^' => coordinate with { Y = coordinate.Y - 1 },
        'v' => coordinate with { Y = coordinate.Y + 1 },
        '>' => coordinate with { X = coordinate.X + 1 },
        '<' => coordinate with { X = coordinate.X - 1 },
        _ => coordinate
    };

}
namespace AdventOfCode_202414;

public record PointType(int X, int Y)
{
    public static PointType Parse(string pointType)
    {
        var components = pointType.Split('=').Last().Split(',');
        return new (int.Parse(components[0]), int.Parse(components[1]));
    }
};
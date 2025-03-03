namespace AdventOfCode_202414;

public record VelocityType(int VelocityX, int VelocityY)
{
    public static VelocityType Parse(string velocity)
    {
        var components = velocity.Split('=').Last().Split(',');
        return new (int.Parse(components[0]), int.Parse(components[1]));
    }
};
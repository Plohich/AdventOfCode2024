namespace AdventOfCode_202407;

public static class StringExtensions
{
    public static EquationCheck ConvertToEquationCheck(this string equation) => equation switch
    {
        { } s => new EquationCheck(long.Parse(equation.Split(":").First()),
            equation.Split(":").Last().Trim().Split(' ').Select(long.Parse).ToList()),
        _ => new EquationCheck(0, new List<long>())
    };
    
}
namespace AdventOfCode_202407;
public static class Executor
{
    public static void Execute(string pathToInput)
    {
        try
        {
            string inputFilePath =  Path.Combine(pathToInput, "advent2024-07.dat");
            using TextReader reader = new StreamReader(inputFilePath);
            long totalSum = 0;
            while (reader.ReadLine() is {} line)
            {
                long interim =  EquationMatcher.GetMatchOrZero(line);
                // long interim =  EquationMatcher.FindSolution(line ?? string.Empty);
                Console.WriteLine($"{interim}");
                totalSum +=interim;
            }
        
            Console.WriteLine($"Total sum: {totalSum}");
            Console.WriteLine(long.MaxValue.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
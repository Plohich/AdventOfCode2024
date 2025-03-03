namespace AdventOfCode_202401;

public static class Executor
{
    /// <summary>
    /// Requirement 1
    /// </summary>
    /// <param name="pathToInput"></param>
    public static void Execute_1(string pathToInput)
    {
        try
        {
           
            string inputFilePath =  Path.Combine(pathToInput, "advent2024-01.dat");
            var data = File.ReadAllLines(inputFilePath)
               .Select(item => (int.Parse(item.Split("   ")[0]), int.Parse(item.Split("   ")[1])))
                .ToArray();

            var dist1 = data.Select(item => item.Item1).ToArray();
            var dist2 = data.Select(item => item.Item2).ToArray();
            
         Array.Sort(dist1);
         Array.Sort(dist2);

          long totalDist = dist1.Zip(dist2).Select(e => Math.Abs(e.Item1 - e.Item2)).Sum();
            
          Console.WriteLine($"Total distance: {totalDist}");
           
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    /// <summary>
    /// Requirement 2
    /// </summary>
    /// <param name="pathToInput"></param>
    public static void Execute_2(string pathToInput)
    {
        try
        {
           
            string inputFilePath =  Path.Combine(pathToInput, "advent2024-01.dat"); 
            var data = File.ReadAllLines(inputFilePath)
                .Select(item => (int.Parse(item.Split("   ")[0]), int.Parse(item.Split("   ")[1])))
                .ToArray();

            var locations1 = data.Select(item => item.Item1);
            var locations2 = data.Select(item => item.Item2);
            long totalSimilarity = locations1.Select(l1 =>
                {
                    var matchCount = locations2
                                                        .CountBy(l2 => l1 == l2)
                                                        .FirstOrDefault(c => c.Key);
                    return matchCount is (false, _) ? 0 : l1 * matchCount.Value;
                })
                .Sum();
          
            
            Console.WriteLine($"Total similarity: {totalSimilarity}");
           
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
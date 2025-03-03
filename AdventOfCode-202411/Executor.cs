namespace AdventOfCode_202411;

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
            string inputFilePath =  Path.Combine(pathToInput, "advent2024-11.dat");
            var data = File.ReadAllLines(inputFilePath)
                                   .Select(item => item.Split(' '))
                                   .First();
            long stoneCount = StoneArranger(data, 0, 75);
            Console.WriteLine($"Last sequence contains {stoneCount} stones");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
    }

    private static IEnumerable<long> Transformer(string number)
    {
        IEnumerable<long> numbers = [];
        ReadOnlySpan<char> numberSpan = number.AsSpan();

        return (number, numberSpan.Length) switch
        {
            ("0", _) => numbers.Append(1),
            var (_, len) when len % 2 == 0 => numbers
                .Append(long.Parse(numberSpan.Slice(0, len / 2).ToString()))
                .Append(long.Parse(numberSpan.Slice(len / 2, len / 2).ToString())),
            _ => numbers.Append(long.Parse(number) * 2024)
        };

    }

    private static long StoneArranger(IEnumerable<string> stones, int currentBlinks, int maxBlinks)
    {

        var newSequence = CustomFlatten(stones.Select(Transformer));

        currentBlinks++;
        return (currentBlinks, maxBlinks) switch
        {
            var (curr, max) when curr == max => newSequence.LongCount(),
            _ => StoneArranger(newSequence, currentBlinks, maxBlinks)
        };
    }
    
    private static IEnumerable<string> CustomFlatten<T>(this IEnumerable<IEnumerable<T>> collections)
    {
        foreach (var collection in collections)
        {
            foreach (var item in collection)
            {
                yield return item.ToString();
            }
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
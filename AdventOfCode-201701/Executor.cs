namespace AdventOfCode_201701;
using System;
public static class Executor
{
    public static void Execute(string pathToInput)
    {
        try
        {
            var matches = new Dictionary<char, int>()
            {
                ['1'] = 0,
                ['2'] = 0,
                ['3'] = 0,
                ['4'] = 0,
                ['5'] = 0,
                ['6'] = 0,
                ['7'] = 0,
                ['8'] = 0,
                ['9'] = 0,
            };
            string inputFilePath =  Path.Combine(pathToInput, "advent2017-01.dat");
            var data  = File.ReadAllText(inputFilePath).TrimEnd().AsSpan();
           // int offset = 1; /*First part of requirement*/
            int offset = Math.DivRem(data.Length, 2, out _); /*Second part of req*/
            for(var idx = 0; idx < data.Length; idx++)
            {
                if (data[idx]  == data[(idx + offset) % data.Length])
                {
                    matches[data[idx]] = matches[data[idx]] + (data[idx] - '0');
                }
            }
        
            Console.WriteLine($"Total sum: {matches.Values.Sum()}");
           
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
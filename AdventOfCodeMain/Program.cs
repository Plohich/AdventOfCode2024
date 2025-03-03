
namespace AdventOfCode;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        string pathToInput = configuration.GetValue<string>("InputDataDirectory");

        // AdventOfCode_202407.Executor.Execute(configuration.GetValue<string>("InputDataDirectory"));

        //AdventOfCode_201701.Executor.Execute(configuration.GetValue<string>("InputDataDirectory"));

        // AdventOfCode_202401.Executor.Execute_2(pathToInput);

        //AdventOfCode_202411.Executor.Execute_1(pathToInput);

        // AdventOfCode_202414.Executor.Execute_1(pathToInput);
        
        AdventOfCode_202415.Executor.Execute_1(pathToInput);
    }
}
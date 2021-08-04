using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SE.Core;

namespace SE.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // setup the DI Builder
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISEStatistics, SEStatistics>()
                .BuildServiceProvider();

            var dynamicStatistics = serviceProvider.GetService<ISEStatistics>();
            StatisticsServiceApp statisticsServiceApp = new StatisticsServiceApp(dynamicStatistics);

            LogOutput(statisticsServiceApp.Mean, statisticsServiceApp.StandardDeviation,
                statisticsServiceApp.FrequenciesInBinsOfTens);

            Console.WriteLine("Press Enter key to exit");
            Console.ReadKey();
        }

        private static void LogOutput(decimal mean,
            decimal standardDeviation, IDictionary<int, int> frequency)
        {

            Console.WriteLine($"Mean = {mean}");
            Console.WriteLine($"Standard Deviation = {standardDeviation}");

            foreach (var key in frequency.Keys.OrderBy(_ => _))
                Console.WriteLine($"Bin {key} contains {frequency[key]} entries");
        }
    }
}

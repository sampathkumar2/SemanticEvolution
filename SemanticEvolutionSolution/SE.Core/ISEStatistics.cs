using System.Collections.Generic;

namespace SE.Core
{
    public interface ISEStatistics
    {
        /*
        void Add(IEnumerable<int> dataList);
        double Mean { get; }
        double StandardDeviation { get; }
        IDictionary<int, int> FrequenciesInBinsOfTens { get; }
        */

        void Add(IEnumerable<decimal> dataList);
        decimal Mean { get; }
        decimal StandardDeviation { get; }
        IDictionary<int, int> FrequenciesInBinsOfTens { get; }
    }
}
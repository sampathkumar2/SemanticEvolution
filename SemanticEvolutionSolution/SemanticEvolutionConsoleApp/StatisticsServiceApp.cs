using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SE.Core;

namespace SE.ConsoleApp
{
    public class StatisticsServiceApp
    {
        #region Fields

        private readonly ISEStatistics _dynamicStatistics;
        private string _fileName = @"SampleData.csv";

        #endregion

        #region Constructor

        public StatisticsServiceApp(ISEStatistics dynamicStatistics)
        {
            _dynamicStatistics = dynamicStatistics;

            #region Load Data

            if (!File.Exists(_fileName))
            {
                throw new FileNotFoundException();
            }

            var firstLine = File.ReadAllLines(_fileName)[0];
            var dataStringValues = firstLine.Split(',');
            var dataList = dataStringValues.Select(_ => Convert.ToDecimal(_));

            // In real app this could be a listener to some streaming event
            _dynamicStatistics.Add(dataList);

            #endregion

            
            
        }

        #endregion

        #region Public Properties

        public decimal Mean => Math.Round(_dynamicStatistics.Mean, 2);

        public decimal StandardDeviation => Math.Round(_dynamicStatistics.StandardDeviation, 2);

        public IDictionary<int, int> FrequenciesInBinsOfTens => _dynamicStatistics.FrequenciesInBinsOfTens;

        #endregion
    }
}
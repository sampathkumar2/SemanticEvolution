using System;
using System.Collections.Generic;
using System.Linq;

namespace SE.Core
{
    public class SEStatistics : ISEStatistics
    {
        #region Old Code
        /*

        #region Fields

        private object _lock = new object();
        private double _mean = 0, _previousMean = 0;
        private double _variance = 0;
        private int _dataLength = 0;
        private IDictionary<int, int> _frequencyDictionary = new Dictionary<int, int>();

        #endregion

        #region Properties

        public double Mean
        {
            get
            {
                lock (_lock)
                {
                    return _mean;
                }
            }
        }

        public double StandardDeviation {
            get
            {
                lock (_lock)
                {
                    if (_dataLength < 2)
                        return 0;

                    return Math.Sqrt(_variance / (_dataLength - 1));
                }
            }
        }
        public IDictionary<int, int> FrequenciesInBinsOfTens {
            get
            {
                lock (_lock)
                {
                    return _frequencyDictionary;
                }
            }
        }

        #endregion

        #region Public Methods

        public void Add(IEnumerable<int> dataList)
        {
            if (dataList == null || !dataList.Any())
                throw new ArgumentNullException();

            lock (_lock)
            {
                foreach (var data in dataList)
                {
                    _dataLength++;

                    //Complete the histogram frequency requirement
                    int key = data / 10;
                    if (_frequencyDictionary.ContainsKey(key))
                        _frequencyDictionary[key] = _frequencyDictionary[key] + 1;
                    else
                        _frequencyDictionary.Add(key, 1);

                    if (_dataLength == 1)
                    {
                        _mean = data;
                        _previousMean = _mean;
                        continue;
                    }

                    _mean = _previousMean + (data - _previousMean) / _dataLength;

                    _variance += (data - _previousMean) * (data - _mean);

                    _previousMean = _mean;

                    
                }
            }
            
        }

        #endregion

        */

        #endregion

        #region Fields

        private object _lock = new object();
        private decimal _mean = 0, _previousMean = 0;
        private decimal _variance = 0;
        private int _dataLength = 0;
        private IDictionary<int, int> _frequencyDictionary = new Dictionary<int, int>();

        #endregion

        #region Properties

        public decimal Mean
        {
            get
            {
                lock (_lock)
                {
                    return _mean;
                }
            }
        }

        public decimal StandardDeviation {
            get
            {
                lock (_lock)
                {
                    if (_dataLength < 2)
                        return 0;

                    return Convert.ToDecimal( Math.Sqrt((double)(_variance / (_dataLength - 1))));
                }
            }
        }
        public IDictionary<int, int> FrequenciesInBinsOfTens {
            get
            {
                lock (_lock)
                {
                    return _frequencyDictionary;
                }
            }
        }

        #endregion

        #region Public Methods

        public void Add(IEnumerable<decimal> dataList)
        {
            if (dataList == null || !dataList.Any())
                throw new ArgumentNullException();

            //Algorithm to compute mean + sd + frequency in single pass
            // using recurrence formula

            lock (_lock) //lock so that readers don't get to see stale statistics (debatable in it's importance)
            {
                foreach (var data in dataList)
                {
                    _dataLength++;

                    //Complete the histogram frequency requirement
                    int key = Convert.ToInt32(Math.Floor(data / 10)); // Math.Round() data / 10;
                    if (_frequencyDictionary.ContainsKey(key))
                        _frequencyDictionary[key] = _frequencyDictionary[key] + 1;
                    else
                        _frequencyDictionary.Add(key, 1);

                    if (_dataLength == 1)
                    {
                        _mean = data;
                        _previousMean = _mean;
                        continue;
                    }

                    _mean = _previousMean + (data - _previousMean) / _dataLength;

                    _variance += (data - _previousMean) * (data - _mean);

                    _previousMean = _mean;

                    
                }
            }
            
        }

        #endregion

        
    }
}
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SE.Core.Tests
{
    public class StandardDeviationTests
    {
        
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            3.03)]
        [TestCase(4, 6, 6, 2, 89, 45, 87, 75, 78, 32, 
            37.06)]
        public void SD_Should_Return_Correct_Value_For_Given_Test_Inputs(
            decimal no1, decimal no2, decimal no3, decimal no4, decimal no5,
            decimal no6, decimal no7, decimal no8, decimal no9, decimal no10,
            decimal expectedStandardDeviation
        )
        {
            //Arrange
            SEStatistics objectUnderTest = new SEStatistics();

            //Act
            objectUnderTest.Add(new List<decimal>
            {
                no1, no2, no3, no4, no5,
                no6, no7, no8, no9, no10
            });

            //Assert
            Assert.AreEqual(Math.Round(expectedStandardDeviation, MidpointRounding.ToZero), Math.Round(objectUnderTest.StandardDeviation, MidpointRounding.ToZero));
        }

        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            1.29, 3.03)]
        [TestCase(4, 6, 6, 2, 89, 45, 87, 75, 78, 32,
            1.91, 37.06)]
        //Streaming inputs so called because data can be added many times (as and when it arrives)
        public void SD_Should_Return_Correct_Cumulative_Value_For_Streaming_Input_Values(
            decimal no1, decimal no2, decimal no3, decimal no4, decimal no5,
            decimal no6, decimal no7, decimal no8, decimal no9, decimal no10,
           decimal firstCutExpectedStandardDeviation, decimal finalExpectedStandardDeviation
        )
        {
            //Arrange
            SEStatistics objectUnderTest = new SEStatistics();

            //Act
            objectUnderTest.Add(new List<decimal>
            {
                no1, no2, no3, no4, //first cut entry
                //no5, no6, no7, no8, no9, no10
            });

            //Assert
            Assert.AreEqual(Math.Round(firstCutExpectedStandardDeviation, MidpointRounding.ToZero), Math.Round(objectUnderTest.StandardDeviation, MidpointRounding.ToZero));

            //Act & Assert
            objectUnderTest.Add(new List<decimal>
            {
                no5, no6, no7, no8, no9, no10
            });

            Assert.AreEqual(Math.Round(finalExpectedStandardDeviation, MidpointRounding.ToZero), Math.Round(objectUnderTest.StandardDeviation, MidpointRounding.ToZero));
        }
    }
}
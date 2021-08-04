using System.Collections.Generic;
using NUnit.Framework;

namespace SE.Core.Tests
{

    public class MeanTests
    {
        /*
        [Test]
        public void Mean_Should_Return_Zero_If_Input_Data_List_Is_Null()
        {
            //Arrange
            Statistics objectUnderTest = new Statistics();

            //Act
            var result = objectUnderTest.Mean(null);

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Mean_Should_Return_Zero_If_Input_Data_List_Is_Empty()
        {
            //Arrange
            Statistics objectUnderTest = new Statistics();

            //Act
            var result = objectUnderTest.Mean(new List<int>());

            //Assert
            Assert.AreEqual(0, result);
        }

        */

        [TestCase(1,2,3,4,5,6,7,8,9,10, 5.5)]
        [TestCase(4, 6, 6, 2, 89, 45, 87, 75, 78, 32, 42.4)]
        public void Mean_Should_Return_Correct_Value_For_Given_Test_Inputs(
            decimal no1, decimal no2, decimal no3, decimal no4, decimal no5,
            decimal no6, decimal no7, decimal no8, decimal no9, decimal no10,
            decimal expectedMean
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
            Assert.AreEqual(expectedMean, objectUnderTest.Mean);
        }

        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 2.5, 5.5)]
        [TestCase(4, 6, 6, 2, 89, 45, 87, 75, 78, 32, 4.5, 42.4)]
        //Streaming inputs so called because data can be added many times (as and when it arrives)
        public void Mean_Should_Return_Correct_Cumulative_Value_For_Streaming_Input_Values(
            decimal no1, decimal no2, decimal no3, decimal no4, decimal no5,
            decimal no6, decimal no7, decimal no8, decimal no9, decimal no10,
            decimal firstCutExpectedMean, decimal finalExpectedMean
        )
        {
            //Arrange
            SEStatistics objectUnderTest = new SEStatistics();

            //Act
            objectUnderTest.Add(new List<decimal>
            {
                no1, no2, no3, no4, //First Cut
                //no5, no6, no7, no8, no9, no10
            });

            //Assert
            Assert.AreEqual(firstCutExpectedMean, objectUnderTest.Mean);

            //Act & Assert
            objectUnderTest.Add(new List<decimal>
            {
                no5, no6, no7, no8, no9, no10
            });
            Assert.AreEqual(finalExpectedMean, objectUnderTest.Mean);
        }
    }
}
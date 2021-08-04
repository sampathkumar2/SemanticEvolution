using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;

namespace SE.Core.Tests
{
    public class NumberFrequencyTest
    {

        [Test]
        [TestCase("CASE 1", new double[]
        {
            1, 20, 39
        }, TestName = "1")]

        [TestCase("CASE 2", new double[] { 75, 77, 85, 91, 100, 100 }, TestName = "2")]

        public void Frequency_Should_Return_Correct_Histogram_Dictionary_For_The_Given_Inputs(
            string caseNo, double[] inputs)
        {
            //Arrange
            SEStatistics objectUnderTest = new SEStatistics();

            //Act
            objectUnderTest.Add(inputs.Select(_=>Convert.ToDecimal(_)).ToList());

            //Assert

            if (caseNo.Equals("CASE 1"))
            {
                Assert.AreEqual(3, objectUnderTest.FrequenciesInBinsOfTens.Count);
                Assert.AreEqual(1, objectUnderTest.FrequenciesInBinsOfTens[0]); //first bin count
                Assert.AreEqual(1, objectUnderTest.FrequenciesInBinsOfTens[2]); //third bin count
                Assert.AreEqual(1, objectUnderTest.FrequenciesInBinsOfTens[3]); //third bin count
            }
            if (caseNo.Equals("CASE 2"))
            {
                Assert.AreEqual(4, objectUnderTest.FrequenciesInBinsOfTens.Count);
                Assert.AreEqual(2, objectUnderTest.FrequenciesInBinsOfTens[7]); //8th bin count
                Assert.AreEqual(1, objectUnderTest.FrequenciesInBinsOfTens[8]); //9th bin count
                Assert.AreEqual(1, objectUnderTest.FrequenciesInBinsOfTens[9]); //10th bin count
                Assert.AreEqual(2, objectUnderTest.FrequenciesInBinsOfTens[10]); //11th bin count (just 100's)
            }
        }

        [TestCase("CASE 2", new double[] { 75, 77 },
            new double[] { 85, 91, 100, 100 },
            TestName = "2")]

        //Streaming inputs so called because data can be added many times (as and when it arrives)
        public void Frequency_Should_Return_Correct_Histogram_Dictionary_For_Streaming_Inputs(
            string caseNo, double[] firstSetOfInputs, double[] finalSetOfInputs)
        {
            //Arrange
            SEStatistics objectUnderTest = new SEStatistics();

            //Act
            objectUnderTest.Add(firstSetOfInputs.Select(_ => Convert.ToDecimal(_)).ToList());

            //Assert
            Assert.AreEqual(1, objectUnderTest.FrequenciesInBinsOfTens.Count);
            Assert.AreEqual(2, objectUnderTest.FrequenciesInBinsOfTens[7]); //8th bin count

            //Act & Assert
            objectUnderTest.Add(finalSetOfInputs.Select(_ => Convert.ToDecimal(_)).ToList());
            Assert.AreEqual(4, objectUnderTest.FrequenciesInBinsOfTens.Count);
            Assert.AreEqual(2, objectUnderTest.FrequenciesInBinsOfTens[7]); //8th bin count
            Assert.AreEqual(1, objectUnderTest.FrequenciesInBinsOfTens[8]); //9th bin count
            Assert.AreEqual(1, objectUnderTest.FrequenciesInBinsOfTens[9]); //10th bin count
            Assert.AreEqual(2, objectUnderTest.FrequenciesInBinsOfTens[10]); //11th bin count (just 100's)

        }

    }


}
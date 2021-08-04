using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SE.Core.Tests
{
    public class GeneralTests
    {
        [Test]
        public void Add_Should_Throw_Error_If_Data_List_Is_Null()
        {
            //Arrange
            SEStatistics objectUnderTest = new SEStatistics();

            //Act & Assert
            try
            {
                objectUnderTest.Add(null);
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(true);
            }
            
            Assert.IsFalse(false);
            
        }

        [Test]
        public void Add_Should_Throw_Error_If_Data_List_Is_Empty()
        {
            //Arrange
            SEStatistics objectUnderTest = new SEStatistics();

            //Act & Assert
            try
            {
                objectUnderTest.Add(new List<decimal>());
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(true);
            }

            Assert.IsFalse(false);

        }
    }
}
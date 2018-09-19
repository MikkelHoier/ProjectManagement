using System;
using FluentAPI.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAPI.UnitTest
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void NameIsValid_ArgumentContainsNumbers_ReturnsFalse()
        {
            //Arrange
            string testString = "ke3k4m2n1";
            bool expectedBool = false;
            bool resultBool = true;
            //Act
            resultBool = Validator.NameIsValid(testString);
            //Assert
            Assert.AreEqual(resultBool, expectedBool);
        }

        [TestMethod]
        public void NameIsValid_ArgumentIsNullOrWhiteSpace_ReturnsFalse()
        {
            //Arrange
            string testString1 = "         ";
            string testString2 = null;

            bool expectedBool = false;
            bool resultBool1 = true;
            bool resultBool2 = true;
            //Act
            resultBool1 = Validator.NameIsValid(testString1);
            resultBool2 = Validator.NameIsValid(testString2);

            //Assert

            Assert.AreEqual(expectedBool, resultBool1);
            Assert.AreEqual(expectedBool, resultBool2);
        }

        [TestMethod]
        public void DateIsValid_ArgumentIsHigherThenDateTimeNow_ReturnsFalse()
        {
            DateTime? testDateTime = new DateTime(3000,1,1);
            bool expectedBool = false;
            bool resultBool = true;

            resultBool = Validator.DateIsValid(testDateTime);

            Assert.AreEqual(expectedBool, resultBool);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DT.CodeTest.Common.Helpers;

namespace DT.CodeTest.Common.Tests
{
    [TestClass]
    public class CurrencyHelperTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConvertCurrencyValueToTextString_InvalidInput_OutOfRange()
        {
            // arrange
            decimal testValue = new Decimal(9999999999999999);
            CurrencyHelper currencyHelper = new CurrencyHelper(false);

            // act
            string actualOutput = currencyHelper.ConvertCurrencyValueToTextString(testValue);

            // assert is handled by ExpectedException
        }

        [TestMethod]
        public void ConvertCurrencyValueToTextString_ValidInput_LowerCase_Success()
        {

            // arrange
            decimal testValue = new Decimal(123.45);
            bool outputToUpperCase = false;
            string expectedOutput = "one hundred and twenty-three dollars and forty-five cents";
            CurrencyHelper currencyHelper = new CurrencyHelper(outputToUpperCase);

            // act
            string actualOutput = currencyHelper.ConvertCurrencyValueToTextString(testValue);

            // assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [TestMethod]
        public void ConvertCurrencyValueToTextString_ValidInput_UpperCase_Success()
        {

            // arrange
            decimal testValue = new Decimal(123.45);
            bool outputToUpperCase = true;
            string expectedOutput = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS";
            CurrencyHelper currencyHelper = new CurrencyHelper(outputToUpperCase);

            // act
            string actualOutput = currencyHelper.ConvertCurrencyValueToTextString(testValue);

            // assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [TestMethod]
        public void ConvertCurrencyValueToTextString_ValidInput_MaxInputValue_Success()
        {

            // arrange
            decimal testValue = new Decimal(999999999999999.00);
            bool outputToUpperCase = true;
            string expectedOutput = "NINE HUNDRED AND NINETY-NINE TRILLION, NINE HUNDRED AND NINETY-NINE BILLION, NINE HUNDRED AND NINETY-NINE MILLION, NINE HUNDRED AND NINETY-NINE THOUSAND, NINE HUNDRED AND NINETY-NINE DOLLARS AND ZERO CENTS";
            CurrencyHelper currencyHelper = new CurrencyHelper(outputToUpperCase);

            // act
            string actualOutput = currencyHelper.ConvertCurrencyValueToTextString(testValue);

            // assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [TestMethod]
        public void ConvertCurrencyValueToTextString_ValidInput_NegativeInputValueWithZeroCents_Success()
        {

            // arrange
            decimal testValue = new Decimal(-1000.00);
            bool outputToUpperCase = true;
            string expectedOutput = "NEGATIVE ONE THOUSAND DOLLARS AND ZERO CENTS";
            CurrencyHelper currencyHelper = new CurrencyHelper(outputToUpperCase);

            // act
            string actualOutput = currencyHelper.ConvertCurrencyValueToTextString(testValue);

            // assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [TestMethod]
        public void ConvertCurrencyValueToTextString_ValidInput_ZeroDollarsAndCents_Success()
        {

            // arrange
            decimal testValue = new Decimal(0);
            bool outputToUpperCase = true;
            string expectedOutput = "ZERO DOLLARS AND ZERO CENTS";
            CurrencyHelper currencyHelper = new CurrencyHelper(outputToUpperCase);

            // act
            string actualOutput = currencyHelper.ConvertCurrencyValueToTextString(testValue);

            // assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [TestMethod]
        public void ConvertCurrencyValueToTextString_ValidInput_LargeInput_Success()
        {

            // arrange
            decimal testValue = new Decimal(1911655499123.99);
            bool outputToUpperCase = true;
            string expectedOutput = "ONE TRILLION, NINE HUNDRED AND ELEVEN BILLION, SIX HUNDRED AND FIFTY-FIVE MILLION, FOUR HUNDRED AND NINETY-NINE THOUSAND, ONE HUNDRED AND TWENTY-THREE DOLLARS AND NINETY-NINE CENTS";
            CurrencyHelper currencyHelper = new CurrencyHelper(outputToUpperCase);

            // act
            string actualOutput = currencyHelper.ConvertCurrencyValueToTextString(testValue);

            // assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [TestMethod]
        public void ConvertCurrencyValueToTextString_ValidInput_LargeRoundDollarInput_Success()
        {

            // arrange
            decimal testValue = new Decimal(9000000000.09);
            bool outputToUpperCase = true;
            string expectedOutput = "NINE BILLION DOLLARS AND NINE CENTS";
            CurrencyHelper currencyHelper = new CurrencyHelper(outputToUpperCase);

            // act
            string actualOutput = currencyHelper.ConvertCurrencyValueToTextString(testValue);

            // assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

    }
}

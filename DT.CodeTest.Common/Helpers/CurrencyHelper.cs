using DT.CodeTest.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.CodeTest.Common.Helpers
{
    public class CurrencyHelper : ICurrencyHelper
    {

        private bool _outputToUpperCase = false;
        public bool OutputToUpperCase { get; set; }

        /// <summary>
        /// Instantiate a new object which contains a boolean value to indicate upper case output is required
        /// </summary>
        /// <param name="targetUrl"></param>
        /// <param name="acceptResponseType"></param>
        public CurrencyHelper(bool outputToUpperCase)
        {
            _outputToUpperCase = outputToUpperCase;
        }
        public CurrencyHelper(ICurrencyHelper currencyHelper)
        {
            _outputToUpperCase = currencyHelper.OutputToUpperCase;
        }

        //The string pattern our class will output
        private const string outputPattern = "{0} dollars and {1} cents";

        /// <summary>
        /// Convert a decimal based currency value into a capitalised string of english text up to a maxiumum value of 999,999,999,999,999
        /// e.g. an input of 1123.45 will result in an output string value of "one thousand, one hundred and twenty-three dollars and forty-five cents"
        /// </summary>
        /// <param name="inputValue">a decimal based value to be converted</param>
        /// <returns>String</returns>
        public string ConvertCurrencyValueToTextString(decimal inputValue)
        {
            //check the paramter for range validity
            if (inputValue > 999999999999999)
                throw new ArgumentOutOfRangeException($"{nameof(inputValue)} is out of range.");

            //split any value after the decimal and convert to an integer
            int decimalValue = GetDecimalPlacesAsInteger(inputValue);
            //make sure our decimal value is not negative
            if (decimalValue < 0) decimalValue *= -1;
            //get the integer value from the decimal value
            Int64 intValue = (Int64)Math.Floor(inputValue);

            //create an instance of IntegerToTextHelper helper class to handle the actual conversion
            IntegerToTextHelper helper = new IntegerToTextHelper();

            //convert the "dollars" and "cents" integer values and format them into the required output string pattern
            string output = string.Format(outputPattern, helper.IntegerToEnglishText(intValue), helper.IntegerToEnglishText(decimalValue));

            //check for to upper case flag
            if (_outputToUpperCase)
                output = output.ToUpper();

            //return the output
            return output;
        }

        /// <summary>
        /// Return the first two decimal places of a decimal value as an integer
        /// </summary>
        /// <param name="inputValue">a decimal value to return the decimal places for</param>
        /// <returns>Integer</returns>
        private int GetDecimalPlacesAsInteger(decimal inputValue)
        {
            return (int)((inputValue % 1) * 100);
        }
    }
}


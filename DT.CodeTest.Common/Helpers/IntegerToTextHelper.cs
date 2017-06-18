using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.CodeTest.Common.Helpers
{
    class IntegerToTextHelper
    {
        //The numbers to words mappings. These are in arrays rather than using switch statement in the relevant functions to facilitate ease of modification i.e. to use a different language
        private static string[] baseNumberMappings = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static string[] baseTensMappings = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static string[] baseThousandsMappings = { "hundred", "thousand", "million", "billion", "trillion" };
        private const string separatorHundreds = ", ";
        private const string separatorTens = "-";
        private const string negativeSignifier = "negative";

        /// <summary>
        /// Convert an 64-bit integer input value into english text up to a maxiumum value of 999,999,999,999,999
        /// This function will call itself recursively
        /// </summary>
        /// <param name="input"></param>
        /// <returns>String</returns>
        public string IntegerToEnglishText(Int64 input)
        {

            //check the paramter for range validity
            if (input > 999999999999999)
                throw new ArgumentOutOfRangeException($"{nameof(input)} is out of range.");

            string result = "";
            //check for a negative value. If found and append to start of string and convert input to a positive value
            if (input < 0)
            {
                result = $"{negativeSignifier} ";
                input *= -1;
            }

            //check for a value less then 20 and return the converted text value if found
            if (input < 20)
                return ConvertNumberToText((int)input);

            //check for trillions
            Int64 baseValue = 1000000000000;
            if (input / baseValue > 0)
            {
                //append trillions value to string
                result += $"{IntegerToEnglishText((int)(input / baseValue))} {baseThousandsMappings[4]}{separatorHundreds}";
                //remove trillions value from input
                input %= baseValue;
            }

            //check for billions
            baseValue = 1000000000;
            if (input / baseValue > 0)
            {
                //append billions value to string
                result += $"{IntegerToEnglishText(input / baseValue)} {baseThousandsMappings[3]}{separatorHundreds}";
                //remove billions value from input
                input %= baseValue;
            }

            //check for millions
            baseValue = 1000000;
            if (input / baseValue > 0)
            {
                //append millions value to string
                result += $"{IntegerToEnglishText(input / baseValue)} {baseThousandsMappings[2]}{separatorHundreds}";
                //remove millions value from input
                input %= baseValue;
            }

            //check for thousands
            baseValue = 1000;
            if (input / baseValue > 0)
            {
                //append thousands value to string
                result += $"{IntegerToEnglishText(input / baseValue)} {baseThousandsMappings[1]}{separatorHundreds}";
                //remove thousands value from input
                input %= baseValue;
            }

            //check for hundreds
            baseValue = 100;
            if (input / baseValue > 0)
            {
                //append hundreds value to string
                result += $"{IntegerToEnglishText(input / baseValue)} {baseThousandsMappings[0]}";
                //remove hundreds value from input
                input %= baseValue;
                if (input > 0)
                    result += " and ";
            }

            //check if we anything left to convert below 100
            if (input > 0)
            {
                if (input < 20)
                    //we have a value below 20 so we can do a straight conversion
                    result += ConvertNumberToText((int)input);
                else
                {
                    //we have a value below between 20 and 99 so convert then tens value then the single-digit value and concatenate them
                    result += ConvertTensNumberToText((int)input / 10);
                    if ((input % 10) > 0)
                    {
                        result += $"{separatorTens}{ConvertNumberToText((int)input % 10)}";
                    }
                }
            }

            //check for a trailing separator and remove if found
            if (result.LastIndexOf(separatorHundreds) == (result.Length - separatorHundreds.Length))
                result = result.Substring(0, (result.Length - separatorHundreds.Length));
            
            //return the results
            return result;
        }

        private static string ConvertNumberToText(int input)
        {
            if (input >= 20)
                throw new IndexOutOfRangeException($"{nameof(input)} is out of range.");
            return baseNumberMappings[input];
        }

        private static string ConvertTensNumberToText(int input)
        {
            if (input >= 10)
                throw new IndexOutOfRangeException($"{nameof(input)} is out of range.");
            return baseTensMappings[input - 2];
        }

    }
}

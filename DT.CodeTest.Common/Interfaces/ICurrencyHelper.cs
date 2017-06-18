using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.CodeTest.Common.Interfaces
{
    public interface ICurrencyHelper
    {

        bool OutputToUpperCase { get; set; }
        
        /// <summary>
        /// Convert a decimal based currency value into a capitalised string of english text up to a maxiumum value of 999,999,999,999,999
        /// e.g. an input of 1123.45 will result in an output string value of "one thousand, one hundred and twenty-three dollars and forty-five cents"
        /// </summary>
        /// <param name="inputValue">a decimal based value to be converted</param>
        /// <returns>String</returns>
        string ConvertCurrencyValueToTextString(decimal inputValue);
    }
}

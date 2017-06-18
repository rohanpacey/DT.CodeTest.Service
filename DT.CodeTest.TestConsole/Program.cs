using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.CodeTest.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.Helpers.CurrencyHelper currencyHelper = new Common.Helpers.CurrencyHelper(true);
            decimal testValue = new Decimal(9000000000.09);
            string output = currencyHelper.ConvertCurrencyValueToTextString(testValue);
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}

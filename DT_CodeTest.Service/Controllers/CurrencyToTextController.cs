using DT.CodeTest.Common.Helpers;
using DT_CodeTest.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DT_CodeTest.Service.Controllers
{
    public class CurrencyToTextController : ApiController
    {

        private CurrencyHelper _CurrencyHelper;
        public CurrencyToTextController()
        {
            _CurrencyHelper = new CurrencyHelper(true);
        }

        /// <summary>
        /// Web service method to convert a decimal based currency value into a capitalised string of english text
        /// The method takes two parameters: a name and a string based amount value to be converted to text
        /// IHttpActionResult interface was implemented for ease of unit testing purposes
        /// </summary>
        /// <param name="name">a name, returned as is</param>
        /// <param name="value">a decimal based value to be converted</param>
        /// <returns>An object of type CurrencyText</returns>
        public IHttpActionResult GetCurrencyTextValue(string name, string value)
        {
            try
            {
                //check the parameters
                decimal intputValue;
                if (!decimal.TryParse(value, out intputValue))
                {
                    //cannot parse value to a decimal value
                    return BadRequest("The amount value is not valid.");
                }
                if (string.IsNullOrEmpty(name))
                {
                    //missing name parameter
                    return BadRequest("The name parameter cannot be empty.");
                }

                //parameters are good so perform conversion
                string output = _CurrencyHelper.ConvertCurrencyValueToTextString(intputValue);

                //create our return object and return it
                CurrencyText currencyText = new CurrencyText { name = name, valueText = output };

                return Ok(currencyText);
            }
            catch (Exception)
            {           
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using DT_CodeTest.Service;
using DT_CodeTest.Service.Controllers;
using System.Web.Http.Results;
using DT_CodeTest.Service.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace DT_CodeTest.Service.Tests1
{
    [TestClass]
    public class CurrencyToTextControllerTests
    {
        [TestMethod]
        public void GetCurrencyTextValue_ShouldReturnCorrectResult()
        {
            // arrange
            string testValue = "123.45";
            string expectedOutput = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS";
            string expectedName = "John Doe";
            var controller = new CurrencyToTextController();

            // act
            var result = controller.GetCurrencyTextValue(expectedName, testValue) as OkNegotiatedContentResult<CurrencyText>;

            // assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(expectedOutput, result.Content.valueText);
            Assert.AreEqual(expectedName, result.Content.name);
        }

        [TestMethod]
        public void GetCurrencyTextValue_LargeInput_ShouldReturnCorrectResult()
        {
            // arrange
            string testValue = "1911655499123.99";
            string expectedOutput = "ONE TRILLION, NINE HUNDRED AND ELEVEN BILLION, SIX HUNDRED AND FIFTY-FIVE MILLION, FOUR HUNDRED AND NINETY-NINE THOUSAND, ONE HUNDRED AND TWENTY-THREE DOLLARS AND NINETY-NINE CENTS";
            string expectedName = "John Doe";
            var controller = new CurrencyToTextController();

            // act
            var result = controller.GetCurrencyTextValue(expectedName, testValue) as OkNegotiatedContentResult<CurrencyText>;

            // assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(expectedOutput, result.Content.valueText);
        }

        [TestMethod]
        public void GetCurrencyTextValue_InvalidParameter_value()
        {
            // arrange
            string testValue = "123..45";
            string expectedName = "John Doe";
            var controller = new CurrencyToTextController();

            // act
            IHttpActionResult result = controller.GetCurrencyTextValue(expectedName, testValue) as OkNegotiatedContentResult<CurrencyText>;

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void GetCurrencyTextValue_InvalidParameter_name()
        {
            // arrange
            string testValue = "123.45";
            string expectedName = "";
            var controller = new CurrencyToTextController();

            // act
            IHttpActionResult result = controller.GetCurrencyTextValue(expectedName, testValue) as OkNegotiatedContentResult<CurrencyText>;

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }
    }
}

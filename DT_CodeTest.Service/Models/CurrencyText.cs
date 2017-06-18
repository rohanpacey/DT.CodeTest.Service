using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DT_CodeTest.Service.Models
{
    public class CurrencyText
    {
        public string name { get; set; }
        public string valueText { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
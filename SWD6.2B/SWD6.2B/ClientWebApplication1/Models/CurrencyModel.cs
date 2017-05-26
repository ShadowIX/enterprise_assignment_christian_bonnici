using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientWebApplication1.CurrencyReference;

namespace ClientWebApplication1.Models
{
    public class CurrencyModel 
    {
        public IEnumerable<string> Currencies { get; set; }

        public CurrencyModel()
        {
            ConverterSoapClient myclient = new ConverterSoapClient("ConverterSoap");
            string [] abbreviations = myclient.GetCurrencies();

            Currencies = abbreviations.AsEnumerable();

        }

        public decimal ConvertedValue { get; set; }
    }
}

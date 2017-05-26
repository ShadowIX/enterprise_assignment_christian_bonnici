using ClientWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientWebApplication1.CurrencyReference;
using ClientWebApplication1.UnitConverterReference;

namespace ClientWebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            CurrencyModel cm = new CurrencyModel();
            return View(cm);
        }
        [HttpPost]
        public ActionResult Index(string ddlFrom, string ddlTo, string v)
        {
            ConverterSoapClient client = new ConverterSoapClient("ConverterSoap");
           decimal rate=  client.GetConversionRate(ddlFrom, ddlTo, DateTime.Now);

           decimal answer = rate * Convert.ToDecimal(v);
           CurrencyModel cm = new CurrencyModel();
           cm.ConvertedValue = answer;

            return View(cm);
        }



        public ActionResult UnitConverter()
        {
            return View();
        }

        //http://..../Home/DegToFah?v=30
        public ActionResult DegToFah(string v)
        {
            UnitConverterClient myClient = new UnitConverterClient();
            ViewBag.Result = myClient.ConvertDegreesToFahrenheit(Convert.ToDouble(v));


            return Content(ViewBag.Result.ToString());
        }
    }
}

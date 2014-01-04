using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMDUtilities.ObjectExtensions.Converter;
using WMDUtilities.ObjectExtensions.Cloner;

namespace HelloWorldMVC.Controllers
{
    public class HomeController : Controller
    {
        private ICloner<string> myStringCloner;

        public HomeController(ICloner<string> serializingCloner)
        {
            this.myStringCloner = serializingCloner;

            var string1 = "Nijected Bitch!!";
            var string2 = myStringCloner.Clone(string1);
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

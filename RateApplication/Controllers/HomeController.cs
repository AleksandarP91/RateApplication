using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            ViewBag.Title = "Skills";

            return View();
        }
    }
}

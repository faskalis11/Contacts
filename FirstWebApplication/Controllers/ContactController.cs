using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApplication.Controllers
{
    public class ContactController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }

        //
        // GET: /Contact/Show/ 
        //public string Show(string name, int ID = 1)
        //{
        //    return HttpUtility.HtmlEncode("Hello " + name + ", ID: " + ID);
        //}
    }
}
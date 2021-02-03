using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vedauri.CRUD;

namespace Vedauri.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Website()
        {
            return View();
        }

        public ActionResult Software()
        {
            return View();
        }

        public ActionResult Marketing()
        {
            return View();
        }

        public ActionResult Support()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SendMessage(string email, string service, string msg)
        {
            return Json(new ContactCRUD().StoreContactMessage(email, service, msg), JsonRequestBehavior.AllowGet);
        }
    }
}
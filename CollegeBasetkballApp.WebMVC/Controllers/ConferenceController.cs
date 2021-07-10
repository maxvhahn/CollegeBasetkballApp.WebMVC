using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeBasetkballApp.WebMVC.Controllers
{
    public class ConferenceController : Controller
    {
        // GET: Conference
        public ActionResult Index()
        {
            return View();
        }
    }
}
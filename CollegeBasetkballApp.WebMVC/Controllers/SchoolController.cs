using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeBasetkballApp.WebMVC.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {
            return View();
        }

        // Get SchoolCreate View
        public ActionResult Create()
        {
            return View();
        }

        // Post SchoolCreate View


        // Get SchoolRead View


        // Post SchoolRead View


        // Get SchoolUpdate View


        // Post SchoolUpdate View


        // Get SchoolDelete View


        // Post SchoolDelete View
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSchool(int id)
        {

        }
    }
}
using CollegeSportsApp.Models.ConferenceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeBasetkballApp.WebMVC.Controllers
{  
    [Authorize]
    public class ConferenceController : Controller
    {
        // GET: Conference
        public ActionResult Index()
        {
            var model = new ConferenceListItem[0];
            return View(model);
        }

        // Get
        public ActionResult Create()
        {
            return View();
        }
    }
}
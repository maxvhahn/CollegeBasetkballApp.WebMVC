using CollegeSportsApp.Models.ConferenceModels;
using CollegeSportsApp.Services;
using Microsoft.AspNet.Identity;
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
            ConferenceService service = CreateConferenceService();
            var model = service.GetConferences();

            //var model = new ConferenceListItem[0];
            return View(model);
        }

        private ConferenceService CreateConferenceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ConferenceService(userId);
            return service;
        }

        // Get
        public ActionResult Create()
        {
            return View();
        }

        //Post
        //Conference/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConferenceCreate model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreateConferenceService();

            if (service.CreateConference(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Conference could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateConferenceService();
            var model = svc.GetConferenceById(id);

            return View(model);
        }
    }
}
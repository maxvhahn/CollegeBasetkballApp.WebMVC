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
            //ViewBag.ConferenceList = new ConferenceService().GetConferences().OrderBy(x => x.ConferenceName);
            return View();
        }

        //Post
        //Conference/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConferenceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateConferenceService();

            if (service.CreateConference(model))
            {
                TempData["SaveResult"] = "The conference was created!";
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

        public ActionResult DetailConference(int id)
        {
            var svc = CreateConferenceService();
            var model = svc.GetSchoolByConferenceId(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateConferenceService();
            var detail = service.GetConferenceById(id);
            var model =
                new ConferenceEdit
                {
                    ConferenceName = detail.ConferenceName
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConferenceEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.ConferenceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateConferenceService();

            if (service.UpdateConference(model))
            {
                TempData["Save Result"] = "The conference was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The conference could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateConferenceService();
            var model = svc.GetConferenceById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConference(int id)
        {
            var service = CreateConferenceService();

            service.DeleteConference(id);

            TempData["SaveResult"] = "The conference was deleted";

            return RedirectToAction("Index");
        }
    }
}
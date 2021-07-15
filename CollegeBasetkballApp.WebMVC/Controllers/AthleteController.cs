using CollegeSportsApp.Models.AthleteModels;
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
    public class AthleteController : Controller
    {
        // GET: Athlete
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AthleteService(userId);
            var model = service.GetAllAthletes();

            return View(model);
        }

        // Get: Create
        public ActionResult Create()
        {
            return View();
        }

        // Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AthleteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAthleteService();

            if (service.CreateAthlete(model))
            {
                TempData["SaveResult"] = "A team was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Team could not be created.");

            return View(model);

        }

        private AthleteService CreateAthleteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AthleteService(userId);
            return service;
        }

        // Get: Details View
        public ActionResult Details(int id)
        {
            var svc = CreateAthleteService();
            var model = svc.GetAthleteById(id);

            return View(model);
        }

        // Get: Update View
        public ActionResult Edit(int id)
        {
            var service = CreateAthleteService();
            var detail = service.GetAthleteById(id);
            var model =
                new AthleteEdit
                {
                    AthleteId = detail.AthleteId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName
                };
            return View(model);
        }

        // Post: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AthleteEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.AthleteId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAthleteService();

            if (service.UpdateAthlete(model))
            {
                TempData["SaveResult"] = "The athlete was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The athlete could not be updated");
            return View(model);
        }

        // Get: Delete View
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAthleteService();
            var model = svc.GetAthleteById(id);

            return View(model);
        }

        // Post: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAthlete(int id)
        {
            var service = CreateAthleteService();

            service.DeleteAthlete(id);

            TempData["SaveResult"] = "The athlete was deleted";

            return RedirectToAction("Index");
        }
    }
}
using CollegeSportsApp.Models.SportModels;
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
    public class SportController : Controller
    {
        // GET: Sport
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SportServices(userId);
            var model = service.GetSports();

            return View(model);
        }


        // Get: CreateSport View
        public ActionResult Create()
        {
            return View();
        }

        // Post: CreateSport View
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SportCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateSportService();

            if (service.CreateSport(model))
            {
                TempData["SaveResult"] = "The team was created.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private SportServices CreateSportService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SportServices(userId);
            return service;
        }

        // Get: ReadSport View
        public ActionResult Details(int id)
        {
            var svc = CreateSportService();
            var model = svc.GetSportById(id);

            return View(model);
        }

        // Post: UpdateSport View


        // Get: UpdateSport View
        public ActionResult Edit(int id)
        {
            var service = CreateSportService();
            var detail = service.GetSportById(id);
            var model =
                new SportEdit
                {
                    SportId = detail.SportId,
                    SportName = detail.SportName,
                    SportDescription = detail.SportDescription
                };
            return View(model);
        }

        // Post: UpdateSport View
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SportEdit model)
        {
            //if the modelstate isn't valid, return the model passed
            if(!ModelState.IsValid) return View();

            //if the model's sportId isn't equal to the id, say it's not matching
            if(model.SportId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSportService();

            if (service.UpdateSport(model))
            {
                TempData["SaveResult"] = "The sport was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The sport could not be updated.");
            //if the model and id are correct, return the view
            return View(model);
        }

        // Get: DeleteSport View
        public ActionResult Delete(int id)
        {
            var svc = CreateSportService();
            var model = svc.GetSportById(id);

            return View(model);
        }

        // Post: DeleteSport View
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSport(int id)
        {
            var service = CreateSportService();

            service.DeleteSport(id);

            TempData["SaveResult"] = "The sport was deleted.";

            return RedirectToAction("Index");
        }

    }
}
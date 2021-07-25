using CollegeSportsApp.Models.TeamModels;
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
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamService(userId);
            var model = service.GetTeams();

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
        public ActionResult Create(TeamCreate model)
        {
            if (!ModelState.IsValid) return View(model);
           
            var service = CreateTeamService();

            if (service.TeamCreate(model))
            {
                TempData["SaveResult"] = "A team was created.";
            return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Team could not be created.");

            return View(model);

        }

        private TeamService CreateTeamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamService(userId);
            return service;
        }

        // Get: Details View
        public ActionResult Details(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamById(id);

            return View(model);
        }

        // Get: Update View
        public ActionResult Edit(int id)
        {
            var service = CreateTeamService();
            var detail = service.GetTeamById(id);
            var model =
                new TeamEdit
                {
                    TeamName = detail.TeamName
                };
            return View(model);
        }

        //Get: Post View
        public ActionResult Edit(string teamName, TeamEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.TeamName != teamName)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTeamService();

            if (service.UpdateTeam(model))
            {
                TempData["SaveResult"] = "The team was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The team could not be updated.");
            return View(model);
        }

        //Get: Delete View
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamById(id);

            return View(model);
        }

        //Post: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTeam(int id)
        {
            var service = CreateTeamService();

            service.DeleteTeam(id);

            TempData["SaveResult"] = "The team was deleted";

            return RedirectToAction("Index");
        }
    }
}
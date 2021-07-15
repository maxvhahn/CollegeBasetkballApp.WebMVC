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
    }
}
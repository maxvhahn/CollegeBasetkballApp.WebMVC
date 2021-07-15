﻿using CollegeSportsApp.Models.SchoolModels;
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
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SchoolServices(userId);
            var model = service.GetSchools();

            return View(model);
        }

        // Get SchoolCreate View
        public ActionResult Create()
        {
            return View();
        }

        // Post SchoolCreate View
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SchoolServices(userId);

            service.CreateSchool(model);

            return RedirectToAction("Index");
        }

        private SchoolServices CreateSchoolService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SchoolServices(userId);
            return service;
        }

        // Get SchoolRead View
        public ActionResult Details(int id)
        {
            var svc = 
        }

        // Post SchoolRead View


        // Get SchoolUpdate View


        // Post SchoolUpdate View


        // Get SchoolDelete View
        public ActionResult Delete(int id)
        {
            var svc = CreateSchoolService();
            var model = svc.GetSchoolById(id);

            return View(model);
        }

        // Post SchoolDelete View
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSchool(int id)
        {
            var service = CreateSchoolService();

            service.DeleteSchool(id);

            TempData["SaveResult"] = "The school was deleted.";

            return RedirectToAction("Index");
        }
    }
}
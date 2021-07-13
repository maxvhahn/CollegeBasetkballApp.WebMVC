﻿using CollegeBasetkballApp.WebMVC.Data;
using CollegeSportsApp.Data;
using CollegeSportsApp.Models.SchoolModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Services
{
    public class SchoolServices
    {
        public bool CreateSchool(SchoolCreate model)
        {
            var entity =
                new School()
                {
                    SchoolName = model.SchoolName,
                    MascotName = model.MascotName,
                    City = model.City,
                    State = model.State,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Schools.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SchoolListItem> GetSchools()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Schools
                        .Select(e => new SchoolListItem
                        {
                            SchoolId = e.SchoolId,
                            SchoolName = e.SchoolName,
                            City = e.City,
                            State = e.State,
                        });
                return query.ToArray();
            }
        }

        public bool UpdateSchool(SchoolEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schools
                        .Single(e => e.SchoolId == model.SchoolId);
                entity.SchoolName = model.SchoolName;
                entity.MascotName = model.MascotName;
                entity.City = model.City;
                entity.State = model.State;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSchool(int schoolId)
        {
            //using statement for database
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schools
                        .Single(e => e.SchoolId == schoolId);

                ctx.Schools.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
            //Go through the database
            //Select the id to delete

            //Remove the entity

            //Save the changes
        }
    }
}
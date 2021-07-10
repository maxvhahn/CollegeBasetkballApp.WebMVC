﻿using CollegeBasetkballApp.WebMVC.Data;
using CollegeSportsApp.Data;
using CollegeSportsApp.Models.SportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Services
{
    public class SportServices
    {
        private readonly Guid _userId;

        public SportServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSport(SportCreate model)
        {
            var entity =
                new Sport()
                {
                    SportName = model.SportName,
                    SportDescription = model.SportDescription
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sports.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SportListItem> GetSports()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sports
                        .Select(e => new SportListItem()
                        {
                            SportId = e.SportId,
                            SportName = e.SportName
                        });
                return query.ToList();
            }
        }

        public bool UpdateSport(SportEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sports
                        .Single(e => e.SportId == model.SportId);

                entity.SportName = model.SportName;
                entity.SportDescription = model.SportDescription;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

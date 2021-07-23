using CollegeBasetkballApp.WebMVC.Data;
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

        //Create a Sport
        public bool CreateSport(SportCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var sport = ctx.Conferences.First();
                if (sport.OwnerId != _userId)
                    return false;

            var entity =
                new Sport()
                {
                    SportName = model.SportName,
                    SportDescription = model.SportDescription,
                };

                ctx.Sports.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // GetAllSports
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
                            SportName = e.SportName,
                            SportDescription = e.SportDescription
                        });
                return query.ToList();
            }
        }

        //Get Sport by Id
        public SportDetail GetSportById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sports
                        .Single(e => e.SportId == id);
                return
                    new SportDetail
                    {
                        SportId = entity.SportId,
                        SportName = entity.SportName,
                        SportDescription = entity.SportDescription
                    };
            }
        }

        //Update a Sport
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

        //Delete a Sport
        public bool DeleteSport(int sportId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sports
                        .Single(e => e.SportId == sportId);

                ctx.Sports.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

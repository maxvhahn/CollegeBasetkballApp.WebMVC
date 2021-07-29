using CollegeBasetkballApp.WebMVC.Data;
using CollegeSportsApp.Data;
using CollegeSportsApp.Models.AthleteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Services
{
    public class AthleteService
    {
        private readonly Guid _userId;
        public AthleteService(Guid userId)
        {
            _userId = userId;
        }

        //Create Athlete
        public bool CreateAthlete(AthleteCreate model)
        {
            var entity =
                new Athlete()
                {
                    OwnerId = _userId,
                    AthleteId = model.AthleteId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    TeamId = model.TeamId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Athletes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Read Athlete
        public IEnumerable<AthleteListItem> GetAllAthletes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Athletes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                        new AthleteListItem
                        {
                            AthleteId = e.AthleteId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            TeamId = e.TeamId,
                            Team = e.Team
                        });
                return query.ToArray().OrderBy(x => x.TeamId);
            }
        }

        public AthleteDetail GetAthleteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Athletes
                        .SingleOrDefault(e => e.AthleteId == id && e.OwnerId == _userId);
                return
                    new AthleteDetail
                    {
                        AthleteId = entity.AthleteId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName
                    };
            }
        }

        //Update Athlete
        public bool UpdateAthlete(AthleteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Athletes
                        .Single(e => e.AthleteId == model.AthleteId && e.OwnerId == _userId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }
        //Delete Athlete
        public bool DeleteAthlete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Athletes
                        .Single(e => e.AthleteId == id);

                ctx.Athletes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

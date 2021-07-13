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
        //Create Athlete
        public bool CreateAthlete(AthleteCreate model)
        {
            var entity =
                new Athlete()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Athletes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Read Athlete
        public IEnumerable<AthleteListItem> GetAllAthletes()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Athletes
                        .Select(e => new AthleteListItem
                        {
                            AthleteId = e.AthleteId,
                            FirstName = e.FirstName,
                            LastName = e.LastName
                        });
                return query.ToArray();
            }
        }
        //Update Athlete
        public bool UpdateAthlete(AthleteEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Athletes
                        .Single(e => e.AthleteId == model.AthleteId);
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

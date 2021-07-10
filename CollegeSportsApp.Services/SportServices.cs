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
    }
}

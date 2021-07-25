using CollegeBasetkballApp.WebMVC.Data;
using CollegeSportsApp.Data;
using CollegeSportsApp.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Services
{
    public class TeamService
    {
        private readonly Guid _userId;
        public TeamService(Guid userId)
        {
            _userId = userId;
        }

        //Create a Team
        public bool TeamCreate(TeamCreate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var team = ctx.Sports.Find();
                //if (team.OwnerId != _userId)
                //    return false;
            var entity =
                new Team()
                {
                    TeamName = model.TeamName,
                };

                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read a Team
        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams
                        .Select(e => new TeamListItem
                        {
                            TeamName = e.TeamName,
                        });
                return query.ToArray();
            }
        }

        //Get a Team by Id
        public TeamDetail GetTeamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == id);
                return
                    new TeamDetail
                    {
                        TeamName = entity.TeamName
                    };
            }
        }
        //Update a Team
        public bool UpdateTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single();

                entity.TeamName = model.TeamName;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete a Team
        public bool DeleteTeam(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                // query an entity in the database
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == id);

                //Remove the Team
                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

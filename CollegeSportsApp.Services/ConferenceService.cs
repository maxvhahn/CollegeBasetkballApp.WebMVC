using CollegeBasetkballApp.WebMVC.Data;
using CollegeSportsApp.Data;
using CollegeSportsApp.Models.ConferenceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Services
{
    public class ConferenceService
    {
        private readonly Guid _userId;

        public ConferenceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateConference(ConferenceCreate model)
        {
            var entity =
                new Conference()
                {
                    OwnerId = _userId,
                    ConferenceName = model.ConferenceName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Conferences.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ConferenceListItem> GetConferences()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Conferences
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ConferenceListItem
                                {
                                    ConferenceName = e.ConferenceName,
                                    ConferenceId = e.ConferenceId
                                });

                return query.ToArray();
            }
        }
    }
}

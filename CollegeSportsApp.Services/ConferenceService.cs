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
                    ConferenceId = model.ConferenceId,
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

        public ConferenceDetail GetConferenceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Conferences
                        .Single(e => e.ConferenceId == id && e.OwnerId == _userId);
                return
                    new ConferenceDetail
                    {
                        ConferenceId = entity.ConferenceId,
                        ConferenceName = entity.ConferenceName
                    };
            }
        }

        public bool UpdateConference(ConferenceEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Conferences
                        .Single(e => e.ConferenceId == model.ConferenceId && e.OwnerId == _userId);

                entity.ConferenceName = model.ConferenceName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteConference(int conferenceId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Conferences
                        .Single(e => e.ConferenceId == conferenceId && e.OwnerId == _userId);

                ctx.Conferences.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

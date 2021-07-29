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

        public ConferenceService()
        {

        }

        public bool CreateConference(ConferenceCreate model)
        {
            //if Conferenceid
            //return message already created
            var entity =
                new Conference()
                {
                    OwnerId = _userId,
                    ConferenceName = model.ConferenceName
                };

            using (var ctx = new ApplicationDbContext())
            {
                bool cName = ctx.Conferences.Any(e => e.ConferenceName.Equals(entity.ConferenceName));
                if (cName)
                {
                    return false;
                }

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
                                    ConferenceId = e.ConferenceId,
                                    ConferenceName = e.ConferenceName
                                });

                return query.ToArray().OrderBy(x => x.ConferenceName);
            }
        }

        public ConferenceDetail GetConferenceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Conferences
                        .SingleOrDefault(e => e.ConferenceId == id && e.OwnerId == _userId);
                return
                    new ConferenceDetail
                    {
                        ConferenceId = entity.ConferenceId,
                        ConferenceName = entity.ConferenceName
                    };
            }
        }

        public IEnumerable<School> GetSchoolByConferenceId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //Show a list of schools in an individual conference

                //Grab
                var conference = ctx.Conferences.Single(e => e.ConferenceId == id);
                var entity = conference.ListOfSchools.ToList();
                return entity;
            }
        }

        public bool UpdateConference(ConferenceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Conferences
                        .Single(e => e.ConferenceId == model.ConferenceId);

                entity.ConferenceName = model.ConferenceName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteConference(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Conferences
                        .Single(e => e.ConferenceId == id);

                ctx.Conferences.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

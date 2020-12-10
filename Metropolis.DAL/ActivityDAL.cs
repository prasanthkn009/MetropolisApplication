using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//funtions to perform add del update
namespace Metropolis.DAL
{
    public class ActivityDal : IActivityDal
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityDal(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Activity> GetActivities(DateTime fromDate, DateTime toDate)
        {
            return _dbContext.Activities
            .Where(x => x.ScheduledDate >= fromDate && x.ScheduledDate <= toDate)
             .ToList();
        }
        public bool AddActivity(Activity activity)
        {
            try
            {
                var activities = _dbContext.Activities;
                activities.Add(activity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool EditActivity(Activity activity, int id)
        {
            var activities = _dbContext.Activities.Where(x => x.ActivityId == id).FirstOrDefault();

            if (activities != null)
            {
                try
                {
                    activities.ActivityName = activity.ActivityName;
                    activities.ActivityType = activity.ActivityType;
                    activities.ScheduledDate = activity.ScheduledDate;
                    activities.StreetName = activity.StreetName;
                    activities.AlternativeStreet = activity.AlternativeStreet;
                    activities.IsClosed = activity.IsClosed;
                    _dbContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return false;
            }
        }
        public bool DeleteActivity(int id)
        {
            var activities = _dbContext.Activities.Where(x => x.ActivityId == id).FirstOrDefault();
            if (activities != null)
            {
                try
                {

                    _dbContext.Activities.Remove(activities);
                    _dbContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;

                }

            }
            else
            {
                return false;
            }
        }
        public List<Activity> AllActivity()
        {
            return _dbContext.Activities.ToList();

        }
    }
}


using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//funtions to perform add del update

namespace Metropolis.DAL
{
    public class ActivityDAL
    {
        private readonly ApplicationDbContext _dbcontext;

        public ActivityDAL(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public List<Activity> GetActivities(DateTime fromDate, DateTime toDate)
        {
            return _dbcontext.Activities
            .Where(x => x.ScheduledDate >= fromDate && x.ScheduledDate <= toDate)
            .ToList();
        }
        public bool AddActivity(Activity activity)
        {
            try
            {
                var activities = _dbcontext.Activities;
                activities.Add(activity);
                _dbcontext.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                throw ;
            }

        }
        public bool EditActivity(Activity activity, int id)
        {
            var activities = _dbcontext.Activities.Where(x => x.ActivityId == id).FirstOrDefault();

            if (activities != null)
            {
                try
                {
                    activities.ActivityName = activity.ActivityName;
                    activities.ActivityType = activity.ActivityType;
                    activities.StreetFk = activity.StreetFk;
   
                    _dbcontext.SaveChanges();
                    return true;
                }
                catch (Exception )
                {
                    throw;
                }
            }
            else
            {
                return false;
            }
        }
        public bool DeleteActivity(Activity activity, int id)
        {
            var activities = _dbcontext.Activities.Where(x => x.ActivityId == id).FirstOrDefault();
            if (activities != null)
            {
                try
                {

                    _dbcontext.Activities.Remove(activities);
                    _dbcontext.SaveChanges();
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
            return _dbcontext.Activities.ToList(); 
        }
    }
}


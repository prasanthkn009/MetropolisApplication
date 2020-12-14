using Metropolis.DAL;
using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metropolis.BLL
{
    public class ActivityBll : IActivityBll
    {
        private readonly IActivityDal _activityDal;
        private readonly ApplicationDbContext _db;
        public ActivityBll(IActivityDal activityDal, ApplicationDbContext db)
        {
            _activityDal = activityDal;
            _db = db;
        }

        public List<Activity> GetActivitiesForTheDay()

        {
            List<Activity> activities = new List<Activity>();
            var  fromDate = DateTime.UtcNow;
            var toDate = fromDate.AddDays(5);
            activities = _activityDal.GetActivities(fromDate, toDate);
            return activities.OrderBy(x => x.ScheduledDate).ThenByDescending(x => x.IsClosed).ThenBy(x => x.StreetName).ToList();
        }


        public void Add(Activity newdata) 
        {
            Activity data = new Activity();
            int count_activity_per_day = _db.Activities.Where(u => u.ScheduledDate == newdata.ScheduledDate).Count();
            data = _db.Activities.Where(u => u.ScheduledDate == newdata.ScheduledDate).FirstOrDefault(u => u.ActivityName == newdata.ActivityName);
            if (count_activity_per_day < 15 && data == null)
            { 
                if (newdata.IsClosed == true)
                {
                    int count_isclosed = _db.Activities.Where(u => u.ScheduledDate == newdata.ScheduledDate).Where(u => u.IsClosed == true).Count();
                    if (count_isclosed < 6) { _activityDal.AddActivity(newdata);}
                }
                else { _activityDal.AddActivity(newdata); } 
               
            }
        }


        public void Delete(int id)
        {
            _activityDal.DeleteActivity(id);
        }



        public void Update(Activity newdata, int id)
        {
            Activity data = new Activity();
            Activity rdata = new Activity();
            rdata = _db.Activities.FirstOrDefault(u => u.ActivityId == id);
            if (rdata!= null)
            {
                int count_activity_per_day = _db.Activities.Where(u => u.ScheduledDate == newdata.ScheduledDate).Count();
                data = _db.Activities.Where(u => u.ScheduledDate == newdata.ScheduledDate).FirstOrDefault(u => u.ActivityName == newdata.ActivityName);
                if (count_activity_per_day < 16 && data == null)
                {
                    if(newdata.IsClosed == true && rdata.IsClosed == false)
                    {
                        int count_isclosed = _db.Activities.Where(u => u.ScheduledDate == newdata.ScheduledDate).Where(u => u.IsClosed == true).Count();
                        if (count_isclosed < 7) { _activityDal.EditActivity(newdata, id); }

                    }
                    else { _activityDal.EditActivity(newdata, id); }
                }
               
            }
        }

    }
}
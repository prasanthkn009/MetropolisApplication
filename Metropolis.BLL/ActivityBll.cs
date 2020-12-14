using Metropolis.DAL;
using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metropolis.BLL
{
    /// <summary>
    /// The ActivityBll class.
    /// Contains all methods for performing basic logic functions.
    /// </summary>
    /// <remarks>
    /// This class can order the actvities and check the conditions for update and add activities.
    /// </remarks>
    public class ActivityBll : IActivityBll
    {
        private readonly IActivityDal _activityDal;
        private readonly ApplicationDbContext _db;
        public ActivityBll(IActivityDal activityDal, ApplicationDbContext db)
        {
            _activityDal = activityDal;
            _db = db;
        }
        
        
        
        // This method orders the list sorted alphabetically based on street name and ascending order of the day,
        // with the activities for which streets are completely closed appearing on the top of the list.

        public List<Activity> GetActivitiesForTheDay()
        {
            List<Activity> activities = new List<Activity>();
            var  fromDate = DateTime.UtcNow;
            var toDate = fromDate.AddDays(5);
            activities = _activityDal.GetActivities(fromDate, toDate);
            return activities.OrderBy(x => x.ScheduledDate).ThenByDescending(x => x.IsClosed).ThenBy(x => x.StreetName).ToList();
        }


        ///<summary>This method checks the conditions for adding the acitivities in to the list.</summary>
        /// This method checks the conditions for updating and adding the acitivities in to the list.
        
         /// 1.Check whether the steet is completly closed or not.
            /// 2.If the street is closed, check the condition that only a maximum of 6 can have the streets to be closed completely.
            /// 3.If the condition is true, add the activity to the database.
            /// 4.If the street is open, add the activity to the database.

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


        ///<summary> Method for deleting an activity with id.</summary>
        /// Method for deleting an activity with id..

        public void Delete(int Id)
        {
          _activityDal.DeleteActivity(Id);
        }

        
        
        
        
        ///<summary>Method for updating an activity with id.</summary>
        /// Method for updating an activity with id.

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

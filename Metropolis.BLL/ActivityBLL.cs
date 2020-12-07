using Metropolis.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Metropolis.BLL
{
   public class ActivityBLL
    {
        private readonly ActivityDAL _activityDAL;
        public ActivityBLL(ActivityDAL activityDAL)
        {
            _activityDAL = activityDAL;
        }
        public List<Activity> GetActivitiesFotTheDay()

        {
            List<Activity> activities = new List<Activity>();
            
            var fromDate = DateTime.UtcNow;
            var toDate = fromDate.AddDays(5);

            activities = _activityDAL.GetActivities(fromDate, toDate);

            return activities.Where(x => x.IsClosed == true).OrderBy(StreetName, ScheduledDate).ToList() + activities.Where(x => x.IsClosed != true).OrderBy(StreetName, ScheduledDate).ToList();
        }


    }
}

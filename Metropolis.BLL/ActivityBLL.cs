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
        public ActivityBLL(ActivityDal activityDAL)
        {
            _activityDAL = activityDAL;
        }
        public List<Activity> GetActivitiesFotTheDay()

        {
            List<Activity> activities = new List<Activity>();
            
           var  fromDate = DateTime.UtcNow;
            var todate = fromDate.AddDays(5);

            //call activityDAL

            return activities.OrderBy(x => x.IsStreetCompletelyClosed).ToList();
        }


    }
}

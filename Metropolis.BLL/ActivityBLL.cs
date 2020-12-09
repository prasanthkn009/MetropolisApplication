using Metropolis.DAL;
using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metropolis.BLL
{
    public class ActivityBLL : IActivityBLL
    {
        private readonly IActivityDAL _activityDAL;
        public ActivityBLL(IActivityDAL activityDAL)
        {
            _activityDAL = activityDAL;
        }
        public List<Activity> GetActivitiesForTheDay()

        {
            List<Activity> activities = new List<Activity>();

            var fromDate = DateTime.UtcNow;
            var toDate = fromDate.AddDays(5);

            activities = _activityDAL.GetActivities(fromDate, toDate);
            return activities.OrderBy(x => x.ScheduledDate).ThenByDescending(x => x.IsClosed).ThenBy(x => x.StreetName).ToList();
        }

        public void AddToDatabase(Activity newData) //data provided from view
        {
            List<Activity> data = new List<Activity>();
            data = _activityDAL.AllActivity(); // fetch the entire database
            int total = data.Where(x => x.ScheduledDate == newData.ScheduledDate).Count();
            int flag = 0;
            int count = 0;
            //int count = data.Where(x => x.IsClosed == New_data.IsClosed).Count();
            if (total < 15)
            {
                foreach (var element in data)
                {
                    if (element.ActivityName == newData.ActivityName && element.ScheduledDate == newData.ScheduledDate)
                    {
                        flag = 0;
                        break;
                        // "Activity with same name already exist for the date";
                    }

                    else { flag = 1; }

                }
            }
            if (flag ==1)
            { 

                if (newData.IsClosed == true)
                {
                    foreach(var Element in data)
                    {
                        if (Element.ScheduledDate == newData.ScheduledDate)
                        {
                            if (Element.IsClosed == true)
                            {
                                count++;
                            }
                        }
                        
                    }
                    if (count < 6) { _activityDAL.AddActivity(newData); }


                }
                 else 
                {
                    _activityDAL.AddActivity(newData);
                }
            }
        }
        public void Delete(int Id)
        {
            bool c = _activityDAL.DeleteActivity(Id);


        }
        public void Update(Activity newData, int Id)
        {
            bool c = _activityDAL.EditActivity(newData, Id);

        }




    }
}
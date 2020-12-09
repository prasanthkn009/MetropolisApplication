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

            return activities.OrderByDescending(x => x.IsClosed).ThenBy(x => x.StreetName).ThenBy(x => x.ScheduledDate).ToList();
        }

        public void AddToDatabase(Activity New_data) //data provided from view
        {
            List<Activity> data = new List<Activity>();
            data = _activityDAL.AllActivity(); // fetch the entire database
            int Total = data.Where(x => x.ScheduledDate == New_data.ScheduledDate).Count();
            int flag = 0;
            int count = 0;
            //int count = data.Where(x => x.IsClosed == New_data.IsClosed).Count();
            if (Total < 15)
            {
                foreach (var Element in data)
                {
                    if (Element.ActivityName == New_data.ActivityName && Element.ScheduledDate == New_data.ScheduledDate)
                    {
                        break;
                        // "Activity with same name already exist for the date";
                    }

                    else { flag = 1; }

                }
            }
            if (flag ==1)
            { 

                if (New_data.IsClosed == true)
                {
                    foreach(var Element in data)
                    {
                        if (Element.ScheduledDate == New_data.ScheduledDate)
                        {
                            if (Element.IsClosed == true)
                            {
                                count++;
                            }
                        }
                        
                    }
                    if (count < 6) { _activityDAL.AddActivity(New_data); }


                }
            else 
                {
                    _activityDAL.AddActivity(New_data);
                }
            }
        }
        public void Delete(int Id)
        {
            bool c = _activityDAL.DeleteActivity(Id);


        }
        public void update(Activity New_data, int Id)
        {
            bool c = _activityDAL.EditActivity(New_data, Id);

        }




    }
}
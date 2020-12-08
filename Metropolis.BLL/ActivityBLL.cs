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
            int count = data.Where(x => x.IsClosed == New_data.IsClosed).Count();
            if (Total < 15)
            {
                if (New_data.IsClosed == true)
                {
                    if (count < 6)
                    {
                        foreach (var Element in data)
                        {
                            if (Element.ActivityName == New_data.ActivityName)
                            {
                                if (Element.ScheduledDate == New_data.ScheduledDate) { break; }
                                else { _activityDAL.AddActivity(New_data); }
                                // "Activity with same name already exist for the date";
                            }
                            else { _activityDAL.AddActivity(New_data); }
                        }
                    }

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
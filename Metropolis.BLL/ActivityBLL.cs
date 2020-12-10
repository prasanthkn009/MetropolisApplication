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
        public ActivityBll(IActivityDal activityDal)
        {
            _activityDal = activityDal;
        }
        public List<Activity> GetActivitiesForTheDay()

        {
            List<Activity> activities = new List<Activity>();
            
           var  fromDate = DateTime.UtcNow;
            var toDate = fromDate.AddDays(5);

            activities = _activityDal.GetActivities(fromDate, toDate);
            return activities.OrderBy(x => x.ScheduledDate).ThenByDescending(x => x.IsClosed).ThenBy(x => x.StreetName).ToList();
        }

        public void AddToDatabase(Activity newData) //data provided from view
        {
            List<Activity> data = new List<Activity>();
            data = _activityDal.AllActivity(); // fetch the entire database
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
                    if (count < 6) { _activityDal.AddActivity(newData); }


                }
                 else 
                {
                    _activityDal.AddActivity(newData);
                }
            }
        }
        public void Delete(int Id)
        {
            bool c = _activityDal.DeleteActivity(Id);


        }
        public void Update(Activity newData, int id)
        {
            bool c = _activityDal.EditActivity(newData, id);

        }




    }
}
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
<<<<<<< HEAD

=======
        // This method orders the list sorted alphabetically based on street name and ascending order of the day,
        // with the activities for which streets are completely closed appearing on the top of the list.
>>>>>>> 85b0c5b2f9532f44c5bd0fb7e9e066e5e8079720
        public List<Activity> GetActivitiesForTheDay()

        {
            List<Activity> activities = new List<Activity>();
            var  fromDate = DateTime.UtcNow;
            var toDate = fromDate.AddDays(5);
            activities = _activityDal.GetActivities(fromDate, toDate);
            return activities.OrderBy(x => x.ScheduledDate).ThenByDescending(x => x.IsClosed).ThenBy(x => x.StreetName).ToList();
        }

<<<<<<< HEAD

        public void Add(Activity newdata) 
        {
            Activity data = new Activity();
            int count_activity_per_day = _db.Activities.Where(u => u.ScheduledDate == newdata.ScheduledDate).Count();
            data = _db.Activities.Where(u => u.ScheduledDate == newdata.ScheduledDate).FirstOrDefault(u => u.ActivityName == newdata.ActivityName);
            if (count_activity_per_day < 15 && data == null)
=======
        ///<summary>This method checks the conditions for adding the acitivities in to the list.</summary>


        /// This method checks the conditions for updating and adding the acitivities in to the list.
        public void AddToDatabase(Activity newData) //data provided from view
        {
            ///Fetch the entire database of activities to the variable data.
            List<Activity> data = new List<Activity>();
            data = _activityDal.ReturnAllActivity(); /// fetch the entire database
            int total = data.Where(x =>( x.ScheduledDate )== newData.ScheduledDate).Count();
            int flag = 0;
            int count = 0;
          
            /// 1. Checking the  condition that only a maximum of 15 activities can be performed in a day.
            /// 2.Check that the provided activity name is already existing in the database within the same date.
            /// 3. If it is true, flag = 0 and break.
            /// 4. If it is false, flag = 1.
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
            /// 1.Check whether the steet is completly closed or not.
            /// 2.If the street is closed, check the condition that only a maximum of 6 can have the streets to be closed completely.
            /// 3.If the condition is true, add the activity to the database.
            /// 4.If the street is open, add the activity to the database.
            if (flag ==1)
>>>>>>> 85b0c5b2f9532f44c5bd0fb7e9e066e5e8079720
            { 
                if (newdata.IsClosed == true)
                {
                    int count_isclosed = _db.Activities.Where(u => u.ScheduledDate == newdata.ScheduledDate).Where(u => u.IsClosed == true).Count();
                    if (count_isclosed < 6) { _activityDal.AddActivity(newdata);}
                }
                else { _activityDal.AddActivity(newdata); } 
               
            }
        }
<<<<<<< HEAD


        public void Delete(int id)
=======

        ///<summary> Method for deleting an activity with id.</summary>
       
 
        /// Method for deleting an activity with id..

        public void Delete(int Id)
        {
            bool c = _activityDal.DeleteActivity(Id);


        }

        ///<summary>Method for updating an activity with id.</summary>

        
        /// Method for updating an activity with id.

        public void Update(Activity newData, int id)
>>>>>>> 85b0c5b2f9532f44c5bd0fb7e9e066e5e8079720
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
using System;
using System.Collections.Generic;
using System.Text;
using Metropolis.DAL;
using System.Linq;
using Metropolis.DAL.Entities;

namespace Metropolis.BLL
{
    public class AddBLL
    {
        private readonly ActivityDAL _activityDAL;
        public AddBLL(ActivityDAL activityDAL)
        {
            _activityDAL = activityDAL;
        }
        public void AddToDatabase(List<Activity> New_data) //data provided from view
        {
            List<Activity> data = new List<Activity>();
            data = _activityDAL.AllActivity(); // fetch the entire database
            int Flag = 0;
            string Errmsg;
            int Total = data.Where(x => x.ScheduledDate == New_data.ScheduledDate).Count();
            int count = data.Where(x => x.IsClosed== New_data.IsClosed).Count(); 
<<<<<<< HEAD
           
=======
            foreach (List<Activity>Element in data)
            {
                if (Element.ActivityName.where(x => x.ScheduledDate == New_data.ScheduledDate) == New_data.ActivityName) 
                {
                    Errmsg = "Activity with same name already exist for the date";
                    Flag = 0;
                    break;
                }
                else { Flag = 1; }
            }
>>>>>>> 9f75f09d7e8ba81d9a1415df344745a33784e087
            if (Total < 15)
            {
                if (New_data.IsClosed == true)
                {
                    if (count < 6) 
                    {
                        foreach (List<Activity> Element in data)
                        {
                            if (Element.ActivityName.where(x => x.ScheduledDate == New_data.ScheduledDate) == New_data.ActivityName)

                            {
                                Errmsg = "Activity with same name already exist for the date";
                                Flag = 0;
                                break;
                            }
                            else { Flag = 1; }
                        }
                     }
                    else
                    {
                        Errmsg = "Already 6 activities with street status=closed is present ";
                        Flag = 0;
                    }
                }
                else
                {
                    Errmsg = $"Already 15 activities are present for the date{New_data.ScheduledDate}";
                    Flag = 0;

                }
            }
            if (Flag == 1)
            {
                AddActivity(List<Activity> New_data);//add to database
            }   
           
        }

    }
}

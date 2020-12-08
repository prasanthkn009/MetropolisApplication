using System;
using System.Collections.Generic;
using System.Text;
using Metropolis.DAL;
using System.Linq;
using Metropolis.DAL.Entities;

namespace Metropolis.BLL
{
    public class AddBLL : IAddBLL
    {
        private readonly ActivityDAL _activityDAL;
        public AddBLL(ActivityDAL activityDAL)
        {
            _activityDAL = activityDAL;
        }
        public void AddToDatabase(List<Activity> New_data) //data provided from view
        {
            List<Activity> New_data = new List<Activity>();
            this.New_data = New_data;
            List<Activity> data = new List<Activity>();
            data = _activityDAL.AllActivity(); // fetch the entire database
            //int Flag = 0;
            //string Errmsg;
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
                            if (Element.ActivityName.Where(Element => Element.ScheduledDate == New_data.ScheduledDate) == New_data.ActivityName)

                            {
                                // "Activity with same name already exist for the date";
                                //Flag = 0;
                                break;
                            }
                            else
                            {
                                _activityDAL.AddActivity(Activity New_data);//add to database }
                            }
                        }
                    }

                }

            }

        }
    }
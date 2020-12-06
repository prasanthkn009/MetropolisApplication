using System;
using System.Collections.Generic;
using System.Text;
using Metropolis.DAL;
using System.Linq;

namespace Metropolis.BLL
{
    public class AddBLL
    {
        private readonly ActivityDAL _activityDAL;
        public AddBLL(ActivityDAL activityDAL)
        {
            _activityDAL = activityDAL;
        }
        public List<ActivityDAL> DataList()
            List<ActivityDAL> data = new List<ActivityDAL>();
            //data = _activityDAL.GetAllActivities(); GetAllActivities declaerd in DLL layer to fetch the entire database
            return Data.Tolist();
        
        public void AddData
        {
            List<ActivityDAL> data = new List<ActivityDAL>();
            data = _activityDAL.GetActivities();
            if()

            return activities.ToList();
        }


    }
}

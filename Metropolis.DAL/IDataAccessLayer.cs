using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
//interface
namespace Metropolis.DAL
{
    interface IDataAccessLayer
    {
        List<Activity> GetActivities(DateTime fromDate, DateTime toDate);
        bool AddActivity(Activity activity);
        bool EditActivity(Activity activity, int id);
        bool DeleteActivity(Activity activity, int id);
        List<Activity> AllActivity();
    }   
}

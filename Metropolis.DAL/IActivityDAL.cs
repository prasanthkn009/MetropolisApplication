using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Metropolis.DAL
{
    public interface IActivityDAL
    {
        bool AddActivity(Activity activity);
        List<Activity> AllActivity();
        bool DeleteActivity(Activity activity, int id);
        bool EditActivity(Activity activity, int id);
        List<Activity> GetActivities(DateTime fromDate, DateTime toDate);
    }
}
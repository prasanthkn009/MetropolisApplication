using Metropolis.Dal.Entities;
using System;
using System.Collections.Generic;

namespace Metropolis.Dal
{
    public interface IActivityDal
    {
        bool AddActivity(Activity activity);
        List<Activity> ReturnAllActivity();
        bool DeleteActivity(int id);
        bool EditActivity(Activity activity, int id);
        List<Activity> GetActivities(DateTime fromDate, DateTime toDate);
    }
}

using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Metropolis.DAL
{
    public interface IActivityDal
    {
        bool AddActivity(Activity activity);
        bool DeleteActivity(int id);
        bool EditActivity(Activity activity, int id);
        List<Activity> GetActivities(DateTime fromDate, DateTime toDate);
    }
}

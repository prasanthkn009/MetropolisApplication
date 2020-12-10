using Metropolis.Dal.Entities;
using System.Collections.Generic;

namespace Metropolis.Bll
{
    public interface IActivityBll
    {
        void AddToDatabase(Activity newData);
        void Delete(int id);
        List<Activity> GetActivitiesForTheDay();
        void Update(Activity newData, int id);
    }
}

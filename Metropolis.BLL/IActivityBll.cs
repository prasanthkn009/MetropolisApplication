using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.BLL
{
    public interface IActivityBll
    {
        void Add(Activity newdata);
        void Delete(int id);
        List<Activity> GetActivitiesForTheDay();
        void Update(Activity newdata, int id);
    }
}

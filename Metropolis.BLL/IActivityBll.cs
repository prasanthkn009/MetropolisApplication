using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.BLL
{
    /// <summary>
    /// Defines the interface for the ActivityBLL.
    /// </summary>
    public interface IActivityBll
    {
        void Add(Activity newdata);
        void Delete(int id);
        List<Activity> GetActivitiesForTheDay();
        void Update(Activity newdata, int id);
    }
}

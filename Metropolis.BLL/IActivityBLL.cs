using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.BLL
{
    public interface IActivityBLL
    {
        void AddToDatabase(Activity newData);
        void Delete(int Id);
        List<Activity> GetActivitiesForTheDay();
        void Update(Activity newData, int Id);
    }
}
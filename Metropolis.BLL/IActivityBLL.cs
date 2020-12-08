using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.BLL
{
    public interface IActivityBLL
    {
        void AddToDatabase(Activity New_data);
        void Delete(int Id);
        List<Activity> GetActivitiesForTheDay();
        void update(Activity New_data, int Id);
    }
}
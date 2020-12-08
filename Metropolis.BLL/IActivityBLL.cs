using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.BLL
{
    public interface IActivityBLL
    {
        void AddToDatabase(Activity New_data);
        List<Activity> GetActivitiesForTheDay();
    }
}
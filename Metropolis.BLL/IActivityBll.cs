using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.BLL
{
    /// <summary>
    /// Defines the interface for the ActivityBLL.
    /// </summary>
    public interface IActivityBll
    {
<<<<<<< HEAD
        void Add(Activity newdata);
=======
   
        void AddToDatabase(Activity newData);
>>>>>>> 85b0c5b2f9532f44c5bd0fb7e9e066e5e8079720
        void Delete(int id);
        List<Activity> GetActivitiesForTheDay();
        void Update(Activity newdata, int id);
    }
}

using Metropolis.DAL.Entities;
using System.Collections.Generic;

namespace Metropolis.BLL
{
    public interface IAddBLL
    {
        void AddToDatabase(List<Activity> New_data);
    }
}
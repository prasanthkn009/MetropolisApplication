using System.Collections.Generic;
using System.Diagnostics;

namespace Metropolis.BLL
{
    public interface IActivityBLL
    {
        List<Activity> GetActivitiesFotTheDay();
    }
}
using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.BLL.Contracts
{
    public class IActivityBLL
    {
        List<Activity> ActivitiesForTheDay { get; }
    }
}

using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metropolis.DAL
{
    public class ActivityDAL
    {
        private readonly ApplicationDbContext _dbcontext;
       
        public ActivityDAL(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public List<Activity> GetActivities(DateTime fromDate, DateTime toDate)
        {
            return _dbcontext.Activities
            .Where(x => x.ScheduledDate >= fromDate && x.ScheduledDate <= toDate)
            .ToList();
        }

    }
}


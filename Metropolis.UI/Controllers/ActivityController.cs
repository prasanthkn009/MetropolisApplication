using Metropolis.BLL.Contracts;
using Metropolis.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.UI.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityBLL _activityBLL;

        public ActivityController (IActivityBLL activityBLL)
        {
            _activityBLL = activityBLL;

        }
        public IActionResult Index()
        {
            var activities = _activityBLL.GetActivitiesFotTheDay();
            activities.Select(x=> new ActivityViewModel
            {
                scheduledDate = x.ScheduledDate.ToString()
            });
            Console.WriteLine("xx");
            
            return View();

        }
    }
}

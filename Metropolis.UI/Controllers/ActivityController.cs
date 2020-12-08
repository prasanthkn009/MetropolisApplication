using Metropolis.BLL;
using Metropolis.DAL.Entities;
using Metropolis.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityBLL _ActivityBLL;
        public ActivityController(IActivityBLL ActivityBLL)
        {
            _ActivityBLL = ActivityBLL;
        }
        [HttpGet]
        public List<Activity> GetAllProducts()
        {

            return _ActivityBLL.GetActivitiesForTheDay().ToList();
        }

        [HttpPost]

        public void Add(Activity activity)
        {
            _ActivityBLL.AddToDatabase(activity);
        }

        [HttpPost]
        [Route("api/[controller]/{Id}")]
        public void Delete(int Id)
        {
            _ActivityBLL.Delete(Id);
        }

        [HttpPost]
        public void update(Activity activity,int Id)
        {
            _ActivityBLL.update(activity,Id);
        }
    }
}
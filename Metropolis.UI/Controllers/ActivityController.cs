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
    
    public class ActivityController : ControllerBase
    {
        private readonly IActivityBLL _ActivityBLL;
        public ActivityController(IActivityBLL ActivityBLL)
        {
            _ActivityBLL = ActivityBLL;
        }
        [HttpGet]
        [Route("Activities")]
        public List<Activity> GetAllProducts()
        {

            return _ActivityBLL.GetActivitiesForTheDay();
        }

        [Route("Activities")]
        [HttpPost]
        public void Add(Activity activity)
        {
            _ActivityBLL.AddToDatabase(activity);
        }

        [Route("Activities/{id}")]
        [HttpDelete]
        public void Delete(int Id)
        {
            _ActivityBLL.Delete(Id);
        }

        [Route("Activities/{id}")]
        [HttpPut]
        public void update(Activity activity,int Id)
        {
            _ActivityBLL.update(activity,Id);
        }
    }
}

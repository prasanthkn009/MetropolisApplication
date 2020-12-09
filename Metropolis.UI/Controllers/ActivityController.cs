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
        public List<Activity> GetAll()
        {

            return _ActivityBLL.GetActivitiesForTheDay();
        }

        [HttpPost]
        public void Add(Activity activity)
        {
            _ActivityBLL.AddToDatabase(activity);
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _ActivityBLL.Delete(Id);
        }

       
        [HttpPut("{Id}")]
        public void update(Activity activity,int Id)
        {
            _ActivityBLL.update(activity,Id);
        }
    }
}

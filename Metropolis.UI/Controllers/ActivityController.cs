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
<<<<<<< HEAD
        //[Route("Activities")]
=======
        [Route("Activities")]
>>>>>>> 9f7494e8f4e63e1a35f14f100ada3d817e98cb84
        public List<Activity> GetAll()
        {

            return _ActivityBLL.GetActivitiesForTheDay();
        }

        //[Route("Activities")]
        [HttpPost]
        public void Add(Activity activity)
        {
            _ActivityBLL.AddToDatabase(activity);
        }

        //[Route("Activities/{Id}")]
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _ActivityBLL.Delete(Id);
        }

        //[Route("Activities/{Id}")]
        [HttpPut]
        public void update(Activity activity,int Id)
        {
            _ActivityBLL.update(activity,Id);
        }
    }
}

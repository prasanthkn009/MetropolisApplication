using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.UI.Controllers
{
    public class StreetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

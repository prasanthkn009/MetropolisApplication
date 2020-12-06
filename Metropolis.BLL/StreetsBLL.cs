using Metropolis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metropolis.BLL
{
   
    public class StreetsBLL
    {
        public List<Street> GetStreetName()
        {
            List<Street> streetNames = new List<Street>();

            return streetNames.OrderBy(x => x.StreetName).ThenBy(o => o.StreetName).ToList();
        }
    }
}

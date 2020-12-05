using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.DAL.Entities
{
    public class Street
    {
        public int StreetId { get; set; }
        public string StreetName { get; set; }

        public string AlternativeStreet { get; set; }

        public string StreetStatus { get; set; }
    }
}

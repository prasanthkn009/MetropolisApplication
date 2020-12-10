using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolis.UI.Models
{
    public class ActivityViewModel
    {
        public int ActivityId { get; set; }

        public string ActivityName { get; set; }

        public string ActivityType { get; set; }

        public DateTime ScheduledDate { get; set; }

        public string StreetName { get; set; }

        public string AlternativeStreet { get; set; }

        public bool IsClosed { get; set; }

    }
}

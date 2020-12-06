using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Metropolis.DAL.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }

        public string ActivityName { get; set; }

        public string ActivityType { get; set; }
        
        //[ForeignKey("StreetFk")]
        public Street Street { get; set; }
        public int StreetFk{ get; set; }
        

        public DateTime ScheduledDate { get; set; }
    }
}

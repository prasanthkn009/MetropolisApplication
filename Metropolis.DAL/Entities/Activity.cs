using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Metropolis.DAL.Entities
{
    class Activity
    {
        [Key]
        public int activityId { get; set; }

        [Required]
        public string activityName { get; set; }

        [Required]
        public string activityType { get; set; }
    }
}

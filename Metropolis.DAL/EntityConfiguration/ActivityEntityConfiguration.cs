using Metropolis.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.Dal.EntityConfiguration
{
    public class ActivityEntityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(i => i.ActivityId);

            builder.Property(t => t.ActivityName)
                   .IsRequired();

            builder.Property(p => p.ActivityType)
                   .IsRequired();

            builder.Property(x => x.ScheduledDate)
                   .IsRequired();
            
            builder.Property(o => o.StreetName)
                   .IsRequired();
            
            builder.Property(y => y.IsClosed)
                   .IsRequired();
        }     

    }
}

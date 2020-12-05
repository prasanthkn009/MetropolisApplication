using Metropolis.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.DAL.EntityConfiguration
{
    public class StreetEntityConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.HasKey(e => e.StreetId);

            builder.Property(t => t.StreetName)
                   .IsRequired();
        }
    }
}

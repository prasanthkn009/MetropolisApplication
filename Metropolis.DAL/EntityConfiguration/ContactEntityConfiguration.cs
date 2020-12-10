using Metropolis.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.Dal.EntityConfiguration
{
    public class ContactEntityConfiguration : IEntityTypeConfiguration<Contact>

    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(u => u.ContactId);

            builder.Property(i => i.ContactName).IsRequired();

            builder.Property(i => i.ContactEmailId).IsRequired();

            builder.Property(j => j.ContactPhoneNumber).IsRequired();

        }
    }
}


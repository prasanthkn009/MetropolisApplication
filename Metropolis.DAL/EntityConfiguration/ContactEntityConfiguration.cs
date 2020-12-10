using Metropolis.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.DAL.EntityConfiguration
{
    public class ContactEntityConfiguration : IEntityTypeConfiguration<Contact>

    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(i => i.contactId);

            builder.Property(u => u.contactName).IsRequired();


            builder.Property(i => i.contactEmailId).IsRequired();

            builder.Property(j => j.contactPhoneNumber).IsRequired();

        }
    }
}



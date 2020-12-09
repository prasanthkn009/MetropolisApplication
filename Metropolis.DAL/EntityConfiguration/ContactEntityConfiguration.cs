﻿using Metropolis.DAL.Entities;
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
            builder.Property(u => u.ContactName).IsRequired();


            builder.Property(i => i.ContactEmailId).IsRequired();

            builder.Property(j => j.ContactPhoneNumber).IsRequired();

        }
    }
}


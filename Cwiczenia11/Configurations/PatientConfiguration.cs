using Cwiczenia11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient);

            builder.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Birthdate)
                .IsRequired();

            var patients = new List<Patient>();

            patients.Add(new Patient { IdPatient = 201, FirstName = "Adrian", LastName = "Janusz", Birthdate = new DateTime(1990, 12, 12) });
            patients.Add(new Patient { IdPatient = 202, FirstName = "Zygmunt", LastName = "Zygmuntowski", Birthdate = new DateTime(1991, 11, 11) });

            builder.HasData(patients);
        }
    }
}

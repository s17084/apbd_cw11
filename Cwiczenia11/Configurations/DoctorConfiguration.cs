using Cwiczenia11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor);

            builder.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Email)
               .HasMaxLength(100)
               .IsRequired();

            var doctors = new List<Doctor>();

            doctors.Add(new Doctor { IdDoctor = 101, FirstName = "Piotr", LastName = "Kowalski", Email = "p@k.pl" });
            doctors.Add(new Doctor { IdDoctor = 102, FirstName = "Andrzej", LastName = "Andrzejewski", Email = "a@a.pl" });
            doctors.Add(new Doctor { IdDoctor = 103, FirstName = "Wojciech", LastName = "Wojciechowski", Email = "w@w.pl" });
            doctors.Add(new Doctor { IdDoctor = 104, FirstName = "Ziemowit", LastName = "Lato", Email = "z@l.pl" });

            builder.HasData(doctors);
        }
    }
}

using Cwiczenia11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription);

            builder.HasOne(e => e.Doctor)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdDoctor);

            builder.HasOne(e => e.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdPatient);

            builder.Property(e => e.Date)
                .IsRequired();

            builder.Property(e => e.DueDate)
                .IsRequired();

            var prescriptions = new List<Prescription>();

            prescriptions.Add(new Prescription { 
                IdPrescription = 401, 
                IdDoctor = 101, 
                IdPatient = 201, 
                Date = new DateTime(), 
                DueDate = new DateTime(),
            });

            prescriptions.Add(new Prescription
            {
                IdPrescription = 402,
                IdDoctor = 102,
                IdPatient = 202,
                Date = new DateTime(),
                DueDate = new DateTime(),
            });

            builder.HasData(prescriptions);
        }
    }
}

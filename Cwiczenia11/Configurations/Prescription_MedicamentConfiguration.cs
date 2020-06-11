using Cwiczenia11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Configurations
{
    public class Prescription_MedicamentConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
    {
        public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
        {
            builder.HasKey(e => new { e.IdMedicament, e.IdPrescription });

            builder.HasOne(e => e.Medicament)
                .WithMany(e => e.Prescription_Medicaments)
                .HasForeignKey(e => e.IdMedicament);

            builder.HasOne(e => e.Prescription)
                .WithMany(e => e.Prescription_Medicaments)
                .HasForeignKey(e => e.IdPrescription);

            builder.Property(e => e.Details)
                .HasMaxLength(100)
                .IsRequired();

            var prescriptions_medicaments = new List<Prescription_Medicament>();

            prescriptions_medicaments.Add(new Prescription_Medicament { IdMedicament = 301, IdPrescription = 401, Details = "Szczegóły1", Dose = 10 });
            prescriptions_medicaments.Add(new Prescription_Medicament { IdMedicament = 301, IdPrescription = 402, Details = "Szczegóły2", Dose = 30 });
            prescriptions_medicaments.Add(new Prescription_Medicament { IdMedicament = 302, IdPrescription = 402, Details = "Szczegóły3", Dose = 20 });

            builder.HasData(prescriptions_medicaments);
        }
    }
}

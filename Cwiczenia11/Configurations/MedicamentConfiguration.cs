using Cwiczenia11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Configurations
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Type)
                .HasMaxLength(100)
                .IsRequired();

            var medicaments = new List<Medicament>();

            medicaments.Add(new Medicament { IdMedicament = 301, Name = "Apap", Description = "Ból głowy", Type = "Przeciwbólowy" });
            medicaments.Add(new Medicament { IdMedicament = 302, Name = "Rutinoscorbin", Description = "Nic nie daje...", Type = "Odporność" });
            medicaments.Add(new Medicament { IdMedicament = 303, Name = "Fervex", Description = "Na gorączke", Type = "Przeziębienie" });

            builder.HasData(medicaments);
        }
    }
}

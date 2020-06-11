using Cwiczenia11.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public MyDbContext() { }

        public MyDbContext(DbContextOptions options)
        :base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorConfiguration());

            modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());

            modelBuilder.ApplyConfiguration(new PatientConfiguration());

            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());

            modelBuilder.ApplyConfiguration(new Prescription_MedicamentConfiguration());
        }
    }
}

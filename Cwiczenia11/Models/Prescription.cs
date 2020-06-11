using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Models
{
    public class Prescription
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public Doctor Doctor { get; set; }
        public int IdDoctor { get; set; }
        public Patient Patient { get; set; }
        public int IdPatient { get; set; }
        public ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
    }
}

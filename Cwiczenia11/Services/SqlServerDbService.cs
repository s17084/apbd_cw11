using Cwiczenia11.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Services
{
    public class SqlServerDbService : IDbService
    {
        private readonly MyDbContext _context;

        public SqlServerDbService(MyDbContext context) => _context = context;

        public void AddDoctor(AddDoctorRequest req)
        {
            var addedDoctor = _context.Add(new Doctor { FirstName = req.FirstName, LastName = req.LastName, Email = req.Email });
            _context.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if(doctor == null)
            {
                return;
            }
            var prescriptions = _context.Prescriptions.Where(e => e.IdDoctor == id);
            foreach(var prescription in prescriptions)
            {
                doctor.Prescriptions.Remove(prescription);
            }
            _context.Remove(doctor);
            _context.SaveChanges();
        }

        public Doctor GetDoctor(int id)
        {
            var res = _context.Doctors.Where(e => e.IdDoctor == id).Single<Doctor>();
            return res;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public void UpdateDoctor(AddDoctorRequest req, int id)
        {
            var doctor = _context.Doctors.Find(id);
            if(doctor == null)
            {
                return;
            }

            _context.Entry(doctor).CurrentValues.SetValues(req);
            _context.SaveChanges();
        }
    }
}

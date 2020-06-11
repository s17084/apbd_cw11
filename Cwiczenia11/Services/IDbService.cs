using Cwiczenia11.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Services
{
    public interface IDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor GetDoctor(int id);
        public void AddDoctor(AddDoctorRequest req);
        public void UpdateDoctor(AddDoctorRequest req, int id);
        public void DeleteDoctor(int id);
    }
}

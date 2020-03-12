using HospitalService.Data.Interfaces;
using HospitalService.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Repository
{
    public class DoctorRepository : IDoctors
    {
        private readonly EFContext.EFContext _context;
        public DoctorRepository(EFContext.EFContext context)
        {
            _context = context;
        }

        public IEnumerable<DoctorProfile> GetDoctors => _context.DoctorProfiles.ToList();

        public DoctorProfile Doctor(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

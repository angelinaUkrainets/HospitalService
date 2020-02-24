using HospitalService.Data.Interfaces;
using HospitalService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Repository
{
    public class PatientRepository : IPatient
    {
        private readonly EFContext.EFContext _context;
        public PatientRepository(EFContext.EFContext context)
        {
            _context = context;
        }
        public IEnumerable<PatientProfile> GetPatients => _context.PatientProfiles;

        IEnumerable<PatientProfile> IPatient.GetPatients { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PatientProfile Patient(int id)
        {
            throw new NotImplementedException();
        }
    }
}

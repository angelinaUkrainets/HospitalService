using HospitalService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Interfaces
{
    public interface IPatient
    {
        IEnumerable<PatientProfile> GetPatients { get; set; }
        PatientProfile Patient(int id);
    }
}

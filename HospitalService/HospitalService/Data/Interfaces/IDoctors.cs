using HospitalService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Interfaces
{
    public interface IDoctors
    {
        IEnumerable<DoctorProfile> GetDoctors { get; }
        DoctorProfile Doctor(int Id);
    }
}

using HospitalService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.ViewModels
{
    public class DoctorListViewModel
    {
        public IEnumerable<DoctorProfile> GetDoctors { get; set; }
        public string DoctorSpecialization { get; set; }
    }
}

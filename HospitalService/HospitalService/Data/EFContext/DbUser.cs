using HospitalService.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.EFContext
{
    public class DbUser : IdentityUser<string>
    {
        public ICollection<DbUserRole> UserRoles { get; set; }
        public virtual DoctorProfile DocProfile { get; set; }
        public virtual PatientProfile UserProfile { get; set; }
        public virtual AdminProfile Admin { get; set; }
    }
}

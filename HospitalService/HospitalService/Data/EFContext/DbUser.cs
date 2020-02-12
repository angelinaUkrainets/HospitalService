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
        public virtual DoctorProfile UserProfile { get; set; }
    }
}

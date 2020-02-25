using HospitalService.Data.EFContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Models
{
    public class DoctorProfile:BaseProfile
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Image { get; set; }
        [Required] public string Experience { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey("Specializations")]
        public int SpecializationId { get; set; }
        public virtual Specialization Specializations { get; set; }

        [ForeignKey("Hospitals")]
        public int HospitalId { get; set; }
        public virtual Hospital Hospitals { get; set; }

        public virtual DbUser User { get; set; }
    }
}

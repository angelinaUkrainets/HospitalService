using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Models
{
    public class PatientProfile:BaseProfile
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Image { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }
        public string TypeBlood { get; set; }

        [ForeignKey("Sicknesses")]
        public int? SicknessId { get; set; }
        public virtual Sickness Sicknesses { get; set; }

        [ForeignKey("VisitRequests")]
        public int? VisitId { get; set; }
        public virtual VisitRequest VisitRequests { get; set; }
    }
}

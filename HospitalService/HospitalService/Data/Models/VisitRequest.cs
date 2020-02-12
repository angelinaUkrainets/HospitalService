using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Models
{
    public class VisitRequest
    {
        [Key] public int Id { get; set; }
        [Required] public DateTime Time { get; set; }
        
        [ForeignKey("DoctorProfiles")]
        public int DoctorId { get; set; }
        public virtual DoctorProfile DoctorProfiles { get; set; }
    }
}

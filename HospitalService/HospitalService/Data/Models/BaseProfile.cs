using HospitalService.Data.EFContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Models
{
    public class BaseProfile
    {
        [Key, ForeignKey("User")] public string Id { get; set; }
        [Required] public string Login { get; set; }

        public virtual DbUser User { get; set; }
    }
}

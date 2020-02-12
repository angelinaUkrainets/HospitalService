using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Models
{
    public class Hospital
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public virtual Region Regions { get; set; }
    }
}

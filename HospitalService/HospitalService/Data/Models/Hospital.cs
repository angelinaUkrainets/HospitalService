﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Models
{
    public class Hospital
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Regions")]
        public int RegionId { get; set; }
        public virtual Region Regions { get; set; }
    }
}

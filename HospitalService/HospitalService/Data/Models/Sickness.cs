﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Models
{
    public class Sickness
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public DateTime Duration { get; set; }

        [ForeignKey("Symptoms")]
        public int SymptomId { get; set; }
        public virtual Symptom Symptoms { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Models
{
    public class Symptom
    {
        [Key] public int Id { get; set; }
        [Required] public string Desription { get; set; }
    }
}

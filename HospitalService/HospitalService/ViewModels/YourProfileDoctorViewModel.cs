﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.ViewModels
{
    public class YourProfileDoctorViewModel
    {
        [RegularExpression
           (@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$",
       ErrorMessage = "Please enter a valid name")]
        [Required] public string FirstName { get; set; }

        [RegularExpression
            (@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$",
        ErrorMessage = "Please enter a valid name")]
        [Required] public string LastName { get; set; }

        [RegularExpression
            (@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$",
        ErrorMessage = "Please enter a valid email")]
        [EmailAddress, Required] public string Email { get; set; }

        [Required] public string Login { get; set; }


        public string ImageName { get; set; }

        [Required] public string Experience { get; set; }
        [Required] public string SicknessId { get; set; }
    }
}

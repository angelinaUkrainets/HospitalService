using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.ViewModels
{
    public class YourProfileViewModel
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

        [RegularExpression
           (@"^\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*$",
       ErrorMessage = "Please enter a valid time of birth(dd.mm.yyyy)")]
        [Required] public string TimeOfBirth { get; set; }

        [Required, DataType(DataType.Password),
            Display(Name = "Password")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,24}$",
        ErrorMessage = "Please enter a valid password")]
        public string Password { get; set; }

        [Required, Compare("Password", ErrorMessage = "Passwords don`t match"),
             DataType(DataType.Password),
            Display(Name = "Confirm Password")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,24}$",
        ErrorMessage = "Please enter a valid password")]
        public string PasswordConfirm { get; set; }

        public string TypeBlood { get; set; }
    }
}

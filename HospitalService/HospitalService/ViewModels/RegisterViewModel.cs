using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.ViewModels
{
    public class RegisterViewModel
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [EmailAddress, Required] public string Email { get; set; }
        [Required] public string Login { get; set; }
        [Required] public string Image { get; set; }
        [Required] public DateTime TimeOfBirth { get; set; }

        [Required, DataType(DataType.Password),
            Display(Name = "Password")] public string Password { get; set; }

        [Required, Compare("Password", ErrorMessage = "Passwords don`t match"),
             DataType(DataType.Password), 
            Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }
    }
}

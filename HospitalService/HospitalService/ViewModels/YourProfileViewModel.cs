using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.ViewModels
{
    public class YourProfileViewModel
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string TypeBlood { get; set; }
        public string DateBirth { get; set; }
    }
}

using HospitalService.Data.EFContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.Models
{
    public class UserProfile
    {
        [Key, ForeignKey("User")] public string Id { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }

        /// <summary>
        /// Фото користувача
        /// </summary>
        [Required] public string Image { get; set; }

        /// <summary>
        /// Дата реєстрації
        /// </summary>
        public DateTime RegistrationDate { get; set; }
        public virtual DbUser User { get; set; }
    }
}

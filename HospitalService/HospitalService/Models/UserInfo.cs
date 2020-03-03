using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Models
{
    [Serializable]
    public class UserInfo
    {
        public string Id { get; set; }
        public string Email { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University_Core.Models
{
    public class User : IdentityUser
    {
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}

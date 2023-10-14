using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.DataAcces.Model
{
    public class ApiUser : IdentityUser<long>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Region { get; set; }

        public int? Age { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.DataAcces.DTO_s.LoginDto_s
{
    public class LoginDto
    {
        public string UserName { get; set; }

        [StringLength(15, ErrorMessage = "Your password is limited {2} to {1}", MinimumLength = 6)]
        public string Password { get; set; }
    }
}

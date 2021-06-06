using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Authentication
{
    public class Login
    {
        [Required(ErrorMessage ="Email is required") ]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Required")]
        public string Password { get; set; }
    }
}

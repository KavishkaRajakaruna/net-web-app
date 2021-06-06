using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Authentication
{
    public class Register
    {
        [EmailAddress, Required(ErrorMessage ="Email is required") ]
        public string Email { get; set; }
        [Required (ErrorMessage ="password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please define user type")]
        public int UserType { get; set; }  
        
    }
}

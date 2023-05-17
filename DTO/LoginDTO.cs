using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoginDTO
    {
        public string Password { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Email address incorrect")]
        public string Email { get; set; } = null!;
    }
}

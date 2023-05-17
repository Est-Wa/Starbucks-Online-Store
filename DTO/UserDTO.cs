using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class UserDTO {

        public int UserId { get; set; }

        [StringLength(20, ErrorMessage ="name too long")]
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [EmailAddress(ErrorMessage = "Email address incorrect")]
        public string? Email { get; set; }

    }
}

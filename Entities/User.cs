using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(20,ErrorMessage ="String length must be between 5-20", MinimumLength = 5)]
        public string UserName { get; set; }

        [StringLength(20, ErrorMessage = "String length must be between 6-20", MinimumLength = 5)]
        public string Password { get; set; }

        [StringLength(20, ErrorMessage = "String length must be between 2-20", MinimumLength = 2)]
        public string? FirstName { get; set; }


        [StringLength(20, ErrorMessage = "String length must be between 2-20", MinimumLength = 2)]
        public string? LastName { get; set; }
    }
}

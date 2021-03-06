using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewModels.Account
{
    public class RegisterVM
    {
        [Required, StringLength(maximumLength: 100)]
        public string FirstName { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required, DataType("nvarchar(50)")]
        public string Username { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password mustn't be empty"), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string SecurityCode { get; set; }
    }
}

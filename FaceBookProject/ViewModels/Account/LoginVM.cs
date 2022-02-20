using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewModels.Account
{
    public class LoginVM
    {
        [Required, StringLength(maximumLength: 100)]
        public string Username { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

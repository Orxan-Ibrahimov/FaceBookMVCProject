using FaceBookProject.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class AppUser:IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        //public string Profile { get; set; }
        //[NotMapped]
        //public IFormFile ProfilePhoto { get; set; }
        public List<UserFriend> UserFriends { get; set; }
        public List<UserSuggest> UserSuggests { get; set; }
        public List<UserMessage> UserMessages { get; set; }

    }
}

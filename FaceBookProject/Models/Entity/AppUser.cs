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
        public string FirstName { get; set; }
        public string Profile { get; set; }
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }
        public string Cover { get; set; }
        [NotMapped]
        public IFormFile CoverPhoto { get; set; }
        [Required]
        public string LastName { get; set; }     
        [Required]
        public DateTime Birthday { get; set; }
        public ICollection<Friendship> Friends { get; set; }
        public List<Suggest> Suggests { get; set; }
        public List<Message> Messages { get; set; }
        public List<Album> Albums { get; set; }
        public List<UserHobby> UserHobbies { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Story> Stories { get; set; }
        public List<Like> Likes { get; set; }
    }
}

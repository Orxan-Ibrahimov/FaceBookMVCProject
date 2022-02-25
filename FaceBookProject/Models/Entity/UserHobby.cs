using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class UserHobby : BaseEntity
    {
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public Hobby Hobby { get; set; }
        public string HobbyId { get; set; }
    }
}

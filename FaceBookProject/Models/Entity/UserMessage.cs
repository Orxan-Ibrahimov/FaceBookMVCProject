
using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class UserMessage : BaseEntity
    {
        public bool UserSented { get; set; }
        public AppUser User { get; set; }
        public int? UserId { get; set; }
        public Message Message { get; set; }
        public int? MessageId { get; set; }
    }
}

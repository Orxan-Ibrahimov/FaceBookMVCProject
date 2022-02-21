using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class Friendship : BaseEntity
    {        
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public AppUser Friend { get; set; }
        public string FriendId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

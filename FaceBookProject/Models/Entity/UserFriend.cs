using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class UserFriend : BaseEntity
    {
        public AppUser User { get; set; }
        public int? UserId { get; set; }
        public Friend Friend { get; set; }
        public int? FriendId { get; set; }
    }
}

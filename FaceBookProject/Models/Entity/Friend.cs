using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class Friend : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public List<UserFriend> UserFriends { get; set; }

    }
}

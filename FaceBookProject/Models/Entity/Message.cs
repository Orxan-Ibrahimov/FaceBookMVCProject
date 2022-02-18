
using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class Message : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<UserMessage> UserMessages { get; set; }

    }
}

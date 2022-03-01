using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class Like : BaseEntity
    {
        public string Name { get; set; }
        public int? StoryId { get; set; }
        public Story Story { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}

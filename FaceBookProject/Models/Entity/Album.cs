using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class Album : BaseEntity
    {
        public string Name { get; set; }
        public List<Image> Images { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
    }
}

using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class UserSuggest : BaseEntity
    {
        public AppUser User { get; set; }
        public int? UserId { get; set; }
        public Suggest Suggest { get; set; }
        public int? SuggestId { get; set; }
    }
}

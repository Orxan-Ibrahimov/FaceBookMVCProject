using FaceBookProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewModels
{
    public class ProfileVM
    {
        public AppUser SearchedUser { get; set; }
        public AppUser User { get; set; }
        public Image Image { get; set; }
        public List<AppUser> MutualFriends { get; set; }
    }
}

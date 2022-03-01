using FaceBookProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewModels
{
    public class HomeVM
    {
        public List<AppUser> AllUsers { get; set; }
        public AppUser User { get; set; }
        public Story Story { get; set; }
    }
}

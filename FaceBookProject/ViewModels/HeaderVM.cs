using FaceBookProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewModels
{
    public class HeaderVM
    {
        public AppUser User { get; set; }
        public string search { get; set; }
    }
}

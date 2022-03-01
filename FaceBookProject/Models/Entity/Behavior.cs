using FaceBookProject.Helpers.Enums;
using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class Behavior : BaseEntity
    {
        public string Icon { get; set; }
        public string Text { get; set; }
        public EmotionType EmotionType { get; set; }
        public List<Story> Stories { get; set; }
    }
}

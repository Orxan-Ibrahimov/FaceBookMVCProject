using FaceBookProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewModels
{
    public class EmotionVM
    {
        public List<Behavior> Behaviors { get; set; }
        public Behavior Behavior { get; set; }
    }
}

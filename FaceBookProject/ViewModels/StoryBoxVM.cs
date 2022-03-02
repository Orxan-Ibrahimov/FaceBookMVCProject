﻿using FaceBookProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewModels
{
    public class StoryBoxVM
    {
        public Story Story { get; set; }
        public AppUser User { get; set; }
        public Behavior Behavior { get; set; }
        public int? ShareCount { get; set; }
        //public Story Story { get; set; }
        //public Story Story { get; set; }
    }
}

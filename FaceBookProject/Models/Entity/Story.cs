using FaceBookProject.Models.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class Story : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public string Header { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public Behavior Emotion { get; set; }
        public int? EmotionId { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        public int ShareCount { get; set; }
        public Story Share { get; set; }
        public int? ShareId { get; set; }
    }
}

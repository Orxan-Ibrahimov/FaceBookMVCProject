using FaceBookProject.Models.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class Image : BaseEntity
    {
        [Required]
        public string Picture { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public Album Album { get; set; }
        public int? AlbumId { get; set; }       
    }
}

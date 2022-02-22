using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class Suggest : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public AppUser Sender { get; set; }
        public string SenderId { get; set; }
        public AppUser Acceptor { get; set; }
        public string AcceptorId { get; set; }
    }
}

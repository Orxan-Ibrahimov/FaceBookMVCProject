using FaceBookProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewModels
{
    public class ChatViewModel
    {
        public AppUser Sender { get; set; }
        public AppUser Acceptor { get; set; }
        public List<Message> Messages { get; set; }
        public Message Message { get; set; }
    }
}

using FaceBookProject.DAL;
using FaceBookProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewComponents
{
    public class ChatViewComponent : ViewComponent
    {
        private readonly FacebookDbContext _context;
        public ChatViewComponent(FacebookDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ChatViewModel chat = new ChatViewModel();
          

            return View(await Task.FromResult(chat));
        }
    }
}

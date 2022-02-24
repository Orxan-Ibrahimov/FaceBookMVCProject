using FaceBookProject.DAL;
using FaceBookProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly FacebookDbContext _context;
        public HeaderViewComponent(FacebookDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HeaderVM header = new HeaderVM
            {
                User = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name)
            };

            if (header.User == null)
                return View();

            return View(await Task.FromResult(header));
        }
    }
}

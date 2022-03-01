using FaceBookProject.DAL;
using FaceBookProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewComponents
{
    public class StoryViewComponent : ViewComponent
    {
        private readonly FacebookDbContext _context;
        public StoryViewComponent(FacebookDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            StoryBoxVM story = new StoryBoxVM {
                User = _context.Users.FirstOrDefault(u=>u.UserName == User.Identity.Name)
            };

            if (story.User == null)
                return View();

            return View(await Task.FromResult(story));
        }
    }
}

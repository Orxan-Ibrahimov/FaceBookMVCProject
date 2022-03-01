using FaceBookProject.DAL;
using FaceBookProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.ViewComponents
{
    public class BehaviorViewComponent : ViewComponent
    {
        private readonly FacebookDbContext _context;
        public BehaviorViewComponent(FacebookDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            EmotionVM emotion = new EmotionVM
            {
                Behaviors = _context.Behaviors.ToList()
            };

            if (emotion.Behaviors == null)
                return View();

            return View(await Task.FromResult(emotion));
        }
    }
}

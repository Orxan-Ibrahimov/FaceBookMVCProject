
using FaceBookProject.DAL;
using FaceBookProject.Models.Entity;
using FaceBookProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Controllers
{
    public class ProfileController : Controller
    {
        private FacebookDbContext _db;
        public ProfileController(FacebookDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string id)
        {
            if (id == null)
                return NotFound();

            ProfileVM profile = new ProfileVM
            {
                SearchedUser = _db.Users.Include(u=>u.Friends).ThenInclude(f=>f.Friend).Include(u=>u.Suggests).ThenInclude(s => s.Sender).
                Include(u => u.Albums).ThenInclude(a => a.Images).FirstOrDefault(u=>u.Id == id),
                User = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).ThenInclude(s => s.Sender).
                Include(u => u.Albums).ThenInclude(a => a.Images).FirstOrDefault(u => u.UserName == User.Identity.Name),
                MutualFriends = new List<AppUser>()
            };           
                 
            if (profile.SearchedUser == null)
                return NotFound();

            foreach (var friendship in profile.SearchedUser.Friends)
            {
                if (profile.User.Friends.FirstOrDefault(f => f.Friend.Id == friendship.Friend.Id) != null)
                    profile.MutualFriends.Add(friendship.Friend);
            }

            return View(profile);
        }

        public IActionResult EditProfileImage(string id,ProfileVM profile)
        {
           

            return View();
        }
    }
}

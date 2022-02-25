
using FaceBookProject.DAL;
using FaceBookProject.Models.Entity;
using FaceBookProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Controllers
{
    public class ProfileController : Controller
    {
        private FacebookDbContext _db;
        private IWebHostEnvironment _env;
        public ProfileController(FacebookDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index(string id)
        {
            if (id == null)
                return NotFound();

            ProfileVM profile = new ProfileVM
            {
                SearchedUser = _db.Users.Include(u=>u.Friends).ThenInclude(s => s.Friend).ThenInclude(f=>f.Friends).Include(u=>u.Suggests).ThenInclude(s => s.Sender).
                FirstOrDefault(u=>u.Id == id),
                User = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).ThenInclude(s => s.Sender).
                FirstOrDefault(u => u.UserName == User.Identity.Name),
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
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditProfileImage(string id,ProfileVM profile)
        {
            if (id == null)
                return View();

            ProfileVM profileVM = new ProfileVM
            {
                SearchedUser = _db.Users.Include(u => u.Friends).ThenInclude(s => s.Friend).ThenInclude(f => f.Friends).Include(u => u.Suggests).ThenInclude(s => s.Sender).
               FirstOrDefault(u => u.Id == id),
                User = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).ThenInclude(s => s.Sender).
               FirstOrDefault(u => u.UserName == User.Identity.Name),
                MutualFriends = new List<AppUser>()
            };

            if (profile.SearchedUser == null)
                return NotFound();

            foreach (var friendship in profileVM.SearchedUser.Friends)
            {
                if (profileVM.User.Friends.FirstOrDefault(f => f.Friend.Id == friendship.Friend.Id) != null)
                    profileVM.MutualFriends.Add(friendship.Friend);
            }

            if (ModelState["SearchedUser.ProfilePhoto"].ValidationState == ModelValidationState.Invalid)
                return View(profile);
            string filename = RenderImage(profile.SearchedUser.ProfilePhoto);
           

            profileVM.SearchedUser.Profile = filename;
            _db.SaveChanges();

            return View(nameof(Index), profileVM);

        }

        public IActionResult EditCoverImage(string id, ProfileVM profile)
        {
            if (id == null)
                return View();

            ProfileVM profileVM = new ProfileVM
            {
                SearchedUser = _db.Users.Include(u => u.Friends).ThenInclude(s => s.Friend).ThenInclude(f => f.Friends).Include(u => u.Suggests).ThenInclude(s => s.Sender).
               FirstOrDefault(u => u.Id == id),
                User = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).ThenInclude(s => s.Sender).
               FirstOrDefault(u => u.UserName == User.Identity.Name),
                MutualFriends = new List<AppUser>()
            };

            if (profile.SearchedUser == null)
                return NotFound();

            foreach (var friendship in profileVM.SearchedUser.Friends)
            {
                if (profileVM.User.Friends.FirstOrDefault(f => f.Friend.Id == friendship.Friend.Id) != null)
                    profileVM.MutualFriends.Add(friendship.Friend);
            }

            if (ModelState["SearchedUser.CoverPhoto"].ValidationState == ModelValidationState.Invalid)
                return View(profile);
            string filename = RenderImage(profile.SearchedUser.CoverPhoto);


            profileVM.SearchedUser.Cover = filename;
            _db.SaveChanges();

            return View(nameof(Index), profileVM);

        }
        public string RenderImage(IFormFile photo)
        {
            if (!photo.ContentType.Contains("image"))
            {
                return null;
            }
            if (photo.Length / 1024 > 10000)
            {
                return null;
            }

            string filename = Guid.NewGuid().ToString() + '-' + photo.FileName;
            string environment = _env.WebRootPath;
            string newSlider = Path.Combine(environment, "assets", "img");


            if (!Directory.Exists(newSlider))
            {
                Directory.CreateDirectory(newSlider);
            }
            newSlider = Path.Combine(newSlider, filename);

            using (FileStream file = new FileStream(newSlider, FileMode.Create))
            {
                photo.CopyTo(file);
            }

            return filename;
        }
    }
}

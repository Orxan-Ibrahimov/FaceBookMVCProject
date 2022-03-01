
using FaceBookProject.DAL;
using FaceBookProject.Helpers.Methods;
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
                SearchedUser = _db.Users.Include(u => u.Friends).ThenInclude(s => s.Friend).ThenInclude(f => f.Friends).Include(u => u.Suggests).ThenInclude(s => s.Sender).
                FirstOrDefault(u => u.Id == id),
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
        public IActionResult EditProfileImage(string id, ProfileVM profile)
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
            Methods method = new Methods(_env);
            string filename = method.RenderImage(profile.SearchedUser.ProfilePhoto);


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
            Methods method = new Methods(_env);
            string filename = method.RenderImage(profile.SearchedUser.CoverPhoto);


            profileVM.SearchedUser.Cover = filename;
            _db.SaveChanges();

            return View(nameof(Index), profileVM);

        }
        public IActionResult ProfileAbout(string id)
        {
            if (id == null)
                return NotFound();

            ProfileVM profile = new ProfileVM
            {
                SearchedUser = _db.Users.Include(u => u.Friends).ThenInclude(s => s.Friend).ThenInclude(f => f.Friends).Include(u => u.Suggests).ThenInclude(s => s.Sender).
                FirstOrDefault(u => u.Id == id),
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

            return View("_ProfileAbout", profile);
        }
        public IActionResult MutualFriends(string id)
        {
            if (id == null)
                return NotFound();

            ProfileVM profile = new ProfileVM
            {
                SearchedUser = _db.Users.Include(u => u.Friends).ThenInclude(s => s.Friend).ThenInclude(f => f.Friends).Include(u => u.Suggests).ThenInclude(s => s.Sender).
                FirstOrDefault(u => u.Id == id),
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

            return View("_MutualFriends", profile);
        }

    }
}

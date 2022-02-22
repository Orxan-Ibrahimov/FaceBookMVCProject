using FaceBookProject.DAL;
using FaceBookProject.Models.Entity;
using FaceBookProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly FacebookDbContext _db;

        public HomeController(FacebookDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            AppUser user = _db.Users.Include(u=>u.Friends).ThenInclude(f=>f.Friend).Include(u=>u.Suggests).ThenInclude(s=>s.Sender).FirstOrDefault(u=>u.UserName == User.Identity.Name);

            if (user == null)
                return NotFound();

            HomeVM home = new HomeVM
            {
                User = user
            };

            return View(home);
        }

        public IActionResult SearchUser(string search)
        {
            if (string.IsNullOrEmpty(search))
                return View();

            List<AppUser> users = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u=>u.Suggests).ThenInclude(s => s.Sender).Where(u => u.UserName.Contains(search)).ToList();
            AppUser user = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (users == null || user == null)
                return NotFound();

            HomeVM home = new HomeVM
            {
                AllUsers = users,
                User = user
            };

            return View(home);
        }

        public IActionResult SendSuggest(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View();

            AppUser acceptor = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u=>u.Suggests).FirstOrDefault(u => u.Id == id);
            AppUser sender = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (acceptor == null || sender == null)
                return NotFound();

            Suggest suggest = new Suggest
            {
                Sender = sender,
                Acceptor = acceptor                
            };

            _db.Suggests.Add(suggest);
            _db.SaveChanges();

            HomeVM home = new HomeVM
            {
                User = acceptor
            };

            return View("_SendSuggest", home);
        }

        public IActionResult AcceptSuggest(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View();

            AppUser sender = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).FirstOrDefault(u => u.Id == id);
            AppUser acceptor = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (acceptor == null || sender == null)
                return NotFound();

            Suggest suggest = _db.Suggests.Include(s => s.Sender).Include(s => s.Acceptor).FirstOrDefault(s=>s.AcceptorId == acceptor.Id && s.SenderId == sender.Id);

            if (suggest == null)
                return NotFound();

            Friendship friend1 = new Friendship
            {
                User = sender,
                Friend = acceptor
            };
            Friendship friend2 = new Friendship
            {
                User = acceptor,
                Friend = sender
            };

            _db.Friends.Add(friend1);
            _db.Friends.Add(friend2);
            _db.Suggests.Remove(suggest);
            _db.SaveChanges();

            HomeVM home = new HomeVM
            {
                User = acceptor
            };

            return View("_AcceptSuggest", home);
        }
    }
}

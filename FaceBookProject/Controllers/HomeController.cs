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
            AppUser user = _db.Users.Include(u=>u.Friends).ThenInclude(f=>f.Friend).FirstOrDefault(u=>u.UserName == User.Identity.Name);

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

            List<AppUser> users = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Where(u => u.UserName.Contains(search)).ToList();

            if (users == null)
                return NotFound();

            HomeVM home = new HomeVM
            {
                AllUsers = users
            };

            return View(home);
        }

    }
}

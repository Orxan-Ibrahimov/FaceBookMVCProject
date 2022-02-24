using FaceBookProject.DAL;
using FaceBookProject.Helpers.Methods;
using FaceBookProject.Models.Entity;
using FaceBookProject.ViewModels.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FaceBookProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private FacebookDbContext _db;
        public AccountController(FacebookDbContext db, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
        }
        // GET: AccountController
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
                return View(register);

            Random rand = new Random();
            register.SecurityCode = rand.Next(99999, 1000000).ToString();
            string userData = JsonSerializer.Serialize(register);
            HttpContext.Response.Cookies.Append("user",userData);

            string message = "Security code for registration";
            MailOperations.SendMessage(register.Email,message,register.SecurityCode);           

            return View("CompleteRegister");
        }

        public ActionResult CompleteRegister()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> CompleteRegister(SecurityVM security)
        {
            if (!ModelState.IsValid)
                return View(security);

           RegisterVM registerVM = JsonSerializer.Deserialize<RegisterVM>(HttpContext.Request.Cookies["user"]);

            if (registerVM == null)
                return NotFound();

            if (registerVM.SecurityCode != security.Code)
                return BadRequest();

            HttpContext.Response.Cookies.Delete("user");

            AppUser user = new AppUser()
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Birthday = registerVM.Birthday,
                UserName = registerVM.Username,
                Email = registerVM.Email,
                Profile = "default.jpg",                
            };

            //user.Albums = new List<Album> {
            //    new Album{
            //    Name = "Profile",
            //    UserId = user.Id,
            //    Images = new List<Image>
            //    {
            //        new Image
            //        {
            //            Picture = "default.jpg",
            //        }
            //    }
            //    },
            //    new Album{
            //    Name = "Cover",
            //    UserId = user.Id
            //    }
            //};

            IdentityResult result = await _userManager.CreateAsync(user,registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);
            }      
            return View(nameof(Login));
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var user = await _userManager.FindByNameAsync(login.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Username or Password is not correct");
                return View(login);
            }

            var result =  await _signInManager.PasswordSignInAsync(user,login.Password,false,false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is not correct");
                return View(login);
            }
            return RedirectToAction("Index","Home");
        }

        public async Task<ActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }

    }
}

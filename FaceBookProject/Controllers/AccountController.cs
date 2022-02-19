using FaceBookProject.DAL;
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
            //MailOperation

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
                FullName = registerVM.FullName,
                UserName = registerVM.Username,
                Email = registerVM.Email
            };

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

    }
}

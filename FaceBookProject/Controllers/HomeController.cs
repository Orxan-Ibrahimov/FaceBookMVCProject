using FaceBookProject.DAL;
using FaceBookProject.Helpers.Methods;
using FaceBookProject.Models.Entity;
using FaceBookProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly FacebookDbContext _db;
        private readonly IWebHostEnvironment _env;

        public HomeController(FacebookDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Index()
        {
            AppUser user = _db.Users.Include(u=>u.Friends).ThenInclude(f=>f.Friend).Include(u=>u.Stories).ThenInclude(s=>s.Emotion).Include(u=>u.Suggests).ThenInclude(s=>s.Sender).
              FirstOrDefault(u=>u.UserName == User.Identity.Name);

            if (user == null)
                return NotFound();

            HomeVM home = new HomeVM
            {
                User = user                
            };

            return View(home);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult SendStory(StoryBoxVM storyBoxVM)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser user = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u=>u.Stories).Include(u => u.Suggests).ThenInclude(s => s.Sender).
              FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null)
                return NotFound();

            if (storyBoxVM.Behavior != null)
                storyBoxVM.Story.EmotionId = storyBoxVM.Behavior.Id;

            if (ModelState["Story.Photo"].ValidationState == ModelValidationState.Invalid)
                return View(storyBoxVM);

            Methods method = new Methods(_env);
            storyBoxVM.Story.Image = method.RenderImage(storyBoxVM.Story.Photo);
            storyBoxVM.Story.UserId = user.Id;


            StoryBoxVM storyBox = new StoryBoxVM
            {
                User = user,
                Story = storyBoxVM.Story
            };

            
            _db.Stories.Add(storyBox.Story);
            _db.SaveChanges();

            return RedirectToAction("Index");
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
                User = sender
            };

            return View("_AcceptSuggest", home);
        }

        public IActionResult RegretSuggest(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View();

            AppUser sender = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).FirstOrDefault(u => u.Id == id);
            AppUser acceptor = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (acceptor == null || sender == null)
                return NotFound();

            Suggest suggest = _db.Suggests.Include(s => s.Sender).Include(s => s.Acceptor).FirstOrDefault(s => s.AcceptorId == acceptor.Id && s.SenderId == sender.Id);

            if (suggest == null)
                return NotFound();         

           
            _db.Suggests.Remove(suggest);
            _db.SaveChanges();

            HomeVM home = new HomeVM
            {
                User = acceptor
            };

            return View("_RegretSuggest", home);
        }

        public IActionResult OpenFriendWindow(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View();

            AppUser acceptor = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).Include(u=>u.Messages).FirstOrDefault(u => u.Id == id);
            AppUser sender = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).Include(u => u.Messages).FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (acceptor == null || sender == null)
                return NotFound();

            List<Message> messages = _db.Messages.OrderBy(m=>m.CreatedDate).ToList();            

            ChatViewModel chat = new ChatViewModel
            {
                Acceptor = acceptor,
                Sender = sender,
                Messages = messages
            };         

          

            return View("_OpenFriendWindow", chat);
        }
        
        public IActionResult SendMessage(string id,string message)
        {
            if (string.IsNullOrEmpty(id))
                return View();

            AppUser acceptor = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).Include(u => u.Messages).FirstOrDefault(u => u.Id == id);
            AppUser sender = _db.Users.Include(u => u.Friends).ThenInclude(f => f.Friend).Include(u => u.Suggests).Include(u => u.Messages).FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (acceptor == null || sender == null)
                return NotFound();

            Message newMessage = new Message
            {
                AcceptorId = acceptor.Id,
                SenderId = sender.Id,
                Text = message
            };

            _db.Messages.Add(newMessage);
            _db.SaveChanges();

            ChatViewModel chat = new ChatViewModel
            {
                Acceptor = acceptor,
                Sender = sender,
                Message = newMessage
            };

            return View("_SendMessage", chat);
        }
        //public string RenderImage(IFormFile photo)
        //{
        //    if (!photo.ContentType.Contains("image"))
        //    {
        //        return null;
        //    }
        //    if (photo.Length / 1024 > 10000)
        //    {
        //        return null;
        //    }

        //    string filename = Guid.NewGuid().ToString() + '-' + photo.FileName;
        //    string environment = _env.WebRootPath;
        //    string newSlider = Path.Combine(environment, "assets", "img");


        //    if (!Directory.Exists(newSlider))
        //    {
        //        Directory.CreateDirectory(newSlider);
        //    }
        //    newSlider = Path.Combine(newSlider, filename);

        //    using (FileStream file = new FileStream(newSlider, FileMode.Create))
        //    {
        //        photo.CopyTo(file);
        //    }

        //    return filename;
        //}

        public IActionResult AddEmotion(int? id)
        {
            if (id == null)
                return View();

            Behavior emotion = _db.Behaviors.FirstOrDefault(b => b.Id == id);

            if (emotion == null)
                return NotFound();

            StoryBoxVM emotionVM = new StoryBoxVM
            {
                Behavior = emotion
            };

            return View("_AddEmotion", emotionVM);
        }

        public IActionResult SearchEmotion(string search)
        {
            EmotionVM emotionVM = new EmotionVM
            {
                Behaviors = _db.Behaviors.ToList()
        };
            if (search != null)
                emotionVM.Behaviors = emotionVM.Behaviors.Where(b => b.Text.Contains(search)).ToList();

            return View("_SearchEmotion", emotionVM);
        }
    }
}
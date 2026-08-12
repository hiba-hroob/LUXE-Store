using Microsoft.AspNetCore.Mvc;
using Webproject.Data;
using Webproject.Models;

namespace Webproject.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

       

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var isAdmin = HttpContext.Session.GetString("IsAdmin");



            if (isAdmin == "true")
            {
                var messages = _context.Messages
                    .Where(m => !m.IsFromAdmin)
                    .OrderByDescending(m => m.CreatedAt)
                    .ToList();

                foreach (var message in messages)
                {
                    message.IsRead = true;
                }

                _context.SaveChanges();

                return View(messages);
            }

            var userMessages = _context.Messages
    .Where(m => m.UserId == userId.Value && m.IsFromAdmin)
    .OrderByDescending(m => m.CreatedAt)
    .ToList();

            foreach (var message in userMessages.Where(m => m.IsFromAdmin))
            {
                message.IsRead = true;
            }

            _context.SaveChanges();

            return View(userMessages);
        }



        [HttpGet]
        public IActionResult Send(int? userId)
        {
            var isAdmin = HttpContext.Session.GetString("IsAdmin");

            if (isAdmin != "true")
            {
                return RedirectToAction("Index");
            }

            ViewBag.Users = _context.Users.ToList();

            ViewBag.SelectedUserId = userId;

            return View();
        }



        [HttpPost]
        public IActionResult Send(int userId, string content)
        {
            var isAdmin = HttpContext.Session.GetString("IsAdmin");

            if (isAdmin != "true")
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                ViewBag.Users = _context.Users.ToList();
                ViewBag.Error = "Please write a message.";

                return View();
            }

            var message = new Message
            {
                UserId = userId,
                Content = content,
                CreatedAt = DateTime.Now,
                IsRead = false,

             
                IsFromAdmin = true
            };

            _context.Messages.Add(message);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


      

        [HttpGet]
        public IActionResult ContactAdmin()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var isAdmin = HttpContext.Session.GetString("IsAdmin");

            
            if (isAdmin == "true")
            {
                return RedirectToAction("Index");
            }

            return View();
        }


      

        [HttpPost]
        public IActionResult ContactAdmin(string content)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var isAdmin = HttpContext.Session.GetString("IsAdmin");

            if (isAdmin == "true")
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                ViewBag.Error = "Please write your message.";
                return View();
            }

            var message = new Message
            {
                UserId = userId.Value,

                Content = content,

                CreatedAt = DateTime.Now,

                IsRead = false,

              
                IsFromAdmin = false
            };

            _context.Messages.Add(message);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public int GetUnreadMessagesCount()
        {
            var isAdmin = HttpContext.Session.GetString("IsAdmin");

            if (isAdmin == "true")
            {
                return _context.Messages
                    .Count(m => !m.IsFromAdmin && !m.IsRead);
            }

            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return 0;

            return _context.Messages
                .Count(m => m.UserId == userId.Value
                         && m.IsFromAdmin
                         && !m.IsRead);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";

            var message = _context.Messages.FirstOrDefault(m => m.Id == id);

            if (message == null)
            {
                return RedirectToAction("Index");
            }

          
            if (isAdmin)
            {
                _context.Messages.Remove(message);
            }
            else
            {
             
                if (message.UserId != userId.Value)
                {
                    return RedirectToAction("Index");
                }

                _context.Messages.Remove(message);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Reply(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var message = _context.Messages.FirstOrDefault(m => m.Id == id);

            if (message == null)
            {
                return NotFound();
            }

            ViewBag.MessageId = message.Id;
            ViewBag.UserId = message.UserId;
            ViewBag.OriginalMessage = message.Content;

            return View();
        }

        [HttpPost]
        public IActionResult Reply(int id, string content)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                ViewBag.MessageId = id;
                ViewBag.Error = "Please write your reply.";
                return View();
            }

            var originalMessage = _context.Messages
                .FirstOrDefault(m => m.Id == id);

            if (originalMessage == null)
            {
                return NotFound();
            }

            var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";

            var reply = new Message
            {
                UserId = isAdmin ? originalMessage.UserId : userId.Value,
                Content = content,
                CreatedAt = DateTime.Now,
                IsRead = false,
                IsFromAdmin = isAdmin
            };

            _context.Messages.Add(reply);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
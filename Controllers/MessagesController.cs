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

            var messages = _context.Messages
                .Where(m => m.UserId == userId.Value)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            foreach (var message in messages)
            {
                message.IsRead = true;
            }

            _context.SaveChanges();

            return View(messages);
        }

        [HttpGet]
        public IActionResult Send()
        {
            var isAdmin = HttpContext.Session.GetString("IsAdmin");

            if (isAdmin != "true")
            {
                return RedirectToAction("Index");
            }

            ViewBag.Users = _context.Users.ToList();

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
                IsRead = false
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            return RedirectToAction("Send");
        }
    }
}
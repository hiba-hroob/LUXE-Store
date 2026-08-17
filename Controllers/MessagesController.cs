using Microsoft.AspNetCore.Mvc;
using Webproject.Data;
using Webproject.Models;
using Microsoft.EntityFrameworkCore;

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

            var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";

            var query = _context.Messages
                .Include(m => m.User)
                .AsQueryable();

            if (isAdmin)
            {
             
                query = query.Where(m => m.IsFromAdmin == false);
            }
            else
            {
             
                query = query.Where(m =>
                    m.UserId == userId.Value &&
                    m.IsFromAdmin == true);
            }

            var messages = query
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
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";

         
            if (isAdmin)
            {
                ViewBag.Users = _context.Users
                    .Where(u => u.Email != "hiba@gmail.com")
                    .ToList();
            }

            return View();
        }


        [HttpPost]
        public IActionResult Send(int? userId, string content)
        {
            var currentUserId = HttpContext.Session.GetInt32("UserId");

            if (currentUserId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";

            if (string.IsNullOrWhiteSpace(content))
            {
                ViewBag.Error = "Please write a message.";

                if (isAdmin)
                {
                    ViewBag.Users = _context.Users
                        .Where(u => u.Email != "hiba@gmail.com")
                        .ToList();
                }

                return View();
            }

            Message message;

            if (isAdmin)
            {
               
                if (userId == null)
                {
                    ViewBag.Error = "Please select a user.";

                    ViewBag.Users = _context.Users
                        .Where(u => u.Email != "hiba@gmail.com")
                        .ToList();

                    return View();
                }

                message = new Message
                {
                    UserId = userId.Value,
                    Content = content,
                    CreatedAt = DateTime.Now,
                    IsRead = false,
                    IsFromAdmin = true
                };
            }
            else
            {
                message = new Message
                {
                    UserId = currentUserId.Value,
                    Content = content,
                    CreatedAt = DateTime.Now,
                    IsRead = false,
                    IsFromAdmin = false
                };
            }

            _context.Messages.Add(message);
            _context.SaveChanges();

            return RedirectToAction("Index");
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

            var message = _context.Messages.Find(id);

            if (message == null)
            {
                return NotFound();
            }

            if (isAdmin)
            {
                if (message.IsFromAdmin)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
             
                if (message.UserId != userId.Value || !message.IsFromAdmin)
                {
                    return RedirectToAction("Index");
                }
            }

            _context.Messages.Remove(message);
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

            var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";

            var message = _context.Messages.Find(id);

            if (message == null)
            {
                return NotFound();
            }

         
            if (!isAdmin)
            {
                if (message.UserId != userId.Value || !message.IsFromAdmin)
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MessageId = id;

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

            var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";

            var originalMessage = _context.Messages.Find(id);

            if (originalMessage == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                ViewBag.MessageId = id;
                ViewBag.Error = "Please write a reply.";
                return View();
            }

      
            if (!isAdmin)
            {
                if (originalMessage.UserId != userId.Value ||
                    !originalMessage.IsFromAdmin)
                {
                    return RedirectToAction("Index");
                }
            }

            Message reply;

            if (isAdmin)
            {
           
                reply = new Message
                {
                    UserId = originalMessage.UserId,
                    Content = content,
                    CreatedAt = DateTime.Now,
                    IsRead = false,
                    IsFromAdmin = true
                };
            }
            else
            {
           
                var admin = _context.Users
                    .FirstOrDefault(u => u.Email == "hiba@gmail.com");

                if (admin == null)
                {
                    return NotFound("Admin account not found.");
                }

                reply = new Message
                {
                    UserId = admin.Id,
                    Content = content,
                    CreatedAt = DateTime.Now,
                    IsRead = false,
                    IsFromAdmin = false
                };
            }

            _context.Messages.Add(reply);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
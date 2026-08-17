using Microsoft.AspNetCore.Mvc;
using Webproject.Data;
using Microsoft.EntityFrameworkCore;

namespace Webproject.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController(ApplicationDbContext context)
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


            var notifications = _context.Notifications
                .Where(n => n.UserId == userId.Value)
                .OrderByDescending(n => n.CreatedAt)
                .ToList();


       
            foreach (var notification in notifications)
            {
                notification.IsRead = true;
            }

            _context.SaveChanges();


            return View(notifications);
        }


        public IActionResult Read(int id)
        {
            var notification = _context.Notifications
                .FirstOrDefault(n => n.Id == id);


            if (notification == null)
                return NotFound();


            notification.IsRead = true;

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

            var notification = _context.Notifications
                .FirstOrDefault(n => n.Id == id && n.UserId == userId.Value);

            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
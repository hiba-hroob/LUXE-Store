using Microsoft.AspNetCore.Mvc;
using Webproject.Data;
using Webproject.Models;

namespace Webproject.Controllers
{
    public class AdminWalletController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminWalletController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("IsAdmin") == "true";
        }

        public IActionResult Index()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("SignIn", "Account");
            }

            var users = _context.Users
                .Select(u => new AdminWalletViewModel
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    WalletBalance = u.WalletBalance
                })
                .ToList();

            return View(users);
        }
    }
}
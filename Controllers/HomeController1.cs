using Microsoft.AspNetCore.Mvc;
using Webproject.Data;
using Webproject.Models;

namespace Webproject.Controllers
{
    public class WalletController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WalletController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("SignIn", "Account");

         
            if (HttpContext.Session.GetString("IsAdmin") == "true")
            {
                return RedirectToAction("Index", "AdminWallet");
            }

            var user = _context.Users
                .FirstOrDefault(u => u.Id == userId.Value);

            if (user == null)
                return RedirectToAction("SignIn", "Account");

            return View(user);
        }

 
        [HttpGet]
        public IActionResult AddMoney()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("SignIn", "Account");

            return View();
        }

 
        [HttpGet]
        public IActionResult Payment(decimal amount)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("SignIn", "Account");

            if (amount <= 0)
                return RedirectToAction("AddMoney");

            ViewBag.Amount = amount;

            return View();
        }


        [HttpPost]
        public IActionResult Payment(decimal amount, string cardNumber, string cvv)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("SignIn", "Account");

            cardNumber = cardNumber?.Replace(" ", "").Replace("-", "");

            const string demoCard = "4242424242424242";
            const string demoCvv = "123";

            if (cardNumber != demoCard || cvv != demoCvv)
            {
                ViewBag.Amount = amount;
                ViewBag.Error = "Payment failed. Invalid demo card details.";
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);

            if (user == null)
                return RedirectToAction("SignIn", "Account");

            user.WalletBalance += amount;

            var transaction = new WalletTransaction
            {
                UserId = user.Id,
                Amount = amount,
                Type = "Add Money",
                Status = "Completed",
                CreatedAt = DateTime.Now
            };

            _context.WalletTransactions.Add(transaction);
            _context.SaveChanges();

            return RedirectToAction("PaymentSuccess", new { amount });
        }

        [HttpGet]
        public IActionResult PaymentSuccess(decimal amount)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("SignIn", "Account");

            ViewBag.Amount = amount;

            return View();
        }
    }
}
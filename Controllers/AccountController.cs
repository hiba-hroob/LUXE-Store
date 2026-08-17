using Microsoft.AspNetCore.Mvc;
using Webproject.Data;
using Webproject.Models;


namespace Webproject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(User user)
        {
             var dbUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (dbUser != null)
            {
                HttpContext.Session.SetInt32("UserId", dbUser.Id);
                HttpContext.Session.SetString("UserName", dbUser.FullName);


          
                if (dbUser.Email == "hiba@gmail.com")
                {
                    HttpContext.Session.SetString("IsAdmin", "true");
                }


                return RedirectToAction("Index", "Products");
            }

            ViewBag.Error = "Invalid email or password.";
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                var exists = _context.Users.Any(u => u.Email == user.Email);
                if (exists)
                {
                    ViewBag.Error = "This email is already registered.";
                    return View();
                }

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("SignIn");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }




        [HttpGet]
        public IActionResult ChangePassword()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Products");


        }

    }


}


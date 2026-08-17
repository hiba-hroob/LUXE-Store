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
            var user = new User();

            var email = TempData["SignUpEmail"] as string;
            var password = TempData["SignUpPassword"] as string;

            if (!string.IsNullOrEmpty(email))
            {
                user.Email = email;
            }

            if (!string.IsNullOrEmpty(password))
            {
                user.Password = password;
            }

            return View(user);
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
            return View(new User());
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Please fill in all fields correctly.";
                return View(user);
            }

            var exists = _context.Users.Any(u => u.Email == user.Email);

            if (exists)
            {
                ViewBag.Error = "This email is already registered.";
                return View(user);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["SignUpEmail"] = user.Email;
            TempData["SignUpPassword"] = user.Password;

            return RedirectToAction("SignIn");
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

        [HttpPost]
        public IActionResult ChangePassword(
    string CurrentPassword,
    string NewPassword,
    string ConfirmPassword)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn");
            }

            var user = _context.Users.Find(userId.Value);

            if (user == null)
            {
                return NotFound();
            }

            if (user.Password != CurrentPassword)
            {
                ViewBag.Error = "Current password is incorrect.";
                return View();
            }

        
            if (NewPassword != ConfirmPassword)
            {
                ViewBag.Error = "New passwords do not match.";
                return View();
            }

     
            user.Password = NewPassword;

            _context.Users.Update(user);
            _context.SaveChanges();

            ViewBag.Success = "Password updated successfully.";

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


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webproject.Data;
using Webproject.Models;

namespace Webproject.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("SignIn", "Account");

            var favorites = _context.Favorites
                .Include(f => f.Product)
                .Where(f => f.UserId == userId.Value)
                .ToList();

            return View(favorites);
        }
        [HttpPost]
        public IActionResult Add(int productId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");


if (userId == null)
            {
                return Json(new
                {
                    success = false,
                    loginRequired = true
                });
            }

            var exists = _context.Favorites.Any(f =>
                f.UserId == userId.Value &&
                f.ProductId == productId);

            if (!exists)
            {
                var favorite = new Favorite
                {
                    UserId = userId.Value,
                    ProductId = productId
                };

                _context.Favorites.Add(favorite);
                _context.SaveChanges();
            }

            return Json(new
            {
                success = true,
                liked = true
            });


}

        [HttpPost]
        public IActionResult Remove(int productId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");


if (userId == null)
            {
                return Json(new
                {
                    success = false,
                    loginRequired = true
                });
            }

            var favorite = _context.Favorites.FirstOrDefault(f =>
                f.UserId == userId.Value &&
                f.ProductId == productId);

            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                _context.SaveChanges();
            }

            return Json(new
            {
                success = true,
                liked = false
            });


}

    }
}



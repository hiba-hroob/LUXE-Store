using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webproject.Data;
using Webproject.Models; 
namespace Webproject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var productsQuery = _context.Products.AsQueryable();


if (!string.IsNullOrEmpty(searchString))
            {
                productsQuery = productsQuery.Where(p =>
                    p.Name.Contains(searchString) ||
                    p.Brand.Contains(searchString));
            }

            var productsList = await productsQuery.ToListAsync();

            var grouped = productsList
                .GroupBy(p => p.Category ?? "Unknown Category")
                .ToDictionary(g => g.Key, g => g.ToList());

            var userId = HttpContext.Session.GetInt32("UserId");

            var favoriteProductIds = new List<int>();

            if (userId != null)
            {
                favoriteProductIds = await _context.Favorites
                    .Where(f => f.UserId == userId.Value)
                    .Select(f => f.ProductId)
                    .ToListAsync();
            }

            ViewBag.FavoriteProductIds = favoriteProductIds;

            var viewModel = new ProductIndexViewModel
            {
                SearchString = searchString,
                GroupedProducts = grouped
            };

            return View(viewModel);


}

    }
}
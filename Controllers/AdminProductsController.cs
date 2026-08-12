using Microsoft.AspNetCore.Mvc;
using Webproject.Data;
using Webproject.Models;

namespace Webproject.Controllers
{
    public class AdminProductsController : Controller
    {

        private readonly ApplicationDbContext _context;


        public AdminProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("IsAdmin") == "true";
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }



        [HttpGet]
        public IActionResult Create()
        {

            if (!IsAdmin())
            {
                return RedirectToAction("SignIn", "Account");
            }


            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {

            if (!IsAdmin())
            {
                return RedirectToAction("SignIn", "Account");
            }


            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(product);
        }



        public IActionResult Delete(int id)
        {

            if (!IsAdmin())
            {
                return RedirectToAction("SignIn", "Account");
            }


            var product = _context.Products.Find(id);


            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }


            return RedirectToAction("Index");
        }

    }
}
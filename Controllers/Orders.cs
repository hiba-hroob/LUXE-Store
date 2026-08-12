using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using Webproject.Data;
using Webproject.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Webproject.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Checkout()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpPost]

        public IActionResult ConfirmOrder(List<int> selectedProducts)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("SignIn", "Account");

            if (selectedProducts == null || selectedProducts.Count == 0)
                return RedirectToAction("Checkout");

            var products = _context.Products
                .Where(p => selectedProducts.Contains(p.Id))
                .ToList();

            if (products.Count == 0)
                return RedirectToAction("Checkout");

            var total = products.Sum(p => p.Price);

            var order = new Order
            {
                UserId = userId.Value,
                OrderDate = DateTime.Now,
                TotalPrice = total
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var product in products)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Price = product.Price
                };

                _context.OrderDetails.Add(orderDetail);
            }

            var notification = new Notification
            {
                UserId = userId.Value,
                Message = $"Your order #{order.Id} has been confirmed successfully.",
                CreatedAt = DateTime.Now,
                IsRead = false
            };

            _context.Notifications.Add(notification);

            _context.SaveChanges();

            return RedirectToAction("MyOrders", "Orders");
        }

        [HttpPost]
public IActionResult Delete(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("SignIn", "Account");

            var order = _context.Orders
                .FirstOrDefault(o => o.Id == id && o.UserId == userId.Value);

            if (order == null)
                return NotFound();

            var details = _context.OrderDetails
                .Where(d => d.OrderId == order.Id)
                .ToList();

            _context.OrderDetails.RemoveRange(details);

            _context.Orders.Remove(order);

            _context.SaveChanges();

            return RedirectToAction("MyOrders");
        }

        public IActionResult MyOrders()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("SignIn", "Account");

            var orders = _context.Orders
                .Where(o => o.UserId == userId.Value)
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("SignIn", "Account");

            var order = _context.Orders.FirstOrDefault(o => o.Id == id && o.UserId == userId);
            if (order == null) return NotFound();

            var orderDetails = _context.OrderDetails
                .Include(od => od.Product) 
                .Where(od => od.OrderId == id)
                .ToList();

            return View(orderDetails);
        }

        public IActionResult Success(int[] ids) 
        {
            var products = _context.Products.Where(p => ids.Contains(p.Id)).ToList();
            ViewBag.Products = products; 
            ViewBag.Total = products.Sum(p => p.Price);
            return View();
        }
    }
}
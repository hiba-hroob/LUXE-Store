using Microsoft.AspNetCore.Mvc;
using Webproject.Data;
using Webproject.Models;
using System.Collections.Generic;
using System.Linq;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    private static List<CartItem> cart = new List<CartItem>();
    public static List<CartItem> GetCart()
    {
        return cart;
    }

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }


    public IActionResult AddToCart(int id)
    {


        if (HttpContext.Session.GetInt32("UserId") == null)
        {
            return RedirectToAction("SignIn", "Account");
        }


        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }


        var existingItem = cart.FirstOrDefault(c => c.ProductId == id);


        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            cart.Add(new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1
            });
        }

        int count = HttpContext.Session.GetInt32("CartCount") ?? 0;
        count++;
        HttpContext.Session.SetInt32("CartCount", count);

        return RedirectToAction("Index");
    }




    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("UserId") == null)
        {
            return RedirectToAction("SignIn", "Account");
        }


        return View(cart);
    }




    public IActionResult Remove(int id)
    {
        if (HttpContext.Session.GetInt32("UserId") == null)
        {
            return RedirectToAction("SignIn", "Account");
        }

        var item = cart.FirstOrDefault(c => c.ProductId == id);

        if (item != null)
        {
            cart.Remove(item);
        }

        int cartCount = cart.Sum(c => c.Quantity);

        HttpContext.Session.SetInt32("CartCount", cartCount);

        return RedirectToAction("Index");
    }

    public IActionResult Increase(int id)
    {
        if (HttpContext.Session.GetInt32("UserId") == null)
        {
            return RedirectToAction("SignIn", "Account");
        }


        var item = cart.FirstOrDefault(c => c.ProductId == id);


        if (item != null)
        {
            item.Quantity++;
        }


        return RedirectToAction("Index");
    }



    
    public IActionResult Decrease(int id)
    {
        if (HttpContext.Session.GetInt32("UserId") == null)
        {
            return RedirectToAction("SignIn", "Account");
        }


        var item = cart.FirstOrDefault(c => c.ProductId == id);


        if (item != null)
        {
            item.Quantity--;


            if (item.Quantity <= 0)
            {
                cart.Remove(item);
            }
        }


        return RedirectToAction("Index");
    }
} 
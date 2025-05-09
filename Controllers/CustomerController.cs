using Microsoft.AspNetCore.Mvc;
using Product.Data;
using Product.Models;

public class CustomerController : Controller
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Customer customer)
    {
        if (ModelState.IsValid)
        {
            customer.RegisterDate = DateTime.Now;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        return View(customer);
    }
}
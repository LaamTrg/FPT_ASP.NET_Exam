using Microsoft.AspNetCore.Mvc;
using Product.Data;
using Product.Models;

public class RentalController : Controller
{
    private readonly AppDbContext _context;

    public RentalController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        ViewBag.Customers = _context.Customers.ToList();
        ViewBag.Products = _context.Products.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Rental rental, List<RentalDetail> rentalDetails)
    {
        if (ModelState.IsValid)
        {
            rental.RentalDate = DateTime.Now;
            _context.Rentals.Add(rental);
            _context.SaveChanges();

            foreach (var detail in rentalDetails)
            {
                detail.RentalId = rental.RentalId;
                _context.RentalDetails.Add(detail);
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        return View(rental);
    }
}
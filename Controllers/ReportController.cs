using Microsoft.AspNetCore.Mvc;
using Product.Data;

public class ReportController : Controller
{
    private readonly AppDbContext _context;

    public ReportController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult AllProducts()
    {
        var products = _context.Products.ToList();
        return View(products);
    }
}
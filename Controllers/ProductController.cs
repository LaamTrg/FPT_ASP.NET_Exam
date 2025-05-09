using Microsoft.AspNetCore.Mvc;
using Product.Data;
using Product.Models;

public class ProductController : Controller
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        try
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            return View("Error", new ErrorViewModel { RequestId = ex.Message });
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                ModelState.AddModelError("", "An error occurred while saving the product.");
            }
        }
        return View(product);
    }

    public IActionResult Edit(int id)
    {
        try
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            return View("Error", new ErrorViewModel { RequestId = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                ModelState.AddModelError("", "An error occurred while updating the product.");
            }
        }
        return View(product);
    }

    public IActionResult Delete(int id)
    {
        try
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            return View("Error", new ErrorViewModel { RequestId = ex.Message });
        }
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        try
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            return View("Error", new ErrorViewModel { RequestId = ex.Message });
        }
    }
}
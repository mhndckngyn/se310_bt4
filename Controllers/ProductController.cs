using ASP_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers;

public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        _productService = new ProductService(connectionString);
    }

    public IActionResult Index()
    {
        var products = _productService.GetAllProducts();
        return View(products);
    }

    public IActionResult DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
        return RedirectToAction("Index");
    }
}
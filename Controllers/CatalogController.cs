using ASP_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers;

public class CatalogController : Controller
{
    private readonly CatalogService _catalogService;

    public CatalogController(IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        _catalogService = new CatalogService(connectionString);
    }

    public IActionResult Index()
    {
        var catalogs = _catalogService.GetAllCatalogs();
        return View(catalogs);
    }

    public IActionResult DeleteCatalog(int id)
    {
        _catalogService.DeleteCatalog(id);
        return RedirectToAction("Index");
    }
}
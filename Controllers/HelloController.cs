using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers;

public class HelloController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GuiLoiChao()
    {
        return Content("Gui loi chao content");
    }

    public IActionResult HocMVCKhongKho()
    {
        ViewBag.Message = "Tra loi: Hoc MVC ntn?";
        return View();
    }
}
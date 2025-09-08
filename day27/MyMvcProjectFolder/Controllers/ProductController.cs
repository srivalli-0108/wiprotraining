using Microsoft.AspNetCore.Mvc;

namespace MyMvcProject.Controllers;

[Route("products")]
public class ProductController : Controller
{
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
     [Route("details/{id}")]
    public IActionResult Details(int id)
    {
        // Example: Retrieve product details using the id
        ViewBag.ProductId = id;
        return View();
    }

    [Route("list")]
    public IActionResult List()
    {
        var products = new List<string> { "Laptop", "Phone", "Tablet" };
        ViewBag.Products = products;
        return View();
    }
}
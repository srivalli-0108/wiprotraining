using Microsoft.AspNetCore.Mvc;
using MvcModelBinding.Models;

namespace MvcModelBinding.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            return View("Details", person);
        }
    }
}

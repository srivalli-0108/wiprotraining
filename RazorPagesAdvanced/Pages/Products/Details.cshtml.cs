using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAdvanced.Models;

namespace RazorPagesAdvanced.Pages.Products
{
    public class DetailsModel : PageModel
    {
        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = IndexModel.Products.FirstOrDefault(p => p.ProductID == id);
            return Product == null ? NotFound() : Page();
        }
    }
}

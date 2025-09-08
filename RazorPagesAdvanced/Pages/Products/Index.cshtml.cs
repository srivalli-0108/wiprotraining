using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAdvanced.Models;
using System.Collections.Generic;

namespace RazorPagesAdvanced.Pages.Products
{
    public class IndexModel : PageModel
    {
        public static List<Product> Products = new(); // Simulated DB
        public List<Product> ProductList => Products;

        public void OnGet() { }
    }
}

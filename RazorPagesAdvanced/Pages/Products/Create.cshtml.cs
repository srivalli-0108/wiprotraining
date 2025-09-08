using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAdvanced.Models;

namespace RazorPagesAdvanced.Pages.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public string[] CategoryNames { get; set; }

        public IActionResult OnPost()
        {
            foreach (var name in CategoryNames)
            {
                Product.Categories.Add(new Category { Name = name });
            }

            IndexModel.Products.Add(Product);
            return RedirectToPage("Index");
        }
    }
}

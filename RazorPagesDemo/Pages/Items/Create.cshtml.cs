using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages.Items
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Item NewItem { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            IndexModel.Items.Add(NewItem); // Add to static list
            return RedirectToPage("Index");
        }
    }
}

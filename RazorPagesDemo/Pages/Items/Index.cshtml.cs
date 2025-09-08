using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;
using System.Collections.Generic;

namespace RazorPagesDemo.Pages.Items
{
    public class IndexModel : PageModel
    {
        public static List<Item> Items = new List<Item>(); // Simulated DB

        public void OnGet()
        {
            // Nothing needed, Items already available
        }
    }
}

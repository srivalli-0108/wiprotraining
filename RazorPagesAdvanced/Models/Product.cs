using System.Collections.Generic;

namespace RazorPagesAdvanced.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Category> Categories { get; set; } = new();
    }
}

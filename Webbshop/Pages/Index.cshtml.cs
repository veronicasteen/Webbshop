using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext database;

        public List <Product> Products { get; set; }


        public IndexModel(AppDbContext database)
        {
            this.database = database;
        }

        public void OnGet(int pageNumber, string searchItem, string category)
        {

			var pageSize = 10;

            Products = database.Products.OrderBy(p => p.Price).ToList();
			
			if (!string.IsNullOrEmpty(searchItem))
			{
				// Filtrera produkter baserat på söktermen
				Products = Products.Where(p => p.Name.ToLower().Contains(searchItem)).ToList();
			}

			// Kontrollera om det finns en vald kategori
			if (!string.IsNullOrEmpty(category) && category != "Any category")
			{
				// Filtrera produkter baserat på kategorin
				Products = Products.Where(p => p.Category.ToLower() == category.ToLower()).ToList();
			}

			Products = Products.Skip((pageNumber -1 ) * pageSize)
				.Take(pageSize).ToList();
			
		}
    }
}
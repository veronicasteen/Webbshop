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

		public int PageNumber { get; set; } 

		public int TotalPages { get; set; }

        public IndexModel(AppDbContext database)
        {
            this.database = database;
        }

        public void OnGet(int pageNumber, string searchItem, string category)
        {
			PageNumber= pageNumber;
			var pageSize = 10;

            Products = database.Products.OrderBy(p => p.Price).ToList();
			
			if (!string.IsNullOrEmpty(searchItem))
			{
				Products = Products.Where(p => p.Name.ToLower().Contains(searchItem)).ToList();
			}

			if (!string.IsNullOrEmpty(category) && category != "Any category")
			{
				Products = Products.Where(p => p.Category.ToLower() == category.ToLower()).ToList();
			}

            int totalProducts = Products.Count; 
            TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize);
            PageNumber = Math.Clamp(PageNumber, 1, TotalPages);

            //Här sätts första sidan till 1 även om använderen inte gjort en sökning än
            if (PageNumber < 1)
            {
                PageNumber = 1;
            }

            Products = Products.Skip((pageNumber -1 ) * pageSize)
				.Take(pageSize).ToList();
			
		}
    }
}
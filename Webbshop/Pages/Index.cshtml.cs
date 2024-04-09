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

        public void OnGet()
        {
            Products = database.Products.ToList();
        }
    }
}
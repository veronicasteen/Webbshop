using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Pages
{
    public class DetailsModel : PageModel
    {

        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public void OnGet(int id)
        {
            Product = _context.Products.Find(id);

        }
    }
}

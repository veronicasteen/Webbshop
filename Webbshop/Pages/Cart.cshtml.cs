using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Pages
{
    public class CartModel : PageModel
    {

        private readonly AppDbContext database;
        private readonly AccessControl accessControl;


        public CartModel(AppDbContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }
        public List<AccountProduct> CartItems { get; set; }
        public double TotalAmount { get; set; }
        public Product Product { get; set; }


        public void OnGet()
        {
            var loggedInUserId = accessControl.LoggedInAccountID;

            CartItems = database.AccountProducts
            .Include(ap => ap.Product) // Inkludera produkter
            .Where(ap => ap.AccountID == loggedInUserId)
            .ToList();

            TotalAmount = CartItems.Sum(ap => ap.Product.Price * ap.Quantity);
        }
    }
}

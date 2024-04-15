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


        private List<AccountProduct> GetCartItems()
        {
            var loggedInUserId = accessControl.LoggedInAccountID;

            return database.AccountProducts
                .Include(ap => ap.Product)
                .Where(ap => ap.AccountID == loggedInUserId)
                .ToList();
        }

        public void OnGet()
        {
            CartItems = GetCartItems();
            TotalAmount = CartItems.Sum(ap => ap.Product.Price * ap.Quantity);
        }

        public void OnPostDelete()
        {
            var cartItemsToRemove = GetCartItems();
            RemoveCartItems(cartItemsToRemove);
        }

        private IActionResult RemoveCartItems(List<AccountProduct> cartItems)
        {
            database.AccountProducts.RemoveRange(cartItems);
            database.SaveChanges();

            return Page();
        }

        public IActionResult OnPostOrder()
        {
            var cartItemsToRemove = GetCartItems();
            CartItems = cartItemsToRemove; // Tilldela CartItems med värdet från GetCartItems()
            double totalAmount = CartItems.Sum(ap => ap.Product.Price * ap.Quantity);

            RemoveCartItems(cartItemsToRemove);

            // Skapa en redirect URL med totalpriset som querysträng
            return RedirectToPage("/Confirmation", new { totalAmount = totalAmount });
        }


    }
}

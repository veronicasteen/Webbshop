using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Pages
{
    public class DetailsModel : PageModel
    {

        private readonly AppDbContext database;
        private readonly AccessControl accessControl;


        public DetailsModel(AppDbContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public Product Product { get; set; }

        public void OnGet(int id)
        {
            Product = database.Products.Find(id);
        }
        public IActionResult OnPost(int id)
        {
            
            var loggedInUserId = accessControl.LoggedInAccountID;

            var existingProduct = database.AccountProducts.SingleOrDefault(ap => ap.AccountID == loggedInUserId && ap.ProductID == id);

            if (existingProduct != null)
            {
                existingProduct.Quantity++;
            }

            else
            {
                var accountProduct = new AccountProduct
                {
                    ProductID = id,
                    AccountID = loggedInUserId,
                    Quantity = 1
                };

                database.AccountProducts.Add(accountProduct);
            }
           
            database.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}

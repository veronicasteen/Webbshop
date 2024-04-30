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


		public double CalculateTotalAmount(List<AccountProduct> cartItems)
		{
			return Math.Round(cartItems.Sum(ap => ap.Product.Price * ap.Quantity), 2);
		}

		public List<AccountProduct> GetCartItems()
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
			TotalAmount = CalculateTotalAmount(CartItems);
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
			CartItems = cartItemsToRemove; 
			TotalAmount = CalculateTotalAmount(CartItems);
			RemoveCartItems(cartItemsToRemove);

			return RedirectToPage("/Confirmation", new { totalAmount = TotalAmount });
		}

	}
}

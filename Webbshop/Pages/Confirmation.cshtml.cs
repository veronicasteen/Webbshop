using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webbshop.Data;

namespace Webbshop.Pages
{
    public class ConfirmationModel : PageModel
    {

		public double TotalAmount { get; set; }


		public void OnGet(double totalAmount)
        {
            TotalAmount = totalAmount;
        }
    }
}

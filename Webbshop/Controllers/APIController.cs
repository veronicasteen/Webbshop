using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Controllers
{
    [Route("/api")]
    [ApiController]
    public class APIController : ControllerBase
    {
		private readonly AppDbContext database;

		public APIController(AppDbContext database)
        {
            this.database = database;
        }

		[HttpGet]
		[Route("/products")]
		public IActionResult GetProducts(int pageNumber, string searchItem, string category)
		{
			var pageSize = 10;

			// Hämta produkter från databasen
			var productsQuery = database.Products.AsQueryable();

			// Filtrera produkter baserat på sökterm
			if (!string.IsNullOrEmpty(searchItem))
			{
				productsQuery = productsQuery.Where(p => p.Name.ToLower().Contains(searchItem.ToLower()));
			}

			// Filtrera produkter baserat på kategori
			if (!string.IsNullOrEmpty(category) && category != "Any category")
			{
				productsQuery = productsQuery.Where(p => p.Category.ToLower() == category.ToLower());
			}

			// Sortera produkter baserat på pris, kanske kan ta bort detta
			productsQuery = productsQuery.OrderBy(p => p.Price);

			var products = productsQuery.Skip((pageNumber - 1) * pageSize)
										.Take(pageSize)
										.ToList();

			var formattedProducts = products.Select(p => new
			{
				p.Name,
				image = GetImage(p.ImagePath), // Funktion för att generera bild-URL
				p.Price,
				p.Category,
				p.Description
			});

			return Ok(formattedProducts);
		}

		public string GetImage(string imagePath)
		{
			string webURL = "https://localhost:5000/Pictures/";
			string imageURL = $"{webURL}{imagePath}";
			return imageURL;
		}
	}

}


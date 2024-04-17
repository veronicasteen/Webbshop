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
        public IActionResult GetProducts(int pageNumber, string searchItem, string category)
        {
			var pageSize = 10;

			var productsQuery = database.Products.AsQueryable();

			if (!string.IsNullOrEmpty(searchItem))
			{
				productsQuery = productsQuery.Where(p => p.Name.ToLower().Contains(searchItem.ToLower()));
			}

			if (!string.IsNullOrEmpty(category) && category != "Any category")
			{
				productsQuery = productsQuery.Where(p => p.Category.ToLower() == category.ToLower());
			}

			var products = productsQuery.Skip((pageNumber - 1) * pageSize)
										.Take(pageSize)
										.ToList();

			var imageURL = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
			
			var formattedProducts = products.Select(p => new
			{
				p.Name,
				image = $"{imageURL}/Pictures/{p.ImagePath}",
				p.Price,
				p.Category,
				p.Description
			});

			return Ok(formattedProducts);
		}

	}

}


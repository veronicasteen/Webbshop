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

			var products = database.Products.OrderBy(p => p.Price).ToList();

			if (!string.IsNullOrEmpty(searchItem))
			{
				products = products.Where(p => p.Name.ToLower().Contains(searchItem.ToLower())).ToList();
			}

			if (!string.IsNullOrEmpty(category) && category != "Any category")
			{
				products = products.Where(p => p.Category.ToLower() == category.ToLower()).ToList();
			}

			products = products.Skip((pageNumber - 1) * pageSize)
							   .Take(pageSize)
							   .ToList();



			return Ok(products);

		}

	}
}

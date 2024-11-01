using AddToCart.Data;
using AddToCart.Model;
using AddToCart.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace AddToCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService conn;
        private readonly MyDbContext db;
        public ProductController()
        {
            conn = new ProductService();
            db = new MyDbContext();
        }
        [HttpGet("Products")]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] int? limit, [FromQuery] string query = null)
        {
            var products = await conn.GetJewelryProductsAsync(limit, query);

            if (products == null)
            {
                return NotFound("No products found matching the criteria.");
            }

            return Ok(products);
        }


        [HttpPost("add-to-cart")]
        public async Task<IActionResult> AddToCart([FromBody] ProductCart product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            await db.AddAsync(product);
            await db.SaveChangesAsync();
            return Ok(product);

        }
    }
}

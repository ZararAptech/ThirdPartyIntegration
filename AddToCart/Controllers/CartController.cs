using AddToCart.Data;
using AddToCart.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace AddToCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly MyDbContext conn;
        public CartController()
        {
            conn = new MyDbContext();
        }

        [HttpGet("getitem")]
        public IActionResult Get()
        {
            var data = conn.Cartitems.ToList();
            return Ok(data);
        }


        [HttpPost("add")]
        public IActionResult AddCart([FromBody] cartitem newitem)
        {
            var existingitem = conn.Cartitems.FirstOrDefault(item => item.id == newitem.id);
            if (existingitem != null)
            {
                existingitem.Quantity += newitem.Quantity;
                conn.Cartitems.Update(existingitem);
            }
            else
            {
                conn.Cartitems.Add(newitem);
            }
            conn.SaveChanges();
            var cartitems = conn.Cartitems.ToList();
            return Ok(cartitems.Select(item => new

            {
                item.id,
                item.name,
                item.Quantity,
                item.price,
                item.totalprice,




            }));



        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var dlt = conn.Cartitems.Find(id);
            if (dlt != null)
            {
                conn.Cartitems.Remove(dlt);
                conn.SaveChanges();
                return Ok();
            }
            return Unauthorized("Item Not deleted successfully");
        }

        [HttpPut("update/{id}")]
        public IActionResult Update( cartitem cd, int id)
        {
            var upd = conn.Cartitems.Find(id);
            if(upd != null)
            {
                upd.name = cd.name;
                upd.Quantity = cd.Quantity;
                upd.price = cd.price;
                conn.Cartitems.Update(upd);
                conn.SaveChanges();
                return Ok(upd);
            }
            return BadRequest();

        }
        
    }
}

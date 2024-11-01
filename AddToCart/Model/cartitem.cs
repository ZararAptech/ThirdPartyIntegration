using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace AddToCart.Model
{
    public class cartitem
    {
        [Key]
        public int id {  get; set; }

        public string name { get; set; }

        public int Quantity { get; set; }

        public decimal price { get; set; }

        public decimal totalprice => Quantity * price;
    }
}

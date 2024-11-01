using AddToCart.Model;
using System.Net.Http;
using System.Text.Json;

namespace AddToCart.Services
{
    public class ProductService
    {
        private readonly HttpClient conn;
        public ProductService()
        {
            conn = new HttpClient();
        }



        public async Task<List<Product>> GetJewelryProductsAsync(int? limit = null, string query = null)
        {
            var url = "https://fakestoreapi.com/products";
            var response = await conn.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null; 
            }
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            if (query!= null)
            {
                products = products
                    .Where(p => p.Title.Contains(query))
                    .ToList();
            }
            if (limit.HasValue && limit > 0)
            {
                products = products.Take(limit.Value).ToList();
            }
            return products;
        }





        //public async Task<List<Product>> SearchProductsAsync(string query)
        //{
        //    var url = "https://fakestoreapi.com/products";
        //    var response = await conn.GetAsync(url);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return null;
        //    }
        //    var products = await response.Content.ReadFromJsonAsync<List<Product>>();
        //    var filteredProducts = products
        //        .Where(p => p.Title.Contains(query, StringComparison.OrdinalIgnoreCase))
        //        .ToList();
        //    return filteredProducts;
        //}

    }
}

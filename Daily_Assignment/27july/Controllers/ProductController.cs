using Microsoft.AspNetCore.Mvc;
using _27july.Models;

namespace _27july.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static List<Product> products = new List<Product>()
        {
            new Product() { Id = 1, Name = "Laptop", Category = "Electronics", Price = 55000, Quantity = 10 },
            new Product() { Id = 2, Name = "Keyboard", Category = "Electronics", Price = 1200, Quantity = 25 },
            new Product() { Id = 3, Name = "Chair", Category = "Furniture", Price = 3500, Quantity = 15 }
        };

        // Get all products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        // Get product by Id
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // Add new product
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            products.Add(product);
            return Ok(product);
        }

        // Update product
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var product1 = products.FirstOrDefault(x => x.Id == id);

            if (product1 == null)
            {
                return NotFound();
            }

            product1.Name = product.Name;
            product1.Category = product.Category;
            product1.Price = product.Price;
            product1.Quantity = product.Quantity;

            return Ok(product1);
        }

        // Delete product
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);

            return Ok("Product deleted successfully");
        }

        // Get products by category
        [HttpGet("Category/{category}")]
        public IActionResult GetProductByCategory(string category)
        {
            var result = products.Where(x =>
                x.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

            if (!result.Any())
            {
                return NotFound("No products found in this category");
            }

            return Ok(result);
        }
    }
}
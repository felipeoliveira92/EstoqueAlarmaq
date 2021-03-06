using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueAlarmaq.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        [HttpGet("id")]
        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.First(p => p.Id == id);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok();
        }
    }
}

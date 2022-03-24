using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueAlarmaq.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            //return _context.Products.ToList();
            return _productsRepository.SelectAll().ToList();
        }

        [HttpGet("id")]
        public Product GetProductById(int id)
        {
            //return _context.Products.FirstOrDefault(p => p.Id == id);
            return _productsRepository.Select(id);
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            //var product = _context.Products.First(p => p.Id == id);

            //_context.Products.Remove(product);
            //_context.SaveChanges();

            //return Ok();
            var product = _productsRepository.Delete(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            else
            {
                _productsRepository.Insert(product);
                return Ok();
            }
        }

        [HttpPut("id")]
        public IActionResult PutProduct(int id)
        {
            if(id == 0)
            {
                return BadRequest(id);
            }
            else
            {
                var product = _productsRepository.Select(id);
                _productsRepository.Update(id, product);
                return Ok();
            }
        }
    }
}

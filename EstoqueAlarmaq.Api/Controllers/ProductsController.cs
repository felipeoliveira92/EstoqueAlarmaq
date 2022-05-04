using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using EstoqueAlarmaq.Services.Repositories;
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
        private readonly ProductsRepository _productsRepository;

        public ProductsController(DataContext context, ProductsRepository productsRepository)
        {
            _context = context;
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            return _productsRepository.SelectAll().ToList();
        }

        [HttpGet("id")]
        public Product GetProductById(int id)
        {
            return _productsRepository.Select(id);
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            _productsRepository.Delete(id);
            return Ok();
        }
    }
}

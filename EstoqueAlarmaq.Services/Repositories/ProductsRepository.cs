using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using EstoqueAlarmaq.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Services.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;

        public ProductsRepository(DataContext context)
        {
            _context = context;
        }

        public Product New()
        {
            return new Product();
        }
        public Product Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            _context.Products.Remove(product);
            _context.SaveChanges();

            return product;
        }

        public void Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product Select(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public IEnumerable<Product> SelectAll()
        {
            return _context.Products.ToList();
        }

        public void Update(int id, Product product)
        {
            product.Id = id;
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}


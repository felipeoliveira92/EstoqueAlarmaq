using EstoqueAlarmaq.Application.Interfaces;
using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Application.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;

        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
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
